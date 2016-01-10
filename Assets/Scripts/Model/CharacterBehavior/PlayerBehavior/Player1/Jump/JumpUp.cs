using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpUp : PlayerBehavior<JumpUp>
    {

        public override void init()
        {
            xTransfer = 3;
            yTransfer = 15;
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            xTransfer = 3 * Player.instance.moveDragRate;
            JumpFlying.instance.xTransfer = xTransfer;
            JumpAtk4.instance.xTransfer = xTransfer;
            JumpFalling.instance.xTransfer = xTransfer;
            JumpFalling.instance.canMove = false;
            pc.StopCoroutine("CheckGround");
            
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            float rate = 1.0f - pc.getCurStateInfo().normalizedTime;
            if (rate > 0)
            {
                pc.rigid2D.velocity = Vector2.up * yTransfer * rate;
            }

            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
            attackableExecute(pc);
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.rigid2D.velocity = Vector2.zero;
            pc.StartCoroutine("CheckGround");
        }

    }
}

