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

        protected virtual void Awake ()
        {
            for (int i = 0; i < CurrentPopupCollection.Count; i++)
            {
                ScheduledPopupController scheduledPopupController = CurrentPopupCollection[i];
                PopupTimer timer = new PopupTimer(this, scheduledPopupController.CurrentSchedulePopupSetup.TimeToShowPopup);
                timer.StartTimer();
                TimerCollection.Add(timer);
            }
        }
        
        protected virtual void OnEnable ()
        {
            AttachEvents();
        }

        protected virtual void OnDisable ()
        {
            DetachEvents();
        }

        private void HandleTimerFinish ()
        {
            foreach (ScheduledPopupController scheduledPopupController in CurrentPopupCollection)
            {
                CurrentBasicPopupQueueVariable.CurrentValue.Enqueue(scheduledPopupController);

                if (CurrentBasicPopupQueueVariable.CurrentValue.Peek() == scheduledPopupController)
                {
                    CurrentBasicPopupQueueVariable.CurrentValue.Peek().gameObject.SetActiveOptimized(true);
                    CurrentBasicPopupQueueVariable.CurrentValue.Dequeue();
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