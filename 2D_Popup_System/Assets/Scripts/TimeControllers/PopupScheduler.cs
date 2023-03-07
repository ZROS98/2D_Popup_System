using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class PopupScheduler : PopupSystemController
    {
        [field: SerializeField]
        private List<ScheduledPopupController> CurrentPopupCollection { get; set; }
        [field: SerializeField]
        private TMP_Text TimerText { get; set; }

        private List<PopupTimer> TimerCollection { get; set; } = new List<PopupTimer>();

        public void SchedulePopups ()
        {
            for (int i = 0; i < CurrentPopupCollection.Count; i++)
            {
                ScheduledPopupController scheduledPopupController = CurrentPopupCollection[i];
                PopupTimer timer = new PopupTimer(this, scheduledPopupController.CurrentSchedulePopupSetup.TimeToShowPopup);
                timer.StartTimer();
                TimerCollection.Add(timer);
            }

            ShowPopupTimer();
            AttachEvents();
        }

        protected virtual void OnDisable ()
        {
            DetachEvents();
        }

        private void ShowPopupTimer ()
        {
            TimerText.gameObject.SetActiveOptimized(true);
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

        private void UpdateTimerText (float passedTime)
        {
            TimerText.text = $"{ProjectConstants.TIMER_INFORMATION}{passedTime.ToString()}";
        }

        private void AttachEvents ()
        {
            foreach (PopupTimer popupTimer in TimerCollection)
            {
                popupTimer.OnTimerFinish += HandleTimerFinish;
                popupTimer.OnTimerTick += UpdateTimerText;
            }
        }

        private void DetachEvents ()
        {
            foreach (PopupTimer popupTimer in TimerCollection)
            {
                popupTimer.OnTimerFinish -= HandleTimerFinish;
                popupTimer.OnTimerTick -= UpdateTimerText;
            }
        }
    }
}