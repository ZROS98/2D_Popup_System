using UnityEngine;

namespace PopupSystem
{
    [CreateAssetMenu( menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class PopupSetup : MonoBehaviour
    {
        [field: SerializeField]
        public string Title { get; set; }
        [field: SerializeField]
        public string Message { get; set; }
        [field: SerializeField]
        public string ButtonImageAddress { get; set; }
        [field: SerializeField]
        public string BackgroundImageAddress { get; set; }
        
        private const string ASSET_NAME = nameof(PopupSetup);
    }
}