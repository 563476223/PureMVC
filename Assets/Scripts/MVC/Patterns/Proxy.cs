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
    }
}

