// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:11:35
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;
using MVC.Patterns;

namespace MVC.Core
{
    public class Model:IModel
    {
        private Dictionary<string, Proxy> mProxys = new Dictionary<string, Proxy>();

        public bool RegisterProxy(Patterns.Proxy mediator)
        {
            if (HasProxy(mediator.Name))
            {
                return false;
            }
            mProxys.Add(mediator.Name, mediator);
            return true;
        }

        public bool HasProxy(string name)
        {
            if (mProxys.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public T RetrieveProxy<T>() where T : Patterns.Proxy
        {
            string name = typeof(T).Name;
            if (HasProxy(name))
            {
                return (T)mProxys[name];
            }
            return default(T);
        }

        public bool UnRegisterProxy(string name)
        {
            if (HasProxy(name))
            {
                mProxys.Remove(name);
                return true;
            }
            return false;
        }

        public void Init()
        {
            foreach (Proxy proxy in mProxys.Values)
            {
                proxy.Init();
            }
        }
    }

}
