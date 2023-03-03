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
        private TMP_Text CurrentTitleText { get; set; }
        [field: SerializeField]
        private List<Texture2D> CurrentTextureCollection { get; set; }
        [field: SerializeField]
        private List<Toggle> CurrentToggleCollection { get; set; }
        
        [field: SerializeField]
        private ImageHandler CurrentImageHandler { get; set; }
        
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