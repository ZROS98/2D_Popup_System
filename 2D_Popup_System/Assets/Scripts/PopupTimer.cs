using System;
using System.Collections;
using UnityEngine;

namespace PopupSystem
{
    public class PopupTimer
    {
        public event Action OnTimerFinish = delegate { };
        public event Action<float> OnTimerTick = delegate { };

        private int TimeToShowPopup { get; set; }
        private float TimeRemaining { get; set; }

        private Coroutine TimerProcess { get; set; }
        private WaitForSeconds TimerWait { get; set; }
        private MonoBehaviour CoroutineController { get; set; }

        public PopupTimer (MonoBehaviour coroutineController, int timeToShowPopup)
        {
            CoroutineController = coroutineController;
            TimerWait = new WaitForSeconds(1);

            SetupTimer(timeToShowPopup);
        }

        public void StartTimer ()
        {
            StopTimer();
            TimerProcess = CoroutineController.StartCoroutine(TickProcess());
        }

        public void StopTimer ()
        {
            if (TimerProcess != null)
            {
                CoroutineController.StopCoroutine(TimerProcess);
                TimerProcess = null;
            }
        }

        public void ResetTimer (int timeToShowPopup)
        {
            SetupTimer(timeToShowPopup);
        }

        private void SetupTimer (int duration)
        {
            TimeToShowPopup = duration;
            TimeRemaining = duration;
        }

        private IEnumerator TickProcess ()
        {
            while (TimeRemaining > 0)
            {
                yield return TimerWait;

                TimeRemaining--;
                float passedTime = TimeToShowPopup - TimeRemaining;
                OnTimerTick.Invoke(passedTime);
            }

            OnTimerFinish.Invoke();
            StopTimer();
        }
    }
}