using System;
using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class PopupImagesHandler
    {
        private BasicPopupSetup CurrentPopupSetup { get; set; }
        private Image CurrentPopupBackgroundImage { get; set; }
        private Image CurrentPopupButtonImage { get; set; }

        private Coroutine SetReferencesProcess { get; set; }
        private PopupSystemController CurrentPopupSystemController { get; set; }

        public PopupImagesHandler (PopupSystemController currentPopupSystemController, BasicPopupController basicPopupController)
        {
            CurrentPopupSystemController = currentPopupSystemController;
            CurrentPopupSetup = basicPopupController.CurrentBasicPopupSetup;
            CurrentPopupBackgroundImage = basicPopupController.BackgroundImage;
            CurrentPopupButtonImage = basicPopupController.ButtonImage;
        }

        public void SetReferences ()
        {
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
            SpriteCreator spriteCreator = new SpriteCreator(CurrentPopupSystemController);
            spriteCreator.GetImage(imageAddress);
            SetReferencesProcess = CurrentPopupSystemController.StartCoroutine(SetSpriteProcess(spriteCreator, popupImage));
        }

        private IEnumerator SetSpriteProcess (SpriteCreator spriteCreator, Image popupImage)
        {
            yield return new WaitUntil(() => CheckIfSpriteLoaded(spriteCreator) == true);

            popupImage.sprite = spriteCreator.CreatedSprite;
        }

        private bool CheckIfSpriteLoaded (SpriteCreator spriteCreator)
        {
            return spriteCreator.CreatedSprite != null;
        }
    }
}