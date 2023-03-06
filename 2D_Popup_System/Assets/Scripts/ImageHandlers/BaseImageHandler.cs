using UnityEngine;

namespace PopupSystem.ImageHandling
{
    public abstract class BaseImageHandler : MonoBehaviour
    {
        protected bool CheckIfSpriteLoaded (SpriteCreator spriteCreator)
        {
            return spriteCreator.CreatedSprite != null;
        }

        protected virtual void SetImageReference (string imageAddress, out SpriteCreator spriteCreator)
        {
            spriteCreator = new SpriteCreator(this);
            spriteCreator.GetImage(imageAddress);
        }
    }
}