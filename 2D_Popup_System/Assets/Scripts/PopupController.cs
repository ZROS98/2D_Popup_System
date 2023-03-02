using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class PopupController : MonoBehaviour
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        private PopupSetup CurrentPopupSetup { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentMessageText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentButtonLableText { get; set; }

        protected virtual void Start ()
        {
            SetReferences();
        }

        private void SetReferences ()
        {
            CurrentTitleText.text = GetProperTextLength(CurrentPopupSetup.Title, CurrentPopupSetup.MaxTitleLength);
            CurrentMessageText.text = GetProperTextLength(CurrentPopupSetup.Message, CurrentPopupSetup.MaxMessageLength);
            CurrentButtonLableText.text = GetProperTextLength(CurrentPopupSetup.ButtonLable, CurrentPopupSetup.MaxButtonLableLength);
        }

        private string GetProperTextLength (string targetText, int maxTextLenght)
        {
            return targetText.Length > maxTextLenght ? targetText.Substring(0, maxTextLenght) : targetText;
        }
    }
}