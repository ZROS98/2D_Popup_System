using PopupSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class PopupController : BasicPopupController
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        private BasicPopupQueueVariable CurrentBasicPopupQueueVariable { get; set; }
        [field: SerializeField]
        private BasicPopupSetup CurrentBasicPopupSetup { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentMessageText { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentButtonLabelText { get; set; }
        [field: SerializeField]
        private Button CurrentButton { get; set; }

        protected override void Start ()
        {
            base.Start();
            SetReferences();
            AddListenerToButton();
        }

        private void SetReferences ()
        {
            SetTextReferences(CurrentTitleText, CurrentBasicPopupSetup.Title, CurrentBasicPopupSetup.MaxTitleLength);
            SetTextReferences(CurrentMessageText, CurrentBasicPopupSetup.Message, CurrentBasicPopupSetup.MaxMessageLength);
            SetTextReferences(CurrentButtonLabelText, CurrentBasicPopupSetup.ButtonLabel, CurrentBasicPopupSetup.MaxButtonLabelLength);
        }

        private void AddListenerToButton ()
        {
            CurrentButton.onClick.AddListener(HandlePopup);
        }

        private void HandlePopup ()
        {
            gameObject.SetActiveOptimized(false);

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
            PopupController currentPopup = CurrentBasicPopupQueueVariable.CurrentValue.Peek();
            CurrentBasicPopupQueueVariable.CurrentValue.Dequeue();
            currentPopup.gameObject.SetActiveOptimized(true);
        }
    }
}