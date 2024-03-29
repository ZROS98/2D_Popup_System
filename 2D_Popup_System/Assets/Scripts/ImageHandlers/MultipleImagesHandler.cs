using System.Collections;
using System.Collections.Generic;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem.ImageHandling
{
    public class MultipleImagesHandler : BaseImageHandler
    {
        [field: SerializeField]
        private PopupSetupWithMultipleOptions CurrentPopupSetupWithMultipleOptions { get; set; }
        [field: SerializeField]
        private List<Image> ImageCollection { get; set; } = new List<Image>();

        private List<SpriteCreator> SpriteCreatorCollection { get; set; } = new List<SpriteCreator>();

        protected virtual void Awake ()
        {
            SetAllImageReferences();
        }

        private void SetAllImageReferences ()
        {
            for (int i = 0; i < CurrentPopupSetupWithMultipleOptions.ButtonImageAddressCollection.Count; i++)
            {
                SetImageReference(CurrentPopupSetupWithMultipleOptions.ButtonImageAddressCollection[i], out SpriteCreator spriteCreator);
                SpriteCreatorCollection.Add(spriteCreator);
            }

            StartCoroutine(SetSpritesProcess());
        }

        private IEnumerator SetSpritesProcess ()
        {
            for (int i = 0; i < SpriteCreatorCollection.Count; i++)
            {
                yield return new WaitUntil(() => CheckIfSpriteLoaded(SpriteCreatorCollection[i]));
                
                Sprite sprite = SpriteCreatorCollection[i].CreatedSprite;
                ImageCollection[i].sprite = sprite;
            }
        }
    }
}