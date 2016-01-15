using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Enemy
{
    [TaskCategory("Enemy")]
    [TaskDescription("Returns a TaskStatus of Success if this enemy have a available skill")]
    public class Attack : Action
    {
        private KGEnemyController ec;
        private Transform targetTransform;

        public override void OnStart()
        {
            ec = GetComponent<KGEnemyController>();
            targetTransform = PlayerController.instance.transform;
        }
        public override TaskStatus OnUpdate()
        {
            AttackEffect ae = ec.character.m_skills.GetRandomAttack(Mathf.Abs(transform.position.x - targetTransform.position.x));
            if (ae != null && ae.IsAvailable()) {
                ec.DoAttack(ae);
                ae.CDReset();
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