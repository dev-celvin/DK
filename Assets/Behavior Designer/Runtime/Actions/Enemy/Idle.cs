using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success if this enemy is close to the player")]
    public class Idle : Action
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (Mathf.Abs(ec.transform.position.x - PlayerController.instance.transform.position.x) <= 0.75f)
            {
                ec.DoIdle();
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