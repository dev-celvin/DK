using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior
{
    public class EnemyBehavior : CharacterBehavior
    {
        protected bool startFall = false;
        protected float startFallTime = -1;
        public override void execute(KGCharacterController cc)
        {
            if (cc.hitAttacks.Count != 0) ((KGEnemyController)cc).DoDamage();
            base.execute(cc);
        }


        protected virtual void DefencableExecute(KGCharacterController cc) {
            KGEnemyController ec = (KGEnemyController)cc;
            if (ec.hitAttacks.Count != 0)
            {
                ec.DoDefence();
            }
            if (animCurve != null) cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * animCurve.Evaluate(Time.time - startTime) * xTransfer * Vector2.right));
            else cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * xTransfer * Vector2.right));
        }
    }
}
