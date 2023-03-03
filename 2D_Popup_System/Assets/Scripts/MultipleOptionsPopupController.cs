using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class MultipleOptionsPopupController : BasicPopupController
    {
        [field: Header(ProjectConstants.HEADER_REFERENCES)]
        [field: SerializeField]
        private PopupSetupWithMultipleOptions CurrentPopupSetupWithMultipleOptions { get; set; }
        [field: SerializeField]
        private GameObject PopupPanel { get; set; }
        [field: SerializeField]
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private List<Image> CurrentToggleImageCollection { get; set; } = new List<Image>();
        [field: SerializeField]
        private List<Toggle> CurrentToggleCollection { get; set; }

        [field: SerializeField]
        private ImageHandler CurrentImageHandler { get; set; }
        private List<bool> IsToggleOnCollection { get; set; } = new List<bool>();

        public void ManagePopupPanel (bool isActive)
        {
            PopupPanel.SetActiveOptimized(isActive);
        }

        public void HandlePopupMenu (Toggle currentToggle)
        {
            currentToggle.interactable = false;
            IsToggleOnCollection.Add(true);

            if (IsToggleOnCollection.Count == CurrentToggleCollection.Count)
            {
                ManagePopupPanel(false);
                IsToggleOnCollection.Clear();

                foreach (Toggle toggle in CurrentToggleCollection)
                {
                    toggle.isOn = false;
                    toggle.interactable = true;
                }
            }
        }

        protected override void Start ()
        {
            base.Start();
            SetReferences();
        }

        private void SetReferences ()
        {
            SetTextReferences(CurrentTitleText, CurrentPopupSetupWithMultipleOptions.Title, CurrentPopupSetupWithMultipleOptions.MaxTitleLength);
            SetImageReferences();
        }

        private void SetImageReferences ()
        {
            for (int i = 0; i < CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count; i++)
            {
                CurrentImageHandler.GetImage(CurrentPopupSetupWithMultipleOptions.ButtonImageAddress[i]);
            }

            StartCoroutine(SetSpritesProcess());
        }

        private IEnumerator SetSpritesProcess ()
        {
            yield return new WaitUntil(() => CheckIfAllSpritesAreLoaded() == true);

            CurrentImageHandler.SpriteCollection.OrderBy(x => x.name);

            for (int i = 0; i < CurrentImageHandler.SpriteCollection.Count; i++)
            {
                Sprite sprite = CurrentImageHandler.SpriteCollection[i];
                CurrentToggleImageCollection[i].sprite = sprite;
            }
        }

        private bool CheckIfAllSpritesAreLoaded ()
        {
            return CurrentImageHandler.SpriteCollection.Count == CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count;
        }
    }
}