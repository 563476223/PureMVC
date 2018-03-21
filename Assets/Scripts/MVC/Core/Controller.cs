// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:11:58
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;
using MVC.Patterns;

namespace MVC.Core
{
    public class Controller:IController
    {
        private Dictionary<string, Commond> mCommonds = new Dictionary<string, Commond>();
        public bool RegisterCommond(Patterns.Commond commond)
        {
            if (HasCommond(commond.Name))
            {
                return false;
            }
            mCommonds.Add(commond.Name,commond);
            return true;
        }

        public bool HasCommond(string name)
        {
            if (mCommonds.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public T RetrieveCommond<T>() where T : Patterns.Commond
        {
            string name = typeof(T).Name;
            if (HasCommond(name))
            {
                return (T)mCommonds[name];
            }
            return default(T);
        }

        public bool UnRegisterCommond(string name)
        {
            if (HasCommond(name))
            {
                mCommonds.Remove(name);
                return true;
            }
            return false;
        }

        public void Init()
        {
            foreach (Commond commond in mCommonds.Values)
            {
                commond.Init();
            }
        }
    }
}
