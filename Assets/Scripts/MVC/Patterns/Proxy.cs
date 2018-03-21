// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:50:26
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Scheduler;


namespace MVC.Patterns
{
    public class Proxy:SchedulerRegister,IEventDispatcher
    {
        private string name;
        public Proxy(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        public virtual void Start()
        {

        }

        public void DispatcherEvent(string type)
        {
            Facade.Instance.DispatcherEvent(type);
        }

        public void DispatcherEvent(string type, object data)
        {
            Facade.Instance.DispatcherEvent(type, data);
        }

        public void DispatcherEvent(string type, object data, object sender)
        {
            Facade.Instance.DispatcherEvent(type, data, sender);
        }
    }
}

