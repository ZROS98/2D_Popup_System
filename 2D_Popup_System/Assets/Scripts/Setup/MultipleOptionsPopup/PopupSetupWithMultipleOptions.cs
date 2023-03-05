using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem.Data
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class PopupSetupWithMultipleOptions : BasicPopupSetup
    {
        [field: SerializeField]
        public List<string> ButtonImageAddress { get; private set; }

        private const string ASSET_NAME = nameof(PopupSetupWithMultipleOptions);
    }
}