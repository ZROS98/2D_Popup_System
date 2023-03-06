using UnityEngine;

namespace PopupSystem.Data
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class PopupWithLinkSetup : BasicPopupSetup
    {
        [field: SerializeField]
        public string LinkAddress { get; set; }

        private const string ASSET_NAME = nameof(PopupWithLinkSetup);
    }
}