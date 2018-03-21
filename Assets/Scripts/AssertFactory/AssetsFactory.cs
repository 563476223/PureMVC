using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.AssertFactory;
using System;
using System.IO;

public class AssetsFactory : IAssertsLoad
{
    //--一个资源请求
    struct LoadRequest
    {
        public string assetPath;
        public List<Callback_1<UnityEngine.Object>> callback;
    };

    static AssetsFactory instance;

    public static AssetsFactory Instance
    {
        get
        {
            if (instance == null)
                instance = new AssetsFactory();
            return instance;
        }
    }

    delegate Coroutine StartCoroutineHandle(IEnumerator routine);

    StartCoroutineHandle startCoroutine;
    //缓存
    Dictionary<string, UnityEngine.Object> assertDic;

    Dictionary<string, LoadRequest> loadRequestDic;

    List<Callback_1<UnityEngine.Object>> callBackToLua;


    private AssetsFactory()
    {
        assertDic = new Dictionary<string, UnityEngine.Object>();
        loadRequestDic = new Dictionary<string, LoadRequest>();
        callBackToLua = new List<Callback_1<UnityEngine.Object>>();
    }

    public void InitAssetFactory()
    {
        startCoroutine = GameObject.Find("Launcher").GetComponent<Launcher>().StartCoroutine;
    }

    public UnityEngine.Object LoadAsset(string path)
    {
        //throw new NotImplementedException();
        return null;
    }

    public void LoadAssetAsync(string path, Callback_1<UnityEngine.Object> loadDoneCallBack)
    {
        UnityEngine.Object asset;
        if (assertDic.TryGetValue(path, out asset))
        {
            loadDoneCallBack(asset);
            return;
        }

        LoadRequest request;

        if (loadRequestDic.TryGetValue(path, out request))
        {
            request.callback.Add(loadDoneCallBack);
        }
        else
        {
            request = new LoadRequest();
            request.assetPath = path;
            request.callback = new List<Callback_1<UnityEngine.Object>>();
            request.callback.Add(loadDoneCallBack);
            loadRequestDic.Add(path, request);
            startCoroutine(loadLocalAsset(request));
        }
    }

    IEnumerator loadLocalAsset(LoadRequest L)
    {
        bool isSuccess = false;
        string path = L.assetPath;
 
        path = path.Replace("Assets/", "").Replace("Resources/", "").Replace(Path.GetExtension(path), "");
        ResourceRequest load = Resources.LoadAsync(path);
        yield return load;

        if (load.asset != null)
        {
            if (!assertDic.ContainsKey(L.assetPath))
            {
                assertDic.Add(L.assetPath, load.asset);
            }
            isSuccess = true;
        }

        LoadAssetDone(isSuccess, L.assetPath);
    }

    //此时需要将prefab传递给lua
    private void LoadAssetDone(bool isSucess,string path)
    {
        LoadRequest L;

        if (!loadRequestDic.TryGetValue(path,out L))
        {
            return;
        }

        loadRequestDic.Remove(path);
            
        if (isSucess == false)
            Debug.LogError("LoadAsset Failed!!!!" + path);

        callBackToLua.Clear();
        int count = L.callback.Count;
        for (int i = 0; i < count; i++)
        {
            callBackToLua.Add(L.callback[i]);
        }

        UnityEngine.Object asset = isSucess ? assertDic[path] : null;

        for (int i = 0; i < count; i++)
        {
            try
            {
                callBackToLua[i](asset);
            }
            catch (Exception error)
            {
                Debug.LogError(error);
            }
        }
    }

    /// <summary>
    /// 资源的释放
    /// </summary>
    /// <param name="path"></param>
    /// <param name="bunderState"></param>
    public void UnLoadAsset(string path,bool bunderState)
    {
        UnityEngine.Object asset;
        if (assertDic.TryGetValue(path,out asset))
        {
            if (bunderState)
            {
                (asset as AssetBundle).Unload(false);
            }
            else
            {
                //--资源释放
            }
            assertDic.Remove(path);
        }
    }

    //取消加载
    public void CancleLoad(string path,Callback_1<UnityEngine.Object> callFunc)
    {
        LoadRequest L;
        if (loadRequestDic.TryGetValue(path,out L))
        {
            int count = L.callback.Count;
            for (int i = 0; i < count; i++)
            {
                if (L.callback[i] == callFunc)
                {
                    L.callback.Remove(callFunc);
                    return;
                }
            }

            if (count == 0)
            {
                loadRequestDic.Remove(path);
            }
        }
    }
}
