// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:50:50
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Scheduler;

namespace MVC.Patterns
{
    public abstract class Mediator : SchedulerRegister,IEventDispatcher, IEventListener
    {
        string name = "";
        Transform[] layers;
        public Mediator(string name,Transform[] layers)
        {
            this.name = name;
            this.layers = layers;
        }

        protected Transform[] Layers
        {
            get
            {
                return layers;
            }
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
    }
}

