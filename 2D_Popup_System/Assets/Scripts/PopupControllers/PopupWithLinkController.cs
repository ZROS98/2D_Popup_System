using PopupSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        [field: SerializeField]
        private TMP_Text OpenLinkButtonLabelText { get; set; }
        [field: SerializeField]
        private Button OpenLinkButton { get; set; }

        protected override void Awake ()
        {
            base.Awake();
            SetReferences();
            AddListenerToButton();
        }

        private void SetReferences ()
        {
            SetTextReferences(TitleText, CurrentPopupWithLinkSetup.Title, CurrentPopupWithLinkSetup.MaxTitleLength);
            SetTextReferences(MessageText, CurrentPopupWithLinkSetup.Message, CurrentPopupWithLinkSetup.MaxMessageLength);
            SetTextReferences(ButtonLabelText, CurrentPopupWithLinkSetup.ButtonLabel, CurrentPopupWithLinkSetup.MaxButtonLabelLength);
            SetTextReferences(OpenLinkButtonLabelText, CurrentPopupWithLinkSetup.OpenLinkLabelButton, CurrentPopupWithLinkSetup.MaxButtonLabelLength);
        }
        
        private void AddListenerToButton ()
        {
            OpenLinkButton.onClick.AddListener(OpenCurrentLink);
        }

        private void OpenCurrentLink ()
        {
            Application.OpenURL(CurrentPopupWithLinkSetup.LinkAddress);
        }
    }
}