// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:15:46
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Patterns;

namespace MVC.Interface
{
    public interface IModel
    {
        bool RegisterProxy(Proxy proxy);
        bool HasProxy(string name);
        T RetrieveProxy<T>() where T : Proxy;
        bool UnRegisterProxy(string name);
        void Init();
    }
}
