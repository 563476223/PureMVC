// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:24:35
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;

namespace MVC.Patterns
{
    public class Proxy:IEventDispatcher
    {
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
        }

        public Proxy(string name)
        {
            this.name = name;   
        }

        public virtual void Init()
        {

        }

        public void DispatchEvent(int type)
        {
            DispatchEvent(type, null, null);
        }

        public void DispatchEvent(int type, object data)
        {
            DispatchEvent(type, data,null);
        }

        public void DispatchEvent(int type, object data, object sender)
        {
            Facade.Instance.DispatchEvent(type, data, sender);
        }

        /// <summary>
        /// 只负责数据交换，不能持有UI的引用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T RetrieveProxy<T>() where T : Proxy
        {
            return Facade.Instance.RetrieveProxy<T>();
        }
    }
}

