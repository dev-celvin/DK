using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success if this enemy can move")]
    public class Move : Action
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            ec.DoMove();
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}