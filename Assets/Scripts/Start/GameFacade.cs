// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:26:10
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

public class GameFacade:Facade
{
    private ProxyManager mProxyMgr;
    private MediatorManager mMediatorMgr;
    private CommondManager mCommondMgr;
    private static GameFacade instance = null;
    public new static GameFacade Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameFacade();
            }
            return instance;
        }
    }

    public override void Init()
    {
        mProxyMgr = new ProxyManager(this);
        mProxyMgr.Register();
        mMediatorMgr = new MediatorManager(this);
        mMediatorMgr.Register();
        mCommondMgr = new CommondManager(this);
        mCommondMgr.Register();
        Debug.Log("初始化PureMVC框架完成！！");
        base.Init();
    }
}