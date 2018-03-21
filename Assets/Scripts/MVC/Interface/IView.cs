// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:15:08
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Patterns;

namespace MVC.Interface
{
    public interface IView
    {
        bool RegisterMediator(Mediator mediator);
        bool HasMediator(string name);
        T RetrieveMediator<T>() where T : Mediator;
        bool UnRegisterMediator(string name);
        void Init();
    }
}

