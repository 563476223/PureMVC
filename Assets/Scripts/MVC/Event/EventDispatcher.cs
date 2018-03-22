// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:01:35
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;

namespace MVC.Event
{
    public delegate void EventHandle(EventArgs args);
    public class EventDispatcher:IEventListener,IEventDispatcher
    {
        Queue<EventCollection> mCacheCollection = new Queue<EventCollection>();
        Queue<EventData> mCacheEvent = new Queue<EventData>();
        Dictionary<int, EventCollection> mCollections = new Dictionary<int, EventCollection>();

        private EventCollection GetUnUseCollection()
        {
            EventCollection collection = null;
            if (mCacheCollection.Count <= 0)
            {
                collection = new EventCollection();
            }
            else
            {
                collection = mCacheCollection.Dequeue();
            }
            return collection;
        }

        private EventData GetUnUseEventData()
        {
            EventData eventData = null;
            if (mCacheEvent.Count <= 0)
            {
                eventData = new EventData();
            }
            else
            {
                eventData = mCacheEvent.Dequeue();
            }
            return eventData;
        }

        public void AddEventListener(int type, EventHandle handle, int priority = 0)
        {
            EventCollection collection = null;
      
            if (!mCollections.TryGetValue(type,out collection))
            {
                collection = GetUnUseCollection();
                mCollections.Add(type, collection);
            }

            EventData eventData = GetUnUseEventData();
            eventData.Priority = priority;
            eventData.handle = handle;
            eventData.Type = type;
            collection.Add(eventData);
        }

        /// <summary>
        /// 所有type类型的事件都将受到该数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="sender"></param>
        public void DispatchEvent(int type, object data, object sender)
        {
            EventCollection collection = null;
            if (!mCollections.TryGetValue(type,out collection))
            {
                return;
            }
            EventArgs args = new EventArgs();
            args.SetData(data);
            args.Sender = sender;
            args.Type = type;

            List<EventData> evts = new List<EventData>(collection.Count);

            foreach (EventData eventData in collection)
            {
                evts.Add(eventData);
            }

            foreach (EventData eventData in evts)
            {
                eventData.handle(args);   
            }
        }

        public void DispatchEvent(int type)
        {
            DispatchEvent(type, null, null);
        }

        public void DispatchEvent(int type, object data)
        {
            DispatchEvent(type, data, null);
        }


        public void RemoveEventListener(int type)
        {
            EventCollection collection = null;
            if (!mCollections.TryGetValue(type,out collection))
            {
                return;
            }
            collection.Clear();
            mCollections.Remove(type);
            mCacheCollection.Enqueue(collection);
        }

        public void RemoveEventListener(int type, EventHandle handle)
        {
            EventCollection collection = null;
            if (!mCollections.TryGetValue(type,out collection))
            {
                return;
            }
            collection.Remove(handle);
            if (collection.Count == 0)
            {
                collection.Clear();
                mCollections.Remove(type);
                mCacheCollection.Enqueue(collection);
            }
        }
    }
}
