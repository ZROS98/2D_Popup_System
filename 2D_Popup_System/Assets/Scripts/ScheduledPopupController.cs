using PopupSystem.Data;
using UnityEngine;

namespace PopupSystem
{
    public class ScheduledPopupController : BasicPopupController
    {
        [field: SerializeField]
        public SchedulePopupSetup CurrentSchedulePopupSetup { get; set; }
    }
}