using PopupSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class BasicPopupController : MonoBehaviour
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        public BasicPopupSetup CurrentBasicPopupSetup { get; set; }
        [field: SerializeField]
        public Image BackgroundImage { get; set; }
        [field: SerializeField]
        public Image ButtonImage { get; set; }
        [field: SerializeField]
        protected Button CurrentButton { get; set; }
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }

        public void HandlePopup ()
        {
            CurrentBasicPopupQueueVariable.CurrentValue.Dequeue().gameObject.SetActiveOptimized(false);

            if (IsThereNextPopupInQueue())
            {
                ShowNextPopup();
            }
        }
        
        protected virtual void Awake ()
        {
        }

        protected void SetTextReferences (TMP_Text tmpText, string targetText, int maxTextLength)
        {
            tmpText.text = GetProperTextLength(targetText, maxTextLength);
        }

        private string GetProperTextLength (string targetText, int maxTextLenght)
        {
            return targetText.Length > maxTextLenght ? targetText.Substring(0, maxTextLenght) : targetText;
        }

        private bool IsThereNextPopupInQueue ()
        {
            return CurrentBasicPopupQueueVariable.CurrentValue.Count > 0;
        }

        private void ShowNextPopup ()
        {
            BasicPopupController currentPopup = CurrentBasicPopupQueueVariable.CurrentValue.Peek();
            currentPopup.gameObject.SetActiveOptimized(true);
        }
    }
}