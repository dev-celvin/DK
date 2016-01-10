using KGCustom.Model;
using UnityEngine;

namespace KGCustom.Controller {
    public class AttackEffectController : MonoBehaviour
    {
        public Transform m_Transform;

        public MeshRenderer m_MeshRenderer;

        public SkeletonAnimation m_SkeletonAnimation;
        public Attack m_curAttack { get; set; }

        void Start() {
            init();
        }

        protected virtual void init() {
            m_MeshRenderer.enabled = true;
            m_SkeletonAnimation.state.Complete += OnComplete;
        }

        public virtual void release(KGCharacterController releaser, AttackEffect ae)
        {
            m_SkeletonAnimation.AnimationName = ae.name;
            m_SkeletonAnimation.timeScale = ae.timeScale;
            m_Transform.localScale = new Vector3(releaser.character.xDirection * m_Transform.localScale.x, 1, 1);
            m_curAttack = new Attack(releaser, ae, releaser.character.xDirection);
        }

        protected virtual void OnComplete(Spine.AnimationState animstate, int index, int loopcount)
        {
            Destroy(m_Transform.gameObject);
        }

    }

}

