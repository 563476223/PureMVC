// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:45:20
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

namespace MVC
{
    interface IModle
    {
        bool UnRegisterProxy(string name);
        bool HasProxy(string name);
        T RetrieveProxy<T>() where T : Proxy;
        bool RegisterProxy(Proxy proxy);
        void Start();
    }
}
