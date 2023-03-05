using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class BasicPopupController : MonoBehaviour
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        protected Button CurrentButton { get; set; }
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }

        protected virtual void Awake ()
        {
            AddListenerToButton();
        }
        
        protected virtual void OnEnable ()
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
        
        private void AddListenerToButton ()
        {
            CurrentButton.onClick.AddListener(HandlePopup);
        }

        private void HandlePopup ()
        {
            CurrentBasicPopupQueueVariable.CurrentValue.Dequeue().gameObject.SetActiveOptimized(false);

            if (IsThereNextPopupInQueue() == true)
            {
                ShowNextPopup();
            }
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