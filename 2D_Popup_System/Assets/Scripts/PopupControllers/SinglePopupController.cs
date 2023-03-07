using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class SinglePopupController : BasicPopupController
    {
        
        [field: SerializeField]
        private TMP_Text TitleText { get; set; }
        [field: SerializeField]
        private TMP_Text MessageText { get; set; }
        [field: SerializeField]
        private TMP_Text ButtonLabelText { get; set; }

        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
        }

        private void SetReferences ()
        {
            SetTextReferences(TitleText, CurrentBasicPopupSetup.Title, CurrentBasicPopupSetup.MaxTitleLength);
            SetTextReferences(MessageText, CurrentBasicPopupSetup.Message, CurrentBasicPopupSetup.MaxMessageLength);
            SetTextReferences(ButtonLabelText, CurrentBasicPopupSetup.ButtonLabel, CurrentBasicPopupSetup.MaxButtonLabelLength);
        }
    }
}