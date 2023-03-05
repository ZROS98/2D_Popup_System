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
            SetTextReferences(CurrentTitleText, CurrentSchedulePopupSetup.Title, CurrentSchedulePopupSetup.MaxTitleLength);
            SetTextReferences(CurrentMessageText, CurrentSchedulePopupSetup.Message, CurrentSchedulePopupSetup.MaxMessageLength);
            SetTextReferences(CurrentButtonLabelText, CurrentSchedulePopupSetup.ButtonLabel, CurrentSchedulePopupSetup.MaxButtonLabelLength);
        }
    }
}