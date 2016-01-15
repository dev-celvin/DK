using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior.PikeManBehavior {

    public class ATK_1 : EnemyBehavior {
        public ATK_1()
        {
            behaviorType = BehaviorType.CanNotThink;
        }

        public override void begin(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController) cc;
            ec.m_SkeletonAnim.timeScale = 1.5f;
        }

        public override void end(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            ec.m_SkeletonAnim.timeScale = 1.0f;
        }
    }

    public class ATK_2 : EnemyBehavior
    {
        public ATK_2() {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Move : EnemyBehavior
    {

        public Move() {
            behaviorType = BehaviorType.CanThink;
            xTransfer = 1;
        }

    }

    public class Defence : EnemyBehavior
    {
        public Defence() {
            behaviorType = BehaviorType.CanNotThink;
        }

        public override void execute(KGCharacterController cc)
        {
            DefencableExecute(cc);
        }
    }

    public class Idle : EnemyBehavior
    {
        public Idle() {
            behaviorType = BehaviorType.CanThink;
        }

    }
    public class Damage : EnemyBehavior
    {
        public Damage()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Dead : EnemyBehavior {
        public Dead() {
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
}

