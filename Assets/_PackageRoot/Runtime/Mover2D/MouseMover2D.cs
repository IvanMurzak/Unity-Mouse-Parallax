using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace UnityMouse.Parallax
{ 
    public abstract class MouseMover2D : MonoBehaviour
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
                target.OriginalLocalPosition = target.target.localPosition;
        }
        protected virtual void OnDisable()
        {
            foreach (var target in targets)
                target.target.localPosition = target.OriginalLocalPosition;
        }

        protected abstract void OnUpdatePrepeare();
        protected abstract void ApplyTransform(ParallaxTarget target, Vector2 offsetMultiplier);

        protected virtual void Update()
        {
            OnUpdatePrepeare();

            foreach (var target in targets)
            {
                if (target != null)
                    ApplyTransform(target, offsetMultiplier);
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

            public Vector3      OriginalLocalPosition { get; set; }
	    }
    }
}