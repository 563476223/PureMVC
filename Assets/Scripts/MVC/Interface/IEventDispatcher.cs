// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:12:54
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    interface IEventDispatcher
    {
        void DispatcherEvent(string type);
        void DispatcherEvent(string type, object data);
        void DispatcherEvent(string type, object data, object sender);
    }
}

