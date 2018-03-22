// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:00:41
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Event;

namespace MVC.Interface
{
    public interface IEventListener
    {
        void AddEventListener(int type,EventHandle handle,int priority = 0);
        void RemoveEventListener(int type);
        /// <summary>
        /// 移除指定事件，监听为Handle的type事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="handle"></param>
        void RemoveEventListener(int type, EventHandle handle);
    }
}

