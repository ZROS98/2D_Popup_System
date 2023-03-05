using UnityEngine;

namespace PopupSystem.Data 
{
    [CreateAssetMenu(menuName = ProjectConstants.POPUP_MENU_PATH + ASSET_NAME)]
    public class SchedulePopupSetup : BasicPopupSetup
    {
        [field: SerializeField, Header("Time in seconds")]
        public int TimeToShowPopup { get; set; }

        private const string ASSET_NAME = nameof(SchedulePopupSetup);
    }
}