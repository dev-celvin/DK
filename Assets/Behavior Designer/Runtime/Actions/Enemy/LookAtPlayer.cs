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
                ec.character.xDirection = Global.GlobalValue.XDIRECTION_LEFT;
            }
            else if (ec.transform.position.x < PlayerController.instance.transform.position.x)
            {
                ec.character.xDirection = Global.GlobalValue.XDIRECTION_RIGHT;
            }
            ec.transform.localScale = Vector3.right * -ec.character.xDirection + Vector3.one - Vector3.right;
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            ec = null;
        }
    }
}