// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:32:36
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Patterns;

public class EffectCommond : Commond
{
    public const string NAME = "EffectCommond";
    BuffProxy mBuffProxy;
    public EffectCommond()
        : base(NAME)
    {

    }
    public override void Init()
    {
        mBuffProxy = RetrieveProxy<BuffProxy>();
  
    }
}
