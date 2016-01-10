
using KGCustom.Controller;

namespace KGCustom.Model {
    public class DefenceSuccess : PlayerBehavior<DefenceSuccess>
    {
        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.m_animator.SetBool("Damage", false);
        }

    }
}
