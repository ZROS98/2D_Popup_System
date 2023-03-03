using System.Collections.Generic;
using UnityEngine;

namespace PopupSystem
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class PopupSetupWithMultipleOptions : ScriptableObject
    {
        [field: SerializeField, Header(ProjectConstants.HEADER_MAX_TEXT_LENGTH + "12")]
        public string Title { get; private set; }
        [field: SerializeField]
        public List<string> ButtonImageAddress { get; private set; }
        [field: SerializeField]
        public string BackgroundImageAddress { get; private set; }
        
        public int MaxTitleLength { get; private set; } = 12;
        
        private const string ASSET_NAME = nameof(PopupSetupWithMultipleOptions);
    }
}