using PopupSystem.Data;
using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class SinglePopupController : BasicPopupController
    {
        
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentMessageText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentButtonLabelText { get; set; }

        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
        }

        private void SetReferences ()
        {
            SetTextReferences(CurrentTitleText, CurrentBasicPopupSetup.Title, CurrentBasicPopupSetup.MaxTitleLength);
            SetTextReferences(CurrentMessageText, CurrentBasicPopupSetup.Message, CurrentBasicPopupSetup.MaxMessageLength);
            SetTextReferences(CurrentButtonLabelText, CurrentBasicPopupSetup.ButtonLabel, CurrentBasicPopupSetup.MaxButtonLabelLength);
        }
    }
}