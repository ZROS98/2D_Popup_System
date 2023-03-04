using UnityEngine;

namespace PopupSystem.Data
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class ImageSetup : ScriptableObject
    {
        [field: SerializeField]
        public string ImageAddress { get; private set; }

        private const string ASSET_NAME = nameof(ImageSetup);
    }
}