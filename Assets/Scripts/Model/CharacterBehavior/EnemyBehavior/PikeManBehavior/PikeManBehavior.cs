using UnityEngine;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior.PikeManBehavior {

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

    public class Dead : EnemyBehavior {
        public Dead() {
            behaviorType = BehaviorType.CanNotThink;
        }
    }
}

