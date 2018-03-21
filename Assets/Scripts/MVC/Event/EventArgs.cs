// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:13:59
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Event
{
    public class EventArgs
    {
        private object data;
        public void SetData(object data) { this.data = data; }

        public T GetData<T>()
        {
            return (T)data;
        }

        public object Sender {get;set;}
        public string Type {get;set;}

    }
}
