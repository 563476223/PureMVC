// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:14:46
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Scheduler
{
    public delegate void SchedulerCallBack(float delta);
    public class Scheduler:IScheduler
    {
        private Queue<SchedulerData> cacheScheduleData = new Queue<SchedulerData>();
        private Dictionary<SchedulerCallBack, SchedulerData> scheduleDic = new Dictionary<SchedulerCallBack, SchedulerData>();
        private List<SchedulerData> updateSchedule = new List<SchedulerData>();
        private static Scheduler instance;
        public static Scheduler Instance
        {
            get
            {
                if (instance == null) 
                {
                    instance = new Scheduler();
                }
                return instance;
            }
        }

        public void Update(float delta)
        {
            updateSchedule.Clear();
            foreach (KeyValuePair<SchedulerCallBack, SchedulerData> sc in scheduleDic)
            {
                updateSchedule.Add(sc.Value);
            }

            foreach (SchedulerData sc in updateSchedule)
            {
                float deltatime = 0;
                bool result = sc.Update(delta,out deltatime);

                if (!sc.IsDone)
                {
                    continue;
                }

                if (result)
                {
                    sc.callback(deltatime);
                }
              
            }
        }

        public void DelayCall(float interval, SchedulerCallBack callback)
        {
            RepeatCall(interval, 0, 1, callback);
        }

        public void RepeatCall(float interval, SchedulerCallBack callback)
        {
            RepeatCall(0, interval, int.MaxValue, callback);
        }

        public void RepeatCall(float interval, int times, SchedulerCallBack callback)
        {
            RepeatCall(0, interval, times, callback);
        }

        public void RepeatCall(float delaytime, float interval, int times, SchedulerCallBack callback)
        {
            SchedulerData scheduledata = GetUnUseSchedule();
            scheduledata.interval = interval;
            scheduledata.Times = times;
            scheduledata.Delay = delaytime;
            scheduledata.callback = callback;
            scheduleDic.Add(callback, scheduledata);
        }

        public void CancleCall(SchedulerCallBack callback)
        {
            SchedulerData scheduleData;
            if (scheduleDic.TryGetValue(callback,out scheduleData))
            {
                if (scheduleDic.Count == 0)
                {
                    scheduleDic.Clear();
                }
                scheduleData.IsUsing = false;
                cacheScheduleData.Enqueue(scheduleData);
            }
        }

        private SchedulerData GetUnUseSchedule()
        {
            SchedulerData scheduledata = null;
            if (cacheScheduleData.Count == 0)
            {
                scheduledata = new SchedulerData();
            }
            else
                scheduledata = cacheScheduleData.Dequeue();
            scheduledata.IsUsing = true;
            return scheduledata;
        }

        public void RepeatCallForever(float interval, SchedulerCallBack callback)
        {
            RepeatCall(interval, int.MaxValue, callback);
        }
        public void RepeatCallWithDelay(float delay, float interval, int times, SchedulerCallBack callback)
        {
            RepeatCall(delay, interval, times, callback);
        }
    }
}

