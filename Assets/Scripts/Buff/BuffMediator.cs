// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:33:11
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

public class BuffMediator :Mediator
{
    private const string NAME = "BuffMediator";
    public BuffMediator()
        : base(NAME)
    {

    }

    public override void Init()
    {
    }
}
