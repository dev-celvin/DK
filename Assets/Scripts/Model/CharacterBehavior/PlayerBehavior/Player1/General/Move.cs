using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Move : PlayerBehavior<Move>
    {
        public override void init()
        {
            xTransfer = 6;
            yTransfer = 0;
        }
        public override void execute(KGCharacterController cc)
        {
            if (Player.instance.xDirection > 0)
            {
                CameraController.Instance.SetFace(FaceCode.Right);
            }
            else if (Player.instance.xDirection < 0)
            {
                CameraController.Instance.SetFace(FaceCode.Left);
            }
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            moveableExecute(pc);
            nextToAttackExecute(pc);
            pc.transform.Translate(Player.instance.moveDragRate * xTransfer * Time.deltaTime * Vector3.right);
            //pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
        }

    }
}
