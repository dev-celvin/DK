using UnityEngine;
using System.Collections.Generic;
using KGCustom.Model.Behavior.EnemyBehavior;

namespace KGCustom.Controller.CharacterController.EnemyController {
    public abstract class KGEnemyController : KGCharacterController
    {
        //Editor下执行的代码为提供动画位移编辑，可忽略不看
#if UNITY_EDITOR
        public int GetBehaviorCount() {
            return m_behaviors.Count;
        }

        [HideInInspector]
        public int AnimIndex
        {
            get
            {
                return _animIndex;
            }
            set
            {
                SetAnim(value);
                _animIndex = value;
            }
        }
        protected int _animIndex = -1;

        protected virtual void SetAnim(int index)
        {
            
        }
#endif
        /////////////////////////////////////////////

        public SkeletonAnimation m_SkeletonAnim;
        protected GeneralDamage genDamge;
        protected GeneralDead genDead;
        [SerializeField]
        protected List<CharacterBehavior.BehaviorCurve> m_behaviors;

        public virtual void hitAttackHandle() {
            
        }

        protected virtual void ChangeState() {
            if (character.curState != null) character.curState.end(this);
            CharacterBehavior cb = GetState(m_SkeletonAnim.AnimationName);
            character.curState = cb;
            if (cb != null)
            {
                character.curState.begin(this);
            }
        }

        public void ChangeDirection(int direction) {
            if (direction == character.xDirection) return;
            character.xDirection = direction;
            transform.localScale -= (transform.localScale.x + Mathf.Abs(transform.localScale.x) * character.xDirection) * Vector3.right;
        }
        /// <summary>
        /// [必须重写]重写以实现寻找动画名对应的状态，找不到则返回null
        /// </summary>
        /// <param name="animName"></param>
        /// <returns></returns>
        protected virtual CharacterBehavior GetState(string animName) {
            return null;
        }

        //动作集均已DoXxx()形式出现，理论上除DoAttack外均要重写，DoAttack如需特殊处理可重写
        public virtual void DoDefence() {}
        public virtual void DoMove() { }
        public virtual void DoAttack(AttackEffect ae) {
            m_SkeletonAnim.AnimationName = ae.name;
            GameObject go = attackEffectPool.Instantiate();
            go.transform.parent = transform;
            go.transform.position = transform.position;
            AttackEffectController aeCtrl = go.GetComponent<AttackEffectUtility>().m_AttackEffectController;
            aeCtrl.release(this, ae);
            TryPushAtkEffect(aeCtrl);
            ChangeState();
        }
        public virtual void DoDamage() { }
        public virtual void DoIdle() { }
        public virtual void DoDead() { }
        public virtual void DoStart() { }

        protected virtual void ECUpdate() {
            if (character.curState != null) character.curState.execute(this);
        }

        /// <summary>
        /// [有必要时重写]重写实现每个动画结束时执行的动作
        /// </summary>
        /// <param name="state"></param>
        /// <param name="trackIndex"></param>
        /// <param name="loopCount"></param>
        protected virtual void OnComplete(Spine.AnimationState state, int trackIndex, int loopCount){
            switch (character.curState.behaviorType)
            {
                case CharacterBehavior.BehaviorType.CanThink:
                    break;
                default:
                    if (character.curState != null)
                    {
                        character.curState.end(this);
                    }
                    m_SkeletonAnim.AnimationName = null;
                    character.curState = null;
                    break;
            }
        }

        protected override void init()
        {
            transform.localScale = new Vector3(-1, 1, 1);
            ChangeDirection(Global.GlobalValue.XDIRECTION_RIGHT);
            m_SkeletonAnim.state.Complete += OnComplete;
            character.curState = null;
            attackEffectPool = PoolManager.instance.GetPoolByType(character.characterType);
        }

    }

}

