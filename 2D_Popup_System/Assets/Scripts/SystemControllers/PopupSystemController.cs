using System.Collections.Generic;
using PopupSystem.ImageHandling;
using UnityEngine;

namespace PopupSystem
{
    public class PopupSystemController : MonoBehaviour
    {
        [field: SerializeField]
        protected BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }
        [field: SerializeField]
        private List<BasicPopupController> PopupCollection { get; set; }

        protected virtual void Awake ()
        {
            foreach (BasicPopupController basicPopupController in PopupCollection)
            {
                PopupImagesHandler popupImagesHandler = new PopupImagesHandler(this, basicPopupController);
                popupImagesHandler.SetReferences();
            }
        }

        public void ShowPopup ()
        {
            AddPopupsToQueue();
            HandleFirstPopupInQueue();
        }

        private void AddPopupsToQueue ()
        {
            foreach (BasicPopupController popupController in PopupCollection)
            {
                CurrentBasicPopupQueueVariable.CurrentValue.Enqueue(popupController);
            }
        }

        private void HandleFirstPopupInQueue ()
        {
            BasicPopupController currentPopup = CurrentBasicPopupQueueVariable.CurrentValue.Peek();
            currentPopup.gameObject.SetActiveOptimized(true);
        }
    }
}