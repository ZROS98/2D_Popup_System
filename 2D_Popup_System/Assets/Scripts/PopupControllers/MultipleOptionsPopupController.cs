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
        private TMP_Text TitleText { get; set; }
        [field: SerializeField]
        private List<Toggle> ToggleCollection { get; set; }
        private List<bool> IsToggleOnCollection { get; set; } = new List<bool>();
        private bool IsPopupReadyToClose { get; set; }
        
        public void HandlePopupMenu (Toggle currentToggle)
        {
            currentToggle.interactable = false;
            IsToggleOnCollection.Add(true);

            if (IsToggleOnCollection.Count == ToggleCollection.Count)
            {
                IsPopupReadyToClose = true;
                CurrentButton.interactable = true;
                IsToggleOnCollection.Clear();
            }
        }
        
        public void ClosePopup ()
        {
            if (IsPopupReadyToClose)
            {
                foreach (Toggle toggle in ToggleCollection)
                {
                    toggle.isOn = false;
                    toggle.interactable = true;
                }
                
                IsPopupReadyToClose = false;
                CurrentButton.interactable = false;
            }
        }

        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
        }

        private void SetReferences ()
        {
            SetTextReferences(TitleText, CurrentPopupSetupWithMultipleOptions.Title, CurrentPopupSetupWithMultipleOptions.MaxTitleLength);
        }
    }
}