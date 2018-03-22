// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:33:01
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;


public class BuffProxy:Proxy
{
    private const string NAME = "BuffProxy";
    public BuffProxy()
        : base(NAME)
    {

    }
    public int BuffNumb = 1;
    public override void Init()
    {
        DispatchEvent(EventType.ADD_BUFF_EVENT, 123);
    }
}
