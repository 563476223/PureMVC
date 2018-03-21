// ========================================================
// 描 述：事件的分发和监听
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:13:29
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Event
{
    public delegate void EventHandle(EventArgs args);
    public class EventDispatcher:IEventListener,IEventDispatcher
    {
        private Queue<EventData> cacheEventData = new Queue<EventData>();
        private Queue<EventCollection> cacheEventCollection = new Queue<EventCollection>();
        private Dictionary<string, EventCollection> eventDic = new Dictionary<string, EventCollection>();

        public void AddEventListening(string type, EventHandle handle, int priority = 0)
        {
            EventCollection collection = GetUseCollection(type);
            EventData data = GetCacheEventData();
            data.Priority = priority;
            data.handle = handle;
            data.Type = type;
            collection.Add(data);
        }

        public void RemoveEventListening(string type)
        {
            EventCollection collection;
            if (eventDic.TryGetValue(type,out collection))
            {
                collection.Clear();
                cacheEventCollection.Enqueue(collection);
                eventDic.Remove(type);
            }
        }

        public void RemoveEventListening(string type, EventHandle handle)
        {
            EventCollection collection;
            if (eventDic.TryGetValue(type,out collection))
            {
                collection.Remove(handle);
                if (collection.Count == 0)
                {
                    collection.Clear();
                    cacheEventCollection.Enqueue(collection);
                    eventDic.Remove(type);
                }
            }
        }

        public void DispatcherEvent(string type)
        {
            DispatcherEvent(type, null, null);
        }

        public void DispatcherEvent(string type, object data)
        {
            DispatcherEvent(type, data, null);
        }

        public void DispatcherEvent(string type, object data, object sender)
        {
            EventCollection collection = null;
            if (eventDic.TryGetValue(type,out collection))
            {
                EventArgs args = new EventArgs();
                args.SetData(data);
                args.Sender = sender;
                args.Type = type;
                List<EventData> tempEventData = new List<EventData>(collection.Count);

                foreach (EventData ev in collection)
                {
                    tempEventData.Add(ev);
                }

                foreach (EventData ev in tempEventData)
                {
                    if (ev.handle != null)
                    {
                        ev.handle(args);
                    }
                }
            }
        }

        private EventCollection GetUseCollection(string type)
        {
            EventCollection collection;
            if (!eventDic.TryGetValue(type,out collection))
            {
                collection = GetCacheCollection();
                eventDic.Add(type, collection);
            }
            return collection;
        }

        private EventCollection GetCacheCollection()
        {
            EventCollection collection = null;
            if (cacheEventCollection.Count <= 0)
            {
                collection = new EventCollection();
            }
            else
                collection = cacheEventCollection.Dequeue();
            return collection;
        }

        private EventData GetCacheEventData()
        {
            EventData eventData = null;
            if (cacheEventData.Count <= 0)
            {
                eventData = new EventData();
            }
            else
                eventData = cacheEventData.Dequeue();
            return eventData;
        }
    }
}
