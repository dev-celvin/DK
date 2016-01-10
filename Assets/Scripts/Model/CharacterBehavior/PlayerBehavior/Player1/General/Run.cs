using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Run : PlayerBehavior<Run>
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
            if (Mathf.Abs(Player.instance.moveDragRate) >= 0.9f)
            {
                pc.skeletonGhost.color = new Color32(0, 135, 248, 0);
                pc.skeletonGhost.ghostingEnabled = true;
                CameraController.Instance.SetCameraEffect(CameraMode.Blur, true, 2f);
            }
            else
            {
                pc.skeletonGhost.ghostingEnabled = false;
                CameraController.Instance.SetCameraEffect(CameraMode.Blur, false, -1f);
            }
            if (damageCount(pc)) return;
            moveableExecute(pc);
            nextToAttackExecute(pc);
#if UNITY_STANDALONE_WIN
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlayerAttack.instance.normalIndex = 0;
                pc.m_animator.SetInteger("AttackAction", 0);

                pc.skeletonGhost.color = new Color32(0, 135, 250, 0);
                pc.m_animator.SetTrigger("RunAttack");
            }
#else
        					if (KeyManager.instance.GetKeyMessage(KeyManager.KeyCode.Attack))
                            {
                               PlayerAttack.instance.normalIndex = 0;
                            pc.m_animator.SetInteger("AttackAction", 0);
                            pc.skeletonGhost.color = new Color32(0, 135, 250, 0);
                            pc.m_animator.SetTrigger("RunAttack");
                            }
#endif
            pc.transform.Translate(Player.instance.moveDragRate * xTransfer * Time.deltaTime * Vector3.right);
            //pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            PlayerAttack.instance.normalIndex = 0;
            pc.m_animator.SetInteger("AttackAction", 0);

        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.skeletonGhost.ghostingEnabled = false;
            CameraController.Instance.SetCameraEffect(CameraMode.Blur, false, -1f);
        }

    }
}
