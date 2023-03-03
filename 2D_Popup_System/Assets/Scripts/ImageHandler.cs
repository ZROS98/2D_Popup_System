using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PopupSystem
{
    public class ImageHandler : MonoBehaviour
    {
        public Texture2D CurrentTexture2D;
        public List<Texture2D> CurrentTexture2DCollection { get; private set; } = new List<Texture2D>();

        public void GetImage (string imageAddress)
        {
            StartCoroutine(GetImageProcess(imageAddress));
        }

        private IEnumerator GetImageProcess (string imageAddress)
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
                    CurrentTexture2D = DownloadHandlerTexture.GetContent(unityWebRequest);
                    CurrentTexture2DCollection.Add(CurrentTexture2D);
                }
            }
        }
    }
}