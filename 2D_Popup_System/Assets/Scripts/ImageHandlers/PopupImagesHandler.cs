using System;
using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class PopupImagesHandler : MonoBehaviour
    {
        [field: SerializeField]
        private BasicPopupSetup CurrentPopupSetup { get; set; }
        [field: SerializeField]
        private Image CurrentPopupBackgroundImage { get; set; }
        [field: SerializeField]
        private Image CurrentPopupButtonImage { get; set; }
        
        private SpriteCreator CurrentSpriteCreator { get; set; }

        protected virtual void Awake ()
        {
            SetReferences();
        }

        private void SetReferences()
        {
            CurrentSpriteCreator = new SpriteCreator(this);
            
            if (CurrentPopupSetup.BackgroundImageAddress != String.Empty)
            {
                SetImageReference(CurrentPopupSetup.BackgroundImageAddress, CurrentPopupBackgroundImage);
            }

            if (CurrentPopupSetup.ButtonImageAddress != String.Empty)
            {
                SetImageReference(CurrentPopupSetup.ButtonImageAddress, CurrentPopupButtonImage);
            }
        }
        
        private void SetImageReference (string imageAddress, Image popupImage)
        {
            CurrentSpriteCreator.GetImage(imageAddress);
            StartCoroutine(SetSpriteProcess(imageAddress, popupImage));
        }

        private IEnumerator SetSpriteProcess (string imageAddress, Image popupImage)
        {
            yield return new WaitUntil(() => CheckIfSpriteLoaded() == true);

            for (int i = 0; i < CurrentSpriteCreator.SpriteCollection.Count; i++)
            {
                if (CurrentSpriteCreator.SpriteCollection[i].name == imageAddress)
                {
                    popupImage.sprite = CurrentSpriteCreator.SpriteCollection[i];
                }
            }
        }
        
        private bool CheckIfSpriteLoaded ()
        {
            return CurrentSpriteCreator.CreatedSprite != null;
        }
    }
}