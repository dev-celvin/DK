
using KGCustom.Controller;

namespace KGCustom.Model {
    public class JumpStandby : PlayerBehavior<JumpStandby>
    {

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            pc.m_animator.SetBool("JumpAttack", false);
        }

    }
}
