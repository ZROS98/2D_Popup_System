using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem.ImageHandling
{
    public class PopupImagesHandler
    {
        private BasicPopupSetup PopupSetup { get; set; }
        private Image PopupBackgroundImage { get; set; }
        private Image PopupButtonImage { get; set; }

        private Coroutine SetReferencesProcess { get; set; }
        private MonoBehaviour CoroutineController { get; set; }

        public PopupImagesHandler (MonoBehaviour monoBehaviour, BasicPopupController basicPopupController)
        {
            CoroutineController = monoBehaviour;
            PopupSetup = basicPopupController.CurrentBasicPopupSetup;
            PopupBackgroundImage = basicPopupController.BackgroundImage;
            PopupButtonImage = basicPopupController.ButtonImage;
        }

        public void SetReferences ()
        {
            if (string.IsNullOrEmpty(PopupSetup.BackgroundImageAddress) == false)
            {
                SetImageReference(PopupSetup.BackgroundImageAddress, PopupBackgroundImage);
            }

            if (string.IsNullOrEmpty(PopupSetup.ButtonImageAddress) == false)
            {
                SetImageReference(PopupSetup.ButtonImageAddress, PopupButtonImage);
            }
        }

        private void SetImageReference (string imageAddress, Image popupImage)
        {
            SpriteCreator spriteCreator = new SpriteCreator(CoroutineController);
            spriteCreator.GetImage(imageAddress);
            SetReferencesProcess = CoroutineController.StartCoroutine(SetSpriteProcess(spriteCreator, popupImage));
        }

        private IEnumerator SetSpriteProcess (SpriteCreator spriteCreator, Image popupImage)
        {
            yield return new WaitUntil(() => CheckIfSpriteLoaded(spriteCreator));

            popupImage.sprite = spriteCreator.CreatedSprite;
        }

        private bool CheckIfSpriteLoaded (SpriteCreator spriteCreator)
        {
            return spriteCreator.CreatedSprite != null;
        }
    }
}