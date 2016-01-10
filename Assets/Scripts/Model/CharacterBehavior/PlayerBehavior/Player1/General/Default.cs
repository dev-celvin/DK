using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Default : PlayerBehavior<Default>
    {
        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
        }

    }
}
