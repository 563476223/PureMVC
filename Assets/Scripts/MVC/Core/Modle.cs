// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:49:52
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC;
using MVC.Patterns;

namespace MVC.Core
{
    public class Modle:IModle
    {
        private Dictionary<string, Proxy> proxyDic = new Dictionary<string, Proxy>();
        public bool UnRegisterProxy(string name)
        {
            if (HasProxy(name))
            {
                proxyDic.Remove(name);
                return true;
            }
            return false;
        }

        public bool HasProxy(string name)
        {
            return proxyDic.ContainsKey(name);
        }

        public T RetrieveProxy<T>() where T : Patterns.Proxy
        {
            string name = typeof(T).Name;
            if (HasProxy(name))
            {
                return (T)proxyDic[name];
            }
            return null;
        }

        public bool RegisterProxy(Patterns.Proxy proxy)
        {
            if (!HasProxy(proxy.Name))
            {
                proxyDic.Add(proxy.Name, proxy);
                return true;
            }
            return false;
        }

        public void Start()
        {
            foreach (Patterns.Proxy pr in proxyDic.Values)
            {
                pr.Start();
            }
        }
    }
}
