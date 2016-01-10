using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
    [TaskCategory("Basic/Bool")]
    [TaskDescription("Returns success if the enemy is out of mind")]
    public class IsOutOfMind : Conditional
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (ec.character.curState == null) return TaskStatus.Failure;
            switch (ec.character.curState.behaviorType) {
                case CharacterBehavior.BehaviorType.CanNotThink:
                    return TaskStatus.Success;
                case CharacterBehavior.BehaviorType.CanThink:
                    return TaskStatus.Failure;
            }
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}