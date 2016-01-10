
using KGCustom.Controller;

namespace KGCustom.Model {
    public class Fan : PlayerBehavior<Fan>
    {

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (pc.hitAttacks.Count != 0) {
                Attack atk = pc.hitAttacks.Pop();
                pc.setFanSuccess(atk.m_Releaser.transform.localScale.x, atk.m_Releaser.transform.position.x);
                pc.hitAttacks.Clear();
            }
        }

    }
}
