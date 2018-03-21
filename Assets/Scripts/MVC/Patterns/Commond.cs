// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/21 15:24:04
// ========================================================
using System.Collections;
using System.Collections.Generic;

namespace MVC.Patterns
{
    public class Commond
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
        
    }
}
