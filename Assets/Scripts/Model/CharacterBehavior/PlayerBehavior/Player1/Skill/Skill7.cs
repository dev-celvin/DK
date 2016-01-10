using KGCustom.Controller;
public class Skill7 : PlayerBehavior<Skill7>
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
    public override void end(KGCharacterController cc)
    {
        attackEnd(cc);
    }
}