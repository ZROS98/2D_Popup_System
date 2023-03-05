using System.Collections;
using PopupSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class SingleImageHandler : MonoBehaviour
    {
        [field: SerializeField]
        private SpriteCreator CurrentSpriteCreator { get; set; }
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
            SetImageReference();
        }

        private void SetImageReference ()
        {
            CurrentSpriteCreator.GetImage(CurrentImageSetup.ImageAddress);
            StartCoroutine(SetSpriteProcess());
        }

        private IEnumerator SetSpriteProcess ()
        {
            yield return new WaitUntil(() => CheckIfSpriteLoaded() == true);

            CurrentImage.sprite = CurrentSpriteCreator.SpriteCollection[0];
        }
    }
}