// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/11/15 20:49:58
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC;
using MVC.Patterns;

namespace MVC.Core
{
    public class Controller : IController
    {
        Dictionary<string, Commond> commonds = new Dictionary<string, Commond>();

        public T RetrieveCommond<T>() where T : Commond
        {
            string name = typeof(T).Name;
            if (!HasCommond(name))
            {
                return null;
            }
            return (T)commonds[name];
        }

        public bool HasCommond(string name)
        {
            return commonds.ContainsKey(name);
        }

        public bool RegisterCommond(Commond commond)
        {
            if (!HasCommond(commond.Name))
            {
                commonds.Add(commond.Name, commond);
                return true;
            }
            return false;
        }

        public bool UnRegisterCommond(string name)
        {
            if (HasCommond(name))
            {
                commonds.Remove(name);
                return true;
            }
            return false;
        }

        public void Start()
        {
            foreach (Commond com in commonds.Values)
            {
                com.Start();
            }
        }
    }

}
