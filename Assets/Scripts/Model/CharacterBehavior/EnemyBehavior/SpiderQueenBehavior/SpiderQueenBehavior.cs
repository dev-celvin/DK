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

    public class ATK_2 : EnemyBehavior
    {
        public ATK_2()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class ATK_3 : EnemyBehavior
    {
        public ATK_3()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class ATK_4 : EnemyBehavior
    {
        public ATK_4()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Move : EnemyBehavior
    {

        public Move()
        {
            behaviorType = BehaviorType.CanThink;
            xTransfer = 1;
        }

    }
    public class Damage : EnemyBehavior
    {
        public Damage()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }
    public class Damage2 : EnemyBehavior
    {
        public Damage2()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Defence : EnemyBehavior
    {
        public Defence()
        {
            behaviorType = BehaviorType.CanNotThink;
        }

        public override void execute(KGCharacterController cc)
        {
            DefencableExecute(cc);
        }
    }

    public class Idle : EnemyBehavior
    {
        public Idle()
        {
            behaviorType = BehaviorType.CanThink;
        }

    }

    public class Dead : EnemyBehavior
    {
        public Dead()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
        public override void begin(KGCharacterController cc)
        {
            base.begin(cc);
            KGEnemyController ec = (KGEnemyController)cc;
            ec.transform.parent.Find("Collider/HitCollider/body").GetComponent<CircleCollider2D>().enabled = false;
        }

        public override void end(KGCharacterController cc)
        {
            base.end(cc);
            KGEnemyController ec = (KGEnemyController)cc;
            ec.transform.parent.Find("Collider/General/base").GetComponent<CircleCollider2D>().enabled = false;
            GameObject.Destroy(ec.transform.parent.gameObject);
        }
    }
    public class Start : EnemyBehavior
    {
        public Start()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

}