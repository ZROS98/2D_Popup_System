using System.Collections;
using System.Collections.Generic;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class MultipleImagesHandler : MonoBehaviour
    {
        [field: SerializeField]
        private PopupSetupWithMultipleOptions CurrentPopupSetupWithMultipleOptions { get; set; }
        [field: SerializeField]
        private List<Image> CurrentImageCollection { get; set; } = new List<Image>();

        private List<SpriteCreator> SpriteCreatorCollection { get; set; } = new List<SpriteCreator>();

        protected virtual void Awake ()
        {
            SetImageReferences();
        }

        private void SetImageReferences ()
        {
            for (int i = 0; i < CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count; i++)
            {
                SpriteCreator spriteCreator = new SpriteCreator(this);
                spriteCreator.GetImage(CurrentPopupSetupWithMultipleOptions.ButtonImageAddress[i]);
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
                CurrentImageCollection[i].sprite = sprite;
            }
        }

        private bool CheckIfSpriteLoaded (SpriteCreator spriteCreator)
        {
            return spriteCreator.CreatedSprite != null;
        }
    }
}