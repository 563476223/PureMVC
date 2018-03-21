// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:11:50
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Patterns;
using MVC.Interface;

namespace MVC.Core
{
    public class View:IView
    {
        private Dictionary<string, Mediator> mMediator = new Dictionary<string, Mediator>();
        public bool RegisterMediator(Mediator mediator)
        {
            if (HasMediator(mediator.Name))
            {
                return false;
            }
            mMediator.Add(mediator.Name, mediator);
            return true;
        }

        public bool HasMediator(string name)
        {
            if (mMediator.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public T RetrieveMediator<T>() where T : Mediator
        {
            string name = typeof(T).Name;
            if (HasMediator(name))
            {
                return (T)mMediator[name];
            }
            return default(T);
        }

        public bool UnRegisterMediator(string name)
        {
            if (HasMediator(name))
            {
                mMediator.Remove(name);
                return true;
            }
            return false;
        }

        public void Init()
        {
            foreach (Mediator mediator in mMediator.Values)
            {
                mediator.Init();
            }
        }
    }
}
