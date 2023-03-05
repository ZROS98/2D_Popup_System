using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem
{
    public class PopupScheduler : MonoBehaviour
    {
        [field: SerializeField]
        private List<ScheduledPopupController> CurrentPopupCollection { get; set; }
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }

        private List<PopupTimer> TimerCollection { get; set; } = new List<PopupTimer>();
        
        public void SchedulePopups()
        {
            for (int i = 0; i < CurrentPopupCollection.Count; i++)
            {
                ScheduledPopupController scheduledPopupController = CurrentPopupCollection[i];
                PopupTimer timer = new PopupTimer(this, scheduledPopupController.CurrentSchedulePopupSetup.TimeToShowPopup);
                timer.StartTimer();
                TimerCollection.Add(timer);
            }
            
            AttachEvents();
        }

        protected virtual void OnDisable ()
        {
            DetachEvents();
        }

        private void HandleTimerFinish (int timeToShowPopup)
        {
            for (int i = 0; i < CurrentPopupCollection.Count; i++)
            {
                if (CurrentPopupCollection[i].CurrentSchedulePopupSetup.TimeToShowPopup == timeToShowPopup)
                {
                    CurrentBasicPopupQueueVariable.CurrentValue.Enqueue(CurrentPopupCollection[i]);

                    if (CurrentBasicPopupQueueVariable.CurrentValue.Peek() == CurrentPopupCollection[i])
                    {
                        CurrentBasicPopupQueueVariable.CurrentValue.Peek().gameObject.SetActiveOptimized(true);
                    }
                }
            }
        }

        private void AttachEvents ()
        {
            foreach (PopupTimer popupTimer in TimerCollection)
            {
                popupTimer.OnTimerFinish += HandleTimerFinish;
            }
        }

        private void DetachEvents ()
        {
            foreach (PopupTimer popupTimer in TimerCollection)
            {
                popupTimer.OnTimerFinish -= HandleTimerFinish;
            }
        }
    }
}