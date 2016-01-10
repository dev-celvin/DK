using KGCustom.Controller;

namespace KGCustom.Model {
    public class DamageOver : PlayerBehavior<DamageOver>
    {
        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.hitAttacks.Clear();
        }
    }
}
