using System.Collections.Generic;
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
        private List<Texture2D> CurrentTextureCollection { get; set; }
        [field: SerializeField]
        private List<Toggle> CurrentToggleCollection { get; set; }
        
        [field: SerializeField]
        private ImageHandler CurrentImageHandler { get; set; }
        private List<bool> IsToggleOnCollection { get; set; } = new List<bool>();

        public void ManagePopupPanel (bool isActive)
        {
            PopupPanel.SetActiveOptimized(isActive);
        }
        
        public void HandlePopupMenu ()
        {
            IsToggleOnCollection.Add(true);
            
            if (IsToggleOnCollection.Count == CurrentToggleCollection.Count)
            {
                ManagePopupPanel(false);
                IsToggleOnCollection.Clear();

                foreach (Toggle toggle in CurrentToggleCollection)
                {
                    toggle.isOn = false;
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

            CurrentTextureCollection = CurrentImageHandler.CurrentTexture2DCollection;
        }
    }
}