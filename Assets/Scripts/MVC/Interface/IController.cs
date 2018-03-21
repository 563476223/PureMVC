// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:15:18
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Patterns;
namespace MVC.Interface
{
    public interface IController
    {
        bool RegisterCommond(Commond commond);
        bool HasCommond(string name);
        T RetrieveCommond<T>() where T : Commond;
        bool UnRegisterCommond(string name);
        void Init();
    }

}
