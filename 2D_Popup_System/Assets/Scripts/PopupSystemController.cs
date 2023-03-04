using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem
{
    public class PopupSystemController : MonoBehaviour
    {
        [field: SerializeField]
        private List<BasicPopupController> PopupCollection { get; set; }
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }

        private Queue<BasicPopupController> PopupQueue { get; set; } = new Queue<BasicPopupController>();

        public void ShowPopup ()
        {
            AddPopupsToQueue();
            HandleFirstPopupInQueue();
        }

        private void AddPopupsToQueue ()
        {
            foreach (BasicPopupController popupController in PopupCollection)
            {
                PopupQueue.Enqueue(popupController);
            }

            CurrentBasicPopupQueueVariable.CurrentValue = PopupQueue;
        }

        private void HandleFirstPopupInQueue ()
        {
            BasicPopupController currentPopup = PopupQueue.Peek();
            PopupQueue.Dequeue();
            currentPopup.gameObject.SetActiveOptimized(true);
        }
    }
}