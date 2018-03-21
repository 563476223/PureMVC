// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:12:44
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Event;

namespace MVC
{
    interface IEventListener
    {
        void AddEventListening(string type, EventHandle handle, int priority = 0);
        void RemoveEventListening(string type);
        void RemoveEventListening(string type, EventHandle handle);
    }
}
