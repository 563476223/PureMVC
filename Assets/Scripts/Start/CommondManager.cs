// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:26:47
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Interface;
public class CommondManager
{
    IController mController = null;

    public CommondManager(IController controller)
    {
        mController = controller;
    }

    public void Register()
    {
        mController.RegisterCommond(new EffectCommond());
        mController.RegisterCommond(new BuffCommond());
    }
}
