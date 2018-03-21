// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:15:27
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Scheduler
{
    public class SchedulerRegister:IScheduler
    {

        public void DelayCall(float interval, SchedulerCallBack callback)
        {
            Scheduler.Instance.DelayCall(interval, callback);
        }

        public void RepeatCall(float interval, SchedulerCallBack callback)
        {
            Scheduler.Instance.RepeatCall(interval, callback);
        }

        public void RepeatCall(float interval, int times, SchedulerCallBack callback)
        {
            Scheduler.Instance.RepeatCall(interval, times, callback);
        }

        public void RepeatCall(float delaytime, float interval, int times, SchedulerCallBack callback)
        {
            Scheduler.Instance.RepeatCall(delaytime, interval, times, callback);
        }

        public void CancleCall(SchedulerCallBack callback)
        {
            Scheduler.Instance.CancleCall(callback);
        }

        public void RepeatCallForever(float interval, SchedulerCallBack callback)
        {
            Scheduler.Instance.RepeatCall(interval, int.MaxValue, callback);
        }
        public void RepeatCallWithDelay(float delay, float interval, int times, SchedulerCallBack callback)
        {
            Scheduler.Instance.RepeatCall(delay, interval, times, callback);
        }

    }
}

