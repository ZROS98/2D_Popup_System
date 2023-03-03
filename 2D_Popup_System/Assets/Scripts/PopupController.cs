using PopupSystem.Data;
using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class PopupController : BasicPopupController
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        private BasicPopupSetup CurrentBasicPopupSetup { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentMessageText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentButtonLabelText { get; set; }

        protected override void Start ()
        {
            base.Start();
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