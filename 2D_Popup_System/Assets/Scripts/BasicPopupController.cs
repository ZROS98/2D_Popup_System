using TMPro;
using UnityEngine;

namespace PopupSystem
{
    public class BasicPopupController : MonoBehaviour
    {
        protected virtual void Awake ()
        {
        }

        protected void SetTextReferences (TMP_Text tmpText, string targetText, int maxTextLength)
        {
            tmpText.text = GetProperTextLength(targetText, maxTextLength);
        }

        private string GetProperTextLength (string targetText, int maxTextLenght)
        {
            return targetText.Length > maxTextLenght ? targetText.Substring(0, maxTextLenght) : targetText;
        }
    }
}