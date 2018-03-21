// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:14:11
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVC.Scheduler;

namespace MVC
{
    interface IScheduler
    {
        void DelayCall(float interval,SchedulerCallBack callback);
        void RepeatCall(float interval, SchedulerCallBack callback);
        void RepeatCall(float interval, int times, SchedulerCallBack callback);
        void RepeatCall(float delaytime, float interval, int times, SchedulerCallBack callback);
        void CancleCall(SchedulerCallBack callback);
    }
}
