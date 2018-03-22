// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:33:23
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

public class EffectMediator :Mediator
{
    private const string NAME = "EffectMediator";
    private BuffProxy mBuffProxy;
    public EffectMediator()
        : base(NAME)
    {

    }

    public override void Init()
    {
        mBuffProxy = RetrieveProxy<BuffProxy>();
        Debug.Log("EffectMediator获取buffnumb:  " + mBuffProxy.BuffNumb.ToString());
        Register();
    }

    private void Register()
    {
        AddEventListener(EventType.ADD_BUFF_EVENT, AddBuff);
    }

    private void AddBuff(MVC.Event.EventArgs args)
    {
        int cc = args.GetData<int>();
        Debug.Log("[事件通知] 添加特效了！！获取参数 " + cc.ToString());
    }

}