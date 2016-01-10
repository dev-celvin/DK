using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Attack
    {

        public KGCharacterController m_Releaser;
        public AttackEffect m_AttackEffect;
        public Vector3 hitPos { get; set; }
        public int direction { get; set; }

        public Attack(KGCharacterController releaser, AttackEffect attackInfo, int direction)
        {
            m_Releaser = releaser;
            m_AttackEffect = attackInfo;
            this.direction = direction;
        }


    }
}
