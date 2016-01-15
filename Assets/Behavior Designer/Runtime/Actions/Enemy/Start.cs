using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of start")]
    public class Start : Action
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            ec.DoStart();
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}