using UnityEngine;

namespace UnityMouse.Parallax
{
    internal class MouseAPI
    {
        public static Vector2 MousePosition
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return UnityEngine.InputSystem.Mouse.current.position.ReadValue();
#else
                return Input.mousePosition;
#endif
            }
        }
    }
}
