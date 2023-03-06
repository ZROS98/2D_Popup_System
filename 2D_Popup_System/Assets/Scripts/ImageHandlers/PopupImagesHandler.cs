using System;
using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class PopupImagesHandler
    {
        //[field: SerializeField]
        private BasicPopupSetup CurrentPopupSetup { get; set; }
        //[field: SerializeField]
        private Image CurrentPopupBackgroundImage { get; set; }
        //[field: SerializeField]
        private Image CurrentPopupButtonImage { get; set; }

        private Coroutine SetReferencesProcess { get; set; }
        private MonoBehaviour CoroutineController { get; set; }

        private SpriteCreator CurrentSpriteCreator { get; set; }

        public PopupImagesHandler (MonoBehaviour coroutineController, BasicPopupSetup popupSetup, Image popupBackgroundImage, Image popupButtonImage)
        {
            CoroutineController = coroutineController;
            CurrentPopupSetup = popupSetup;
            CurrentPopupBackgroundImage = popupBackgroundImage;
            CurrentPopupButtonImage = popupButtonImage;
        }

        public void SetReferences ()
        {
            CurrentSpriteCreator = new SpriteCreator(CoroutineController);

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
            SetReferencesProcess = CoroutineController.StartCoroutine(SetSpriteProcess(imageAddress, popupImage));
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