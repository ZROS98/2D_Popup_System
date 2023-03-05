using UnityEngine;

namespace PopupSystem.Data
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class BasicPopupSetup : ScriptableObject, ITitle
    {
        [field: SerializeField, Header(ProjectConstants.HEADER_MAX_TEXT_LENGTH + "12")]
        public string Title { get; set; }
        [field: SerializeField, Header(ProjectConstants.HEADER_MAX_TEXT_LENGTH + "75")]
        public string Message { get; private set; }
        [field: SerializeField, Header(ProjectConstants.HEADER_MAX_TEXT_LENGTH + "12")]
        public string ButtonLabel { get; private set; }
        [field: SerializeField]
        public string ButtonImageAddress { get; private set; }
        [field: SerializeField]
        public string BackgroundImageAddress { get; private set; }

        public int MaxTitleLength { get; private set; } = 12;
        public int MaxMessageLength { get; private set; } = 75;
        public int MaxButtonLabelLength { get; private set; } = 12;

        private const string ASSET_NAME = nameof(BasicPopupSetup);
    }
}