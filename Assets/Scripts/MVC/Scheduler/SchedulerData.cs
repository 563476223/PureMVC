// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2017/12/12 16:15:18
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Scheduler
{
    public class SchedulerData
    {
        private bool isStart = false;
        private float duration = 0;
        private bool isUsing = false;

        public float Elasepe = 0;
        public float Times = 0;
        public float interval = 0;
        public float Delay = 0;

        public SchedulerCallBack callback;

        public bool IsDone
        {
            get
            {
                return Times <= 0;
            }
        }

        public bool Update(float delta,out float deltatime)
        {
            Elasepe += delta;
            duration += delta;
            deltatime = 0;
            if (!isStart)
            {
                if (Elasepe >= Delay)
                {
                    Elasepe -= Delay;
                    if (Times >= 1)
                    {
                        duration = Elasepe;
                    }
                    isStart = true;
                }
                else
                {
                    return false;
                }
            }

            if (Elasepe >= interval)
            {
                --Times;
                deltatime = duration;
                duration = 0;
                if (interval == 0)
                {
                    Elasepe = 0;
                }
                else
                {
                    Elasepe -= interval;
                }
                return true;
            }
            return false;
        }

        public bool IsUsing
        {
            get
            {
                return isUsing;
            }
            set
            {
                isUsing = value;
                if (isUsing)
                {
                    isStart = false;
                }
            }
        }
    }


}
