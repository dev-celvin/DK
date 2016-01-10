using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
}
public class Shift : PlayerBehavior<Shift>
{

    public override void init()
    {
        xTransfer = 8;
        yTransfer = 0;
    }

    public override void execute(KGCharacterController cc)
    {
        PlayerController pc = (PlayerController)cc;
        if (pc.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f)
            pc.transform.Translate(-Player.instance.xDirection * xTransfer * Time.deltaTime * Vector3.right);
        //pc.transform.parent.position -= pc.transform.parent.position.y * Vector3.up;
    }

    public override void begin(KGCharacterController cc)
    {
        PlayerController pc = (PlayerController)cc;
        pc.skeletonGhost.ghostingEnabled = true;
        pc.skeletonGhost.color = new Color32(250, 0, 0, 0);
        CameraController.Instance.SetCameraEffect(CameraMode.Blur, true, 2f);
    }

    public override void end(KGCharacterController cc)
    {
        PlayerController pc = (PlayerController)cc;
        pc.hitAttacks.Clear();
        base.end(pc);
        pc.skeletonGhost.ghostingEnabled = false;
        CameraController.Instance.SetCameraEffect(CameraMode.Blur, false, -1f);
    }

}
