// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:01:50
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Event
{
    /// <summary>
    /// 一个接受数据的描述
    /// </summary>
    public class EventArgs
    {
        private object data;

        public int Type { set; get; }

        public object Sender { set; get; }

        public void SetData(object data)
        {
            this.data = data;
        }

        public T GetData<T>()
        {
            return (T)data;
        }
    }

}
