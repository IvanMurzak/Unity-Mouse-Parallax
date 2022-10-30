using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace UnityMouse.Parallax
{ 
    public abstract class MouseRotator2D : MonoBehaviour
    {
                        public  float                   speedMultiplier = 1;
                        public  Vector2                 offsetMultiplier = Vector2.one;
#if ODIN_INSPECTOR
        [Required]
#endif
        [SerializeField]        List<ParallaxTarget>    targets = new List<ParallaxTarget>();


        protected virtual async UniTask OnEnable()
        {
            foreach (var target in targets)
                target.OriginalLocalRotation = target.target.localRotation;
        }
        protected virtual void OnDisable()
        {
            foreach (var target in targets)
                target.target.localRotation = target.OriginalLocalRotation;
        }
        protected abstract void OnUpdatePrepeare();
        protected abstract void ApplyTransform(ParallaxTarget target, Vector2 offsetMultiplier, float toX, float toY, float toZ);
        protected abstract float CalcToX(ParallaxTarget target, Vector2 offsetMultiplier);
        protected abstract float CalcToY(ParallaxTarget target, Vector2 offsetMultiplier);
        protected abstract float CalcToZ(ParallaxTarget target, Vector2 offsetMultiplier);

        protected virtual void Update()
        {
            OnUpdatePrepeare();

            foreach (var target in targets)
            {
                if (target != null)
                {
                    var toX = CalcToX(target, offsetMultiplier);
                    var toY = CalcToY(target, offsetMultiplier);
                    var toZ = CalcToZ(target, offsetMultiplier);

                    if (target.axes == Axes.XY) ApplyTransform(target, offsetMultiplier, toX, toY, toZ);
                    if (target.axes == Axes.XZ) ApplyTransform(target, offsetMultiplier, toX, toZ, toY);
                    if (target.axes == Axes.YZ) ApplyTransform(target, offsetMultiplier, toZ, toX, toY);
                    if (target.axes == Axes.YX) ApplyTransform(target, offsetMultiplier, toY, toX, toZ);
                    if (target.axes == Axes.ZX) ApplyTransform(target, offsetMultiplier, toY, toZ, toX);
                    if (target.axes == Axes.ZY) ApplyTransform(target, offsetMultiplier, toZ, toY, toX);
                }
            }
        }

        [Serializable]
        public class ParallaxTarget
	    {
#if ODIN_INSPECTOR
            [Required]
#endif
            public Transform    target;
            public bool         inverseX    = false; 
            public bool         inverseY    = false;
            public float        speed       = 1;
            public Vector2      maxOffset   = new Vector2(100, 100);
            public Axes         axes        = Axes.XY;

            public Quaternion   OriginalLocalRotation { get; set; }
	    }
    }
}