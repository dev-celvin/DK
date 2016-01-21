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
            base.begin(cc);
        }

        public override void end(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            ec.m_SkeletonAnim.timeScale = 1.0f;
            base.end(cc);
        }
    }

}

