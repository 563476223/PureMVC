// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:44:31
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

namespace MVC
{
    interface IView
    {
        bool UnRegisterMediator(string name);
        bool HasMediator(string name);
        T RetrieveMediator<T>() where T : Mediator;
        bool RegisterMediator(Mediator proxy);
        void Start();

    }
}
