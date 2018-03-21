// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:50:37
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Scheduler;

namespace MVC.Patterns
{
    public class Commond : SchedulerRegister, IEventListener, IEventDispatcher
    {
        string name = "";
        public Commond(string name)
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

        public void AddEventListening(string type, Event.EventHandle handle, int priority = 0)
        {
            Facade.Instance.AddEventListening(type, handle, priority);
        }

        public void RemoveEventListening(string type)
        {
            Facade.Instance.RemoveEventListening(type);
        }

        public void RemoveEventListening(string type, Event.EventHandle handle)
        {
            Facade.Instance.RemoveEventListening(type, handle);
        }

        /// <summary>
        /// 派生类初始化
        /// </summary>
        public virtual void Start()
        {

        }
    }

}
