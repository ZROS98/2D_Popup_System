using PopupSystem.Data;
using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class PopupWithLinkController : BasicPopupController
    {
        [field: SerializeField]
        private PopupWithLinkSetup CurrentPopupWithLinkSetup { get; set; }
        [field: SerializeField]
        private TMP_Text TitleText { get; set; }
        [field: SerializeField]
        private TMP_Text MessageText { get; set; }
        [field: SerializeField]
        private TMP_Text ButtonLabelText { get; set; }

        public void OpenCurrentLink ()
        {
            Application.OpenURL(CurrentPopupWithLinkSetup.LinkAddress);
        }
        
        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
        }

        private void SetReferences ()
        {
            SetTextReferences(TitleText, CurrentPopupWithLinkSetup.Title, CurrentPopupWithLinkSetup.MaxTitleLength);
            SetTextReferences(MessageText, CurrentPopupWithLinkSetup.Message, CurrentPopupWithLinkSetup.MaxMessageLength);
            SetTextReferences(ButtonLabelText, CurrentPopupWithLinkSetup.ButtonLabel, CurrentPopupWithLinkSetup.MaxButtonLabelLength);
        }
    }
}