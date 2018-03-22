// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:02:20
// ========================================================
using System.Collections;
using System.Collections.Generic;

namespace MVC.Event
{
    /// <summary>
    /// eventData事件容器
    /// </summary>
    public class EventCollection:IEnumerable<EventData>
    {
        List<EventData> mEvents = new List<EventData>();

        public void Add(EventData data)
        {
            mEvents.Add(data);
            mEvents.Sort();
        }

        public void Remove(EventHandle handle)
        {
            for (int i = 0; i < mEvents.Count; i++)
            {
                if (mEvents[i].handle == handle)
                {
                    mEvents.RemoveAt(i);
                    break;
                }
            }
        }

        public int Count
        {
            get
            {
                return mEvents.Count;
            }
        }

        public void Clear()
        {
            mEvents.Clear();
        }

        public List<EventData> GetEventList()
        {
            return mEvents;
        }

        public IEnumerator<EventData> GetEnumerator()
        {
            for (int i = 0; i < mEvents.Count; i++)
            {
                yield return mEvents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < mEvents.Count; i++)
            {
                yield return mEvents[i];
            }
        }
    }
}
