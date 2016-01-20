using UnityEngine;
using System.Collections;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using KGCustom.Model.Behavior.EnemyBehavior;

namespace KGCustom.Model.Behavior.EnemyBehavior.SpiderQueenBehavior
{
    public class ATK_1 : EnemyBehavior
    {
        public ATK_1()
        {
            behaviorType = BehaviorType.CanNotThink;
            startFallTime = 0.5f;
            yTransfer = 15;
        }

        public override void begin(KGCharacterController cc)
        {
            startFall = false;
        }

        public override void execute(KGCharacterController cc)
        {
            SpiderQueenController sqc = (SpiderQueenController)cc;
            if (!startFall)
            {
                float rate = 1 - sqc.m_SkeletonAnim.state.GetCurrent(0).time / startFallTime;
                if (rate > 0)
                {
                    sqc.rigid2D.velocity = Vector2.up * yTransfer * rate;
                }
                else
                {
                    sqc.rigid2D.velocity -= Vector2.up * sqc.rigid2D.velocity.y;
                    startFall = true;
                }
            }
            sqc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right * sqc.character.xDirection);
        }

    }

}