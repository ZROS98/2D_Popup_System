using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PopupSystem.ImageHandling
{
    public class SpriteCreator
    {
        public Sprite CreatedSprite { get; private set; }
        private Coroutine SpriteCreatorProcess { get; set; }
        private MonoBehaviour CoroutineController { get; set; }

        public SpriteCreator (MonoBehaviour coroutineController)
        {
            CoroutineController = coroutineController;
        }

        public void GetImage (string imageAddress)
        {
            SpriteCreatorProcess = CoroutineController.StartCoroutine(GetTextureProcess(imageAddress));
        }

        private IEnumerator GetTextureProcess (string imageName)
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(ProjectConstants.GOOGLE_DRIVE_DOWNLOAD_LINK + imageName))
            {
                yield return unityWebRequest.SendWebRequest();

                if (unityWebRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(unityWebRequest.error);
                }
                else
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(unityWebRequest);
                    CreateSprite(texture, imageName);
                }
            }
        }

        private void CreateSprite (Texture2D texture, string imageName)
        {
            CreatedSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            CreatedSprite.name = imageName;
        }
    }
}