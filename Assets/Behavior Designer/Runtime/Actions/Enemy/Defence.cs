using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success to defence")]
    public class Defence : Action
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (ec.hitAttacks.Count != 0)
            {
                ec.DoDefence();
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}