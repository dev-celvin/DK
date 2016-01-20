using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Attack
    {

        public KGCharacterController releaser;
        public AttackEffect atkEffect;
        public Vector3 hitPos { get; set; }
        public int direction { get; set; }

        public Attack(KGCharacterController releaser, AttackEffect attackInfo, int direction)
        {
            this.releaser = releaser;
            atkEffect = attackInfo;
            this.direction = direction;
        }


    }

    public enum AttackObjectType {
        Dart,
    }

}
