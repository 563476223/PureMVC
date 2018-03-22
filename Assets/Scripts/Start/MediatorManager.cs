// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:26:37
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Interface;
public class MediatorManager
{
    IView mView = null;
    public MediatorManager(IView view)
    {
        mView = view;
    }

    public void Register()
    {
        mView.RegisterMediator(new EffectMediator());
        mView.RegisterMediator(new BuffMediator());
    }
}
