using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AssertFactory
{
    public interface IAssertsLoad
    {
        /// <summary>
        /// 资源异步加载
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loadDoneCallBack"></param>
        void LoadAssetAsync(string path,Callback_1<UnityEngine.Object> loadDoneCallBack);

        /// <summary>
        /// 资源同步加载
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        UnityEngine.Object LoadAsset(string path);


    }
}
