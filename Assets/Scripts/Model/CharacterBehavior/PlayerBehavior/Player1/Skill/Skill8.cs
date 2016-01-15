using KGCustom.Controller;
public class Skill8 : PlayerBehavior<Skill8>
{
    public override void begin(KGCharacterController pc)
    {
        attackBegin((PlayerController)pc);
    }
    public override void execute(KGCharacterController cc)
    {
        if (damageCount((PlayerController)cc)) return;
        skillExecute((PlayerController)cc);
        base.execute(cc);
    }

    public override void init()
    {
        xTransfer = 10;
    }
    public override void end(KGCharacterController cc)
    {
        attackEnd(cc);
        CameraController.Instance.SetCameraEffect(CameraMode.Focus, false, -1f, -1f, -1f, null);
    }
}