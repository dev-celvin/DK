using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpFalling : PlayerBehavior<JumpFalling>
    {
        public bool canMove = true;
        public override void init()
        {
            xTransfer = 1;
            yTransfer = 30;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            if (canMove)
            {
                moveableExecute(pc);
                pc.transform.Translate(Player.instance.moveDragRate * xTransfer * Time.deltaTime * Vector3.right);
            }
            else {
                pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
            }
         }

        public override void end(KGCharacterController pc)
        {
            canMove = true;
        }

    }
}
