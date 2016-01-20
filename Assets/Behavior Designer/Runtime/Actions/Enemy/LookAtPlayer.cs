using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Look at the player")]
    public class LookAtPlayer : Action
    {
        private KGEnemyController ec;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
        }
        public override TaskStatus OnUpdate()
        {
            if (ec.transform.position.x > PlayerController.instance.transform.position.x)
            {
                ec.ChangeDirection(Global.GlobalValue.XDIRECTION_LEFT);
            }
            else if (ec.transform.position.x < PlayerController.instance.transform.position.x)
            {
                ec.ChangeDirection(Global.GlobalValue.XDIRECTION_RIGHT);
            }
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}