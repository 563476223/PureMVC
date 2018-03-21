// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:12:06
// ========================================================
using MVC.Event;
using MVC.Core;
namespace MVC.Patterns
{
    public abstract class Facade:EventDispatcher,IController,IView,IModle
    {
        private IController controller;
        private IView view;
        private IModle model;

        private static Facade _instance = null;

        public static Facade Instance
        {
            get
            {
                return _instance;
            }
        } 
           
        public Facade()
        {
            if (_instance == null)
            {
                _instance = this;   
                controller = new Controller();
                view = new View();
                model = new Modle();
            }   
        }

        public T RetrieveCommond<T>() where T : Commond
        {
            return controller.RetrieveCommond<T>();
        }

        public bool HasCommond(string name)
        {
            return controller.HasCommond(name);
        }

        public bool RegisterCommond(Commond commond)
        {
            return controller.RegisterCommond(commond);
        }

        public bool UnRegisterCommond(string name)
        {
            return controller.UnRegisterCommond(name);
        }

        public bool UnRegisterMediator(string name)
        {
            return view.UnRegisterMediator(name);
        }

        public bool HasMediator(string name)
        {
            return view.HasMediator(name);
        }

        public T RetrieveMediator<T>() where T : Mediator
        {
            return view.RetrieveMediator<T>();
        }

        public bool RegisterMediator(Mediator proxy)
        {
            return view.RegisterMediator(proxy);
        }

        public bool UnRegisterProxy(string name)
        {
            return model.UnRegisterProxy(name);
        }

        public bool HasProxy(string name)
        {
            return model.HasProxy(name);
        }

        public T RetrieveProxy<T>() where T : Proxy
        {
            return model.RetrieveProxy<T>();
        }

        public bool RegisterProxy(Proxy proxy)
        {
            return model.RegisterProxy(proxy);
        }
        public void Start()
        {
            controller.Start();
            view.Start();
            model.Start();
        }
    }
}