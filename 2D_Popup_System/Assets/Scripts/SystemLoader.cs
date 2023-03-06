using System.Collections;
using UnityEngine;

namespace PopupSystem.ImageHandling
{
    public class SystemLoader : MonoBehaviour
    {
        [field: SerializeField]
        private SingleImageHandler CurrentImageHandler { get; set; }

        protected virtual void Start ()
        {
            StartCoroutine(WaitForSpritesProcess());
        }

        private IEnumerator WaitForSpritesProcess ()
        {
            yield return new WaitUntil(() => CurrentImageHandler.CheckIfSpriteLoaded());
            
            gameObject.SetActiveOptimized(false);
        }
    }
}