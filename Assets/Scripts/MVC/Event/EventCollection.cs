// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:13:39
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Event
{
    public class EventCollection:IEnumerable<EventData>
    {
        private List<EventData> events = new List<EventData>();

        public void Add(EventData data)
        {
            events.Add(data);
            events.Sort();
        }

        public void Clear()
        {
            events.Clear();
        }

        public void Remove(EventHandle handle)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].handle == handle)
                {
                    events.RemoveAt(i);
                    break;
                }
            }
        }

        public int Count
        {
            get
            {
                return events.Count;
            }
        }


        public IEnumerator<EventData> GetEnumerator()
        {
            int count = events.Count;
            for (int i = 0; i < count; i++)
            {
                yield return events[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int count = events.Count;
            for (int i = 0; i < count; i++)
            {
                yield return events[i];
            }
        }
    }
}