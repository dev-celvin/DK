using KGCustom.Controller;
public class Skill6 : PlayerBehavior<Skill6>
{
    public override void begin(KGCharacterController pc)
    {
        attackBegin((PlayerController)pc);
    }

    public override void init()
    {
        xTransfer = 1.0f;
        yTransfer = 0;
    }
    public override void execute(KGCharacterController cc)
    {
        if (damageCount((PlayerController)cc)) return;
        skillExecute((PlayerController)cc);
        base.execute(cc);
    }
    public override void end(KGCharacterController cc)
    {
        attackEnd(cc);
    }
}