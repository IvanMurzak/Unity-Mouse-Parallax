using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UnityMouse.Parallax
{
    public class MouseMover2DFullscreen : MouseMover2D
    {
        [SerializeField] bool screenCenter = true;

        Vector2 position;
        Vector2 originPosition;
        Vector2 screen;

        protected virtual Vector2 Correct(Vector2 position)
        {
            if (position.x < 0)             position.x = 0;
            if (position.x > Screen.width)  position.x = Screen.width;

            if (position.y < 0)             position.y = 0;
            if (position.y > Screen.height) position.y = Screen.height;

            return position;
        }
        protected virtual void Awake()
        {
            screen = new Vector2(Screen.width, Screen.height);
        }
        protected override async UniTask OnEnable()
        {
            await base.OnEnable();

            if (screenCenter)
                originPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
            else
                originPosition = MouseAPI.MousePosition;

        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }

	    protected override void OnUpdatePrepeare()
	    {
            position = (originPosition - Correct(MouseAPI.MousePosition)) / screen;
        }
	    protected override void ApplyTransform(ParallaxTarget target, Vector2 offsetMultiplier)
	    {
            target.target.localPosition = Vector3.Lerp
            (
                target.target.localPosition,
                new Vector3
                (
                    target.OriginalLocalPosition.x + Mathf.Lerp
                    (
                        -target.maxOffset.x * offsetMultiplier.x,
                        target.maxOffset.x * offsetMultiplier.x,
                        (target.inverseX ? -position.x : position.x) + 0.5f
                    ),
                    target.OriginalLocalPosition.y + Mathf.Lerp
                    (
                        -target.maxOffset.y * offsetMultiplier.y,
                        target.maxOffset.y * offsetMultiplier.y,
                        (target.inverseY ? -position.y : position.y) + 0.5f
                    ),
                    target.OriginalLocalPosition.z
                ),
                Time.deltaTime * target.speed * speedMultiplier
            );
        }
    }
}