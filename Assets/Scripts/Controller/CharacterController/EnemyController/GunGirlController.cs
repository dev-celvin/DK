using KGCustom.Model.Behavior.EnemyBehavior;
using KGCustom.Model.Character.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Controller.CharacterController.EnemyController
{
    public class GunGirlController : KGEnemyController{
#if UNITY_EDITOR
        public static GunGirlController instance;
        protected override void SetAnim(int index)
        {
            string animName = (index == -1) ? "&&" : m_behaviors[index].animName;
            foreach (AttackEffect ae in character.m_skills.skillList)
            {
                if (ae.name == animName)
                {
                    ae.hRange = 10000;
                }
                else ae.hRange = 0;
            }
        }
#endif
        private Dictionary<string, CharacterBehavior> animToState = new Dictionary<string, CharacterBehavior>()
        {
            { "atk_1" ,new EnemyBehavior(CharacterBehavior.BehaviorType.CanNotThink) },
            { "atk_2", new EnemyBehavior(CharacterBehavior.BehaviorType.CanNotThink) },
            { "atk_3", new EnemyBehavior(CharacterBehavior.BehaviorType.CanNotThink) },
            { "move",  new EnemyBehavior(CharacterBehavior.BehaviorType.CanThink, 3) },
            { "damage", new GeneralDamage()},
            { "idle", new EnemyBehavior(CharacterBehavior.BehaviorType.CanThink)},
            { "dead", new GeneralDead()},
        };

        void Start()
        {
#if UNITY_EDITOR
            if (instance == null) instance = this;
#endif
            if (!initFinished)
            {
                init();
                initFinished = true;
            }
        }
        void Update()
        {
#if UNITY_EDITOR
            if (m_behaviors.Count != 0)
            {
                for (int i = 0; i < m_behaviors.Count; i++)
                {
                    if (animToState.ContainsKey(m_behaviors[i].animName))
                    {
                        animToState[m_behaviors[i].animName].animCurve = m_behaviors[i].curve;
                        animToState[m_behaviors[i].animName].xTransfer = m_behaviors[i].xTransfer;
                    }
                    else if (m_behaviors[i].animName == "") {
                        Debug.LogError("动画名不能为空");
                    }
                    else Debug.LogError("动画名" + m_behaviors[i].animName + "不存在");
                }
            }
#endif
            ECUpdate();
        }

        protected override void init()
        {
            character = new GunGirl();
            Sound sound;
            for (int i = 0; i < soundLists.Count; i++)
            {
                sound = soundLists[i];
                if (animToState.ContainsKey(sound.animName)) animToState[sound.animName].SetAudioClip(sound.audioClip);
                else Debug.LogError("SoundLists中声音文件动画名找不到对应动画!");
            }
            for (int i = 0; i < m_behaviors.Count; i++)
            {
                if (animToState.ContainsKey(m_behaviors[i].animName))
                    animToState[m_behaviors[i].animName].animCurve = m_behaviors[i].curve;
                else Debug.LogError("GunGirlController AnimationCurve Init Error: No " + m_behaviors[i].animName);
            }
            base.init();
        }

        public override void DoDamage()
        {
            Model.Attack atk = hitAttacks.Pop();
            character.hp -= atk.atkEffect.getDamageValue();
            ChangeDirection(-atk.direction);
            GameObject hiteffect = PoolManager.instance.GetHitEffectPool().Instantiate();
            hiteffect.transform.position = atk.hitPos;
            hiteffect.GetComponent<HitEffect>().PlayHitEffect(3);
            if (hitAttacks.Count != 0)
            {
                DoDamage();
            }
            if (character.hp <= 0)
            {
                DoDead();
                return;
            }
            if (character.curState == animToState["damage"])
            {
                m_SkeletonAnim.state.SetAnimation(0, "damage", false);
                return;
            }
            m_SkeletonAnim.AnimationName = "damage";
            m_SkeletonAnim.state.GetCurrent(0).loop = false;
            ChangeState();
        }
        public override void DoDead()
        {
            if (character.curState == animToState["dead"])
            {
                return;
            }
            m_SkeletonAnim.AnimationName = "dead";
            m_SkeletonAnim.state.GetCurrent(0).loop = false;
            ChangeState();
        }
        public override void DoIdle()
        {
            if (character.curState == animToState["idle"])
            {
                return;
            }
            m_SkeletonAnim.AnimationName = "idle";
            m_SkeletonAnim.state.GetCurrent(0).loop = true;
            ChangeState();
        }

        public override void DoMove()
        {
            if (character.curState == animToState["move"])
            {
                return;
            }
            m_SkeletonAnim.AnimationName = "move";
            m_SkeletonAnim.state.GetCurrent(0).loop = true;
            audioSource.Play();
            ChangeState();
        }

        public override void DoAttack(AttackEffect ae)
        {
            if (character.curState == animToState[ae.name])
            {
                return;
            }
            base.DoAttack(ae);
        }

        protected override CharacterBehavior GetState(string animName)
        {
            if (animToState.ContainsKey(animName))
            {
                return animToState[animName];
            }
            return null;
        }
    }

}

