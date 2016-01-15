using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior.ZakoBehavior
{

    public class ATK : EnemyBehavior
    {
        public ATK()
        {
            behaviorType = BehaviorType.CanNotThink;
        }
    }

    public class Move : EnemyBehavior
    {

        public Move()
        {
            behaviorType = BehaviorType.CanThink;
            xTransfer = 2;
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

}

