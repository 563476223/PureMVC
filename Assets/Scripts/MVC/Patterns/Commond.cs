// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:24:04
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;

namespace MVC.Patterns
{
    public class Commond:IEventListener,IEventDispatcher
    {
        private string name = "";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Commond(string name)
        {
            this.name = name;
        }

        public virtual void Init()
        {

        }


        public void AddEventListener(int type, Event.EventHandle handle, int priority = 0)
        {
            Facade.Instance.AddEventListener(type,handle,priority);
        }

        public void RemoveEventListener(int type)
        {
            Facade.Instance.RemoveEventListener(type);
        }

        public void RemoveEventListener(int type, Event.EventHandle handle)
        {
            Facade.Instance.RemoveEventListener(type,handle);
        }

        public void DispatchEvent(int type)
        {
            DispatchEvent(type, null, null);
        }

        public void DispatchEvent(int type, object data)
        {
            DispatchEvent(type, data, null);
        }

        public void DispatchEvent(int type, object data, object sender)
        {
            Facade.Instance.DispatchEvent(type, data, sender);
        }

        public T RetrieveMediator<T>() where T:Mediator
        {
            return Facade.Instance.RetrieveMediator<T>();
        }

        public T RetrieveProxy<T>() where T:Proxy
        {
            return Facade.Instance.RetrieveProxy<T>();
        }

        public T RetrieveCommond<T>() where T:Commond
        {
            return Facade.Instance.RetrieveCommond<T>();
        }
    }
}
