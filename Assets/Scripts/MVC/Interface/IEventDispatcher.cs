// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 10:00:20
// ========================================================
using System.Collections;
using System.Collections.Generic;

namespace MVC.Interface
{
    public interface IEventDispatcher
    {
        void DispatchEvent(int type);
        void DispatchEvent(int type,object data);
        void DispatchEvent(int type,object data,object sender);
    }
}

