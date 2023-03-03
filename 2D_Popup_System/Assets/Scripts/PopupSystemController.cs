using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem
{
    public class PopupSystemController : MonoBehaviour
    {
        [field: SerializeField]
        private List<PopupController> PopupCollection { get; set; }

        private Queue<PopupController> PopupQueue { get; set; } = new Queue<PopupController>();
        private PopupController CurrentActivePopup { get; set; }

        public void ShowPopup ()
        {
            AddPopupsToQueue();
            CloseActivePopup();
            ManageCurrentActivePopup();
        }

        public void ShowNextPopup ()
        {
            CloseActivePopup();
            ManageCurrentActivePopup();
        }

        public void CloseActivePopup ()
        {
            if (CurrentActivePopup != null)
            {
                CurrentActivePopup.gameObject.SetActiveOptimized(false);
            }
        }

        private void ManageCurrentActivePopup ()
        {
            CurrentActivePopup = PopupQueue.Peek();
            PopupQueue.Dequeue();
            CurrentActivePopup.gameObject.SetActiveOptimized(true);
        }

        private void AddPopupsToQueue ()
        {
            foreach (PopupController popupController in PopupCollection)
            {
                PopupQueue.Enqueue(popupController);
            }
        }
    }
}