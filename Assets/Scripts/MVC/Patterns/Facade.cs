// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:24:59
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;
using MVC.Core;

namespace MVC.Patterns
{
    /// <summary>
    /// 方便Core之间通信，外部无需关心内部实现
    /// </summary>
    public abstract class Facade:IModel,IView,IController
    {
        IModel mModel = null;
        IView mView = null;
        IController mController = null;
        private static Facade instance = null;
        public static Facade Instance
        {
            get
            {
                return instance;
            }
        }

        public Facade()
        {
            if (instance == null)
            {
                instance = this;
                mModel = new Model();
                mController = new Controller();
                mView = new View();
            }
        }

        public bool RegisterProxy(Proxy proxy)
        {
            return mModel.RegisterProxy(proxy);
        }

        public bool HasProxy(string name)
        {
            return mModel.HasProxy(name);
        }

        public T RetrieveProxy<T>() where T : Proxy
        {
            return mModel.RetrieveProxy<T>();
        }

        public bool UnRegisterProxy(string name)
        {
            return mModel.UnRegisterProxy(name);
        }

        public bool RegisterMediator(Mediator mediator)
        {
            return mView.RegisterMediator(mediator);
        }

        public bool HasMediator(string name)
        {
            return mView.HasMediator(name);
        }

        public bool UnRegisterMediator(string name)
        {
            return mView.UnRegisterMediator(name);
        }

        public T RetrieveMediator<T>() where T : Mediator
        {
            return mView.RetrieveMediator<T>();
        }
        public bool RegisterCommond(Commond commond)
        {
            return mController.RegisterCommond(commond);
        }

        public bool HasCommond(string name)
        {
            return mController.HasCommond(name);
        }

        public T RetrieveCommond<T>() where T : Commond
        {
            return mController.RetrieveCommond<T>();
        }

        public bool UnRegisterCommond(string name)
        {
            return mController.UnRegisterCommond(name);
        }

        public void Init()
        {
            mView.Init();
            mController.Init();
            mModel.Init();
        }


    }
}
