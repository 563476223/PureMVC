// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:49:44
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;
using MVC;
public class View:IView
{
    private Dictionary<string, Mediator> mediatorDic = new Dictionary<string, Mediator>();
    public bool UnRegisterMediator(string name)
    {
        if (!HasMediator(name))
        {
            return false;
        }
        mediatorDic.Remove(name);
        return true;
    }

    public bool HasMediator(string name)
    {
        return mediatorDic.ContainsKey(name);
    }

    public T RetrieveMediator<T>() where T : Mediator
    {
        string name = typeof(T).Name;
        if (HasMediator(name))
        {
            return (T)mediatorDic[name];
        }
        return default(T);
    }

    public bool RegisterMediator(Mediator proxy)
    {
        if (!HasMediator(proxy.Name))
        {
            mediatorDic.Add(proxy.Name,proxy);
            return true;
        }
        return false;
    }

    public void Start()
    {
        foreach (Mediator me in mediatorDic.Values)
        {
            me.Start();
        }
    }
}