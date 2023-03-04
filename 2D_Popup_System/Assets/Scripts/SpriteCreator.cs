using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PopupSystem
{
    public class ImageHandler : MonoBehaviour
    {
        public List<Sprite> SpriteCollection { get; private set; } = new List<Sprite>();

        public void GetImage (string imageAddress)
        {
            StartCoroutine(GetTextureProcess(imageAddress));
        }

        private IEnumerator GetTextureProcess (string imageAddress)
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(ProjectConstants.GOOGLE_DRIVE_DOWNLOAD_LINK + imageAddress))
            {
                yield return unityWebRequest.SendWebRequest();

                if (unityWebRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(unityWebRequest.error);
                }
                else
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(unityWebRequest);
                    CreateSprite(texture, imageAddress);
                }
            }
        }

        private void CreateSprite (Texture2D texture, string imageAddress)
        {
            Sprite createdSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            createdSprite.name = imageAddress;
            SpriteCollection.Add(createdSprite);
        }
    }
}