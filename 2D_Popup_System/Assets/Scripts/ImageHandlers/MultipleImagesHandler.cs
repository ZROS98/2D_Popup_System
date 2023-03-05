using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        private SpriteCreator CurrentSpriteCreator { get; set; }

        protected virtual void Awake ()
        {
            SetImageReferences();
        }

        private void SetImageReferences ()
        {
            CurrentSpriteCreator = new SpriteCreator(this);
            
            for (int i = 0; i < CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count; i++)
            {
                CurrentSpriteCreator.GetImage(CurrentPopupSetupWithMultipleOptions.ButtonImageAddress[i]);
            }

            StartCoroutine(SetSpritesProcess());
        }

        private IEnumerator SetSpritesProcess ()
        {
            yield return new WaitUntil(() => CheckIfAllSpritesAreLoaded() == true);

            CurrentSpriteCreator.SpriteCollection.OrderBy(x => x.name);
            
            for (int i = 0; i < CurrentSpriteCreator.SpriteCollection.Count; i++)
            {
                Sprite sprite = CurrentSpriteCreator.SpriteCollection[i];
                CurrentImageCollection[i].sprite = sprite;
            }
        }

        private bool CheckIfAllSpritesAreLoaded ()
        {
            return CurrentSpriteCreator.SpriteCollection.Count == CurrentPopupSetupWithMultipleOptions.ButtonImageAddress.Count;
        }
    }
}