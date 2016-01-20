using UnityEngine;
using KGCustom.Model;

namespace KGCustom.Controller {
    public class AttackController : MonoBehaviour
    {
        public Attack m_attack;
        public bool CanStop
        {
            get
            {
                if (m_attack.atkEffect.stoppableTime == 1000) return true;
                return false;
            }
        }

        public virtual void release(KGCharacterController releaser, AttackEffect ae)
        {
            transform.localScale = new Vector3(releaser.transform.localScale.x * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            m_attack = new Attack(releaser, ae, releaser.character.xDirection);
        }
    }
}

