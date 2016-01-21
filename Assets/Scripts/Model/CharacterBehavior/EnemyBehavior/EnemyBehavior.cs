using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior
{
    public class EnemyBehavior : CharacterBehavior
    {
        protected bool startFall = false;
        protected float startFallTime = -1;

        protected EnemyBehavior() { }
        public EnemyBehavior(BehaviorType btype, float xTransfer = 0, float yTransfer = 0, float startFallTime = -1)
        {
            this.xTransfer = xTransfer;
            behaviorType = btype;
            this.startFallTime = startFallTime;
        }
        public override void execute(KGCharacterController cc)
        {
            if (cc.hitAttacks.Count != 0) ((KGEnemyController)cc).DoDamage();
            base.execute(cc);
        }

        public override void end(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            if (ec.IsMove)
            {
                ec.IsMove = false;
                ec.audioSource.Stop();
            }
        }

        protected virtual void DefencableExecute(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            if (ec.hitAttacks.Count != 0)
            {
                ec.DoDefence();
            }
            if (animCurve != null) cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * animCurve.Evaluate(Time.time - startTime) * xTransfer * Vector2.right));
            else cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * xTransfer * Vector2.right));
        }
    }

    public class GeneralDamage : EnemyBehavior
    {
        public GeneralDamage(BehaviorType btype = BehaviorType.CanNotThink)
        {
            behaviorType = btype;
        }
        public override void begin(KGCharacterController cc)
        {
            cc.StopRunningEffect();
        }
    }

    public class GeneralDead : EnemyBehavior
    {
        public GeneralDead()
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
            GameObject.Destroy(ec.transform.parent.gameObject);
        }
    }

    public class GeneralDefence : EnemyBehavior {
        public GeneralDefence()
        {
            behaviorType = BehaviorType.CanNotThink;
        }

        public override void execute(KGCharacterController cc)
        {
            DefencableExecute(cc);
        }
    }
}
