using UnityEngine;
using System.Collections;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using KGCustom.Model.Behavior.EnemyBehavior;
using Spine;
using System;

namespace KGCustom.Model.Behavior.EnemyBehavior.ZakoFarBehavior
{
    public class ATK_FAR : EnemyBehavior
    {
        ZakoFarController zc;
        public ATK_FAR()
        {
            behaviorType = BehaviorType.CanNotThink;
        }

        public override void begin(KGCharacterController cc)
        {
            zc = (ZakoFarController)cc;
            zc.m_SkeletonAnim.state.Event += OnEvent;
        }

        private void OnEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
        {
            if (e.Data.name == "1st_syuriken" || e.Data.name == "2nd_syuriken") {
                GameObject dart = PoolManager.instance.GetPoolByType(AttackObjectType.Dart).Instantiate();
                AttackObjectController aoCtrl = dart.GetComponent<AttackObjectController>();
                dart.transform.parent  = zc.transform.parent;
                dart.transform.position = zc.transform.position + Vector3.up * 0.9f;
                dart.GetComponent<Collider2D>().enabled = true;
                dart.GetComponent<Renderer>().material.color = Color.white;
                aoCtrl.direction = (sbyte)zc.character.xDirection;
                aoCtrl.release(zc, zc.character.m_skills.getBySkillName("atk_far"));
                aoCtrl.StartFlyForward();
            }
        }

        public override void end(KGCharacterController cc)
        {
            zc.m_SkeletonAnim.state.Event -= OnEvent;
            zc = null;
        }

    }

}