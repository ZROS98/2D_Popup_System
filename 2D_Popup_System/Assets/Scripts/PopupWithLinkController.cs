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
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentMessageText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentButtonLabelText { get; set; }
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
            SetTextReferences(CurrentTitleText, CurrentPopupWithLinkSetup.Title, CurrentPopupWithLinkSetup.MaxTitleLength);
            SetTextReferences(CurrentMessageText, CurrentPopupWithLinkSetup.Message, CurrentPopupWithLinkSetup.MaxMessageLength);
            SetTextReferences(CurrentButtonLabelText, CurrentPopupWithLinkSetup.ButtonLabel, CurrentPopupWithLinkSetup.MaxButtonLabelLength);
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