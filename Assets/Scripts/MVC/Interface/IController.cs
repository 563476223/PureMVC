// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:45:41
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

namespace MVC
{
    interface IController
    {
        T RetrieveCommond<T>() where T : Commond;
        bool HasCommond(string name);
        bool RegisterCommond(Commond commond);
        bool UnRegisterCommond(string name);
        void Start();
    }
}
