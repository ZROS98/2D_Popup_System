using UnityEngine;

namespace PopupSystem
{
    public static class GameObjectExtensionMethods
    {
        public static void SetActiveOptimized (this GameObject target, bool state)
        {
            if (target != null && target.activeSelf != state)
            {
                target.SetActive(state);
            }
        }
    }
}