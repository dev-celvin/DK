using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior.GunGirlBehavior {

    public class ATK_1 : EnemyBehavior {
        public ATK_1()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class ATK_2 : EnemyBehavior
    {
        public ATK_2() {
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
    public class Move : EnemyBehavior
    {

        public Move() {
            behaviorType = BehaviorType.CanThink;
            xTransfer = 3;
        }
    }

    public class Damage_1 : EnemyBehavior
    {
        public Damage_1() {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Idle : EnemyBehavior
    {
        public Idle() {
            behaviorType = BehaviorType.CanThink;
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

