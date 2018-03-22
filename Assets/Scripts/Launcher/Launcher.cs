using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Lua;

public class Launcher : MonoBehaviour 
{
    void Awake()
    {

    }

    void Start()
    {
        Launch();
    }

    void Launch()
    {
        AssetsFactory.Instance.InitAssetFactory();
        LuaManager.Instance.Luanch();
        GameFacade.Instance.Init();
    }
}
