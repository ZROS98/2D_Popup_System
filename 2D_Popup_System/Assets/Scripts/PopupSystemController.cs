using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem
{
    public class PopupSystemController : MonoBehaviour
    {
        [field: SerializeField]
        private List<PopupController> PopupCollection { get; set; }
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }

        private Queue<PopupController> PopupQueue { get; set; } = new Queue<PopupController>();

        public void ShowPopup ()
        {
            AddPopupsToQueue();
            HandleFirstPopupInQueue();
        }

        private void AddPopupsToQueue ()
        {
            foreach (PopupController popupController in PopupCollection)
            {
                PopupQueue.Enqueue(popupController);
            }

            CurrentBasicPopupQueueVariable.CurrentValue = PopupQueue;
        }

        private void HandleFirstPopupInQueue ()
        {
            PopupController currentPopup = PopupQueue.Peek();
            PopupQueue.Dequeue();
            currentPopup.gameObject.SetActiveOptimized(true);
        }
    }
}