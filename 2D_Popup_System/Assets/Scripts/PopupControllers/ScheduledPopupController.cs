using PopupSystem.Data;
using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class ScheduledPopupController : BasicPopupController
    {
        [field: SerializeField]
        public SchedulePopupSetup CurrentSchedulePopupSetup { get; set; }
        
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
            SetTextReferences(TitleText, CurrentSchedulePopupSetup.Title, CurrentSchedulePopupSetup.MaxTitleLength);
            SetTextReferences(MessageText, CurrentSchedulePopupSetup.Message, CurrentSchedulePopupSetup.MaxMessageLength);
            SetTextReferences(ButtonLabelText, CurrentSchedulePopupSetup.ButtonLabel, CurrentSchedulePopupSetup.MaxButtonLabelLength);
        }
    }
}