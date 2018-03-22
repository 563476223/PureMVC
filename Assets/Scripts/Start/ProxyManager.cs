// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:26:24
// ========================================================
using System.Collections;
using System.Collections.Generic;
using MVC.Interface;

public class ProxyManager
{
    IModel mModle = null;
    public ProxyManager(IModel modle)
    {
        mModle = modle;
    }

    public void Register()
    {
        mModle.RegisterProxy(new EffectProxy());
        mModle.RegisterProxy(new BuffProxy());
    
    }
}
