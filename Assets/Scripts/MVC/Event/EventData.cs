using System;
// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:01:22
// ========================================================
using System.Collections;
using System.Collections.Generic;

namespace MVC.Event
{
    /// <summary>
    /// 一个事件数据的描述
    /// </summary>
    public class EventData : IComparable<EventData>
    {
        public int Type { get; set; }

        public int Priority { get; set; }

        public EventHandle handle { get; set; }

        public int CompareTo(EventData other)
        {
            if (Priority > other.Priority)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
