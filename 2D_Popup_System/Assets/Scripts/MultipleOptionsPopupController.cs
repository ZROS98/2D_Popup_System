using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PopupSystem.Data;
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
        private SpriteCreator CurrentSpriteCreator { get; set; }
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

        protected override void Awake ()
        {
            base.Awake();
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
                CurrentSpriteCreator.GetImage(CurrentPopupSetupWithMultipleOptions.ButtonImageAddress[i]);
            }

            StartCoroutine(SetSpritesProcess());
        }

        private IEnumerator SetSpritesProcess ()
        {
            yield return new WaitUntil(() => CheckIfAllSpritesAreLoaded() == true);

            CurrentSpriteCreator.SpriteCollection.OrderBy(x => x.name);

            for (int i = 0; i < CurrentSpriteCreator.SpriteCollection.Count; i++)
            {
                Sprite sprite = CurrentSpriteCreator.SpriteCollection[i];
                CurrentToggleImageCollection[i].sprite = sprite;
            }
        }

        private bool CheckIfAllSpritesAreLoaded ()
        {
            return CurrentSpriteCreator.SpriteCollection.Count == CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count;
        }
    }
}