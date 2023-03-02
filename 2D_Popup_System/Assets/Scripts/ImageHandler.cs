using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PopupSystem
{
    public class ImageHandler : MonoBehaviour
    {
        [field: SerializeField]
        private Texture2D CurrentTexture { get; set; }
        [field: SerializeField]
        private PopupSetup CurrentPopupSetup { get; set; }
        
        protected virtual void Start ()
        {
            StartCoroutine(GetImageProcess());
        }

        private IEnumerator GetImageProcess ()
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(ProjectConstants.GOOGLE_DRIVE_DOWNLOAD_LINK + CurrentPopupSetup.ButtonImageAddress))
            {
                yield return unityWebRequest.SendWebRequest();

                if (unityWebRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(unityWebRequest.error);
                }
                else
                {
                    CurrentTexture = DownloadHandlerTexture.GetContent(unityWebRequest);
                }
            }
        }
    }
}