
using KGCustom.Controller;

namespace KGCustom.Model {
    public class Attack3 : PlayerBehavior<Attack3>
    {
        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            attackBegin(pc);
        }
        public override void execute(KGCharacterController cc)
        {
            if (damageCount((PlayerController)cc)) return;
            normaAttackExecute((PlayerController)cc);
            base.execute((PlayerController)cc);
        }
        public override void end(KGCharacterController cc)
        {
            attackEnd(cc);
        }
    }
}
