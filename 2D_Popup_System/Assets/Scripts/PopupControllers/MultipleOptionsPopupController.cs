using System.Collections.Generic;
using PopupSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class MultipleOptionsPopupController : BasicPopupController
    {
        [field: SerializeField]
        private PopupSetupWithMultipleOptions CurrentPopupSetupWithMultipleOptions { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private List<Toggle> CurrentToggleCollection { get; set; }
        private List<bool> IsToggleOnCollection { get; set; } = new List<bool>();
        private bool IsPopupReadyToClose { get; set; }
        
        public void HandlePopupMenu (Toggle currentToggle)
        {
            currentToggle.interactable = false;
            IsToggleOnCollection.Add(true);

            if (IsToggleOnCollection.Count == CurrentToggleCollection.Count)
            {
                IsPopupReadyToClose = true;
                CurrentButton.interactable = true;
                IsToggleOnCollection.Clear();
            }
        }

        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
            AddListenerToButton();
        }

        private void SetReferences ()
        {
            SetTextReferences(CurrentTitleText, CurrentPopupSetupWithMultipleOptions.Title, CurrentPopupSetupWithMultipleOptions.MaxTitleLength);
        }
        
        private void AddListenerToButton ()
        {
            CurrentButton.onClick.AddListener(ClosePopup);
        }

        private void ClosePopup ()
        {
            if (IsPopupReadyToClose)
            {
                foreach (Toggle toggle in CurrentToggleCollection)
                {
                    toggle.isOn = false;
                    toggle.interactable = true;
                }
                
                IsPopupReadyToClose = false;
                CurrentButton.interactable = false;
            }
        }
    }
}