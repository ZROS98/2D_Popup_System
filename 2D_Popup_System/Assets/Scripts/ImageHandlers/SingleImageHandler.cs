using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem.ImageHandling
{
    public class SingleImageHandler : BaseImageHandler
    {
        private SpriteCreator CurrentSpriteCreator;
        [field: SerializeField]
        private ImageSetup CurrentImageSetup { get; set; }
        [field: SerializeField]
        private Image CurrentImage { get; set; }

        public bool CheckIfSpriteLoaded ()
        {
            return CurrentSpriteCreator.CreatedSprite != null;
        }
        
        protected virtual void Awake ()
        {
            SetImageReference(CurrentImageSetup.ImageAddress, out _);
        }

        protected override void SetImageReference (string imageAddress, out SpriteCreator spriteCreator)
        {
            base.SetImageReference(imageAddress, out spriteCreator);
            CurrentSpriteCreator = spriteCreator;
            StartCoroutine(SetSpriteProcess());
        }

        private IEnumerator SetSpriteProcess ()
        {
            yield return new WaitUntil(() => CheckIfSpriteLoaded(CurrentSpriteCreator));

            CurrentImage.sprite = CurrentSpriteCreator.CreatedSprite;
        }
    }
}