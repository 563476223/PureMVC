using System;
// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:13:47
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Event
{
    public class EventData : IComparable<EventData>
    {
        public string Type {get;set;}
        public EventHandle handle{get;set;}
        public int Priority {get;set;}
        public int CompareTo(EventData other)
        {
            if (Priority > other.Priority)
                return -1;
            else
                return 1;
        }
    }
}

