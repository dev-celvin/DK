using KGCustom.Model;
using UnityEngine;

namespace KGCustom.Controller {
    public class AttackEffectController : AttackController
    {
        public Transform rootTransform;

        public MeshRenderer meshRenderer;

        public SkeletonAnimation skeletonAnim;
        private bool initComplete = false;

        void Start() {
            if (!initComplete)
            {
                init();
                initComplete = true;
            }
        }

        protected virtual void init() {
            meshRenderer.enabled = true;
            skeletonAnim.state.Complete += OnComplete;
        }

        public override void release(KGCharacterController releaser, AttackEffect ae)
        {
            skeletonAnim.AnimationName = ae.name;
            skeletonAnim.timeScale = ae.timeScale;
            rootTransform.localScale = new Vector3(releaser.transform.localScale.x, 1, 1);
            m_attack = new Attack(releaser, ae, releaser.character.xDirection);
        }

        protected virtual void OnComplete(Spine.AnimationState animstate, int index, int loopcount)
        {
            if (CanStop) m_attack.releaser.RemoveAtkEffect(this);
            skeletonAnim.AnimationName = null;
            m_attack.releaser.attackEffectPool.Push(rootTransform.gameObject);
        }

        public void TryStopEffect() {
            if (skeletonAnim.state.GetCurrent(0).time >= m_attack.atkEffect.stoppableTime) return;
            m_attack.releaser.attackEffectPool.Push(rootTransform.gameObject);
        }

    }

}

