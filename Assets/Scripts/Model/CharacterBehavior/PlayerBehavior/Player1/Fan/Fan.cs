
using KGCustom.Controller;

namespace KGCustom.Model {
    public class Fan : PlayerBehavior<Fan>
    {

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (pc.hitAttacks.Count != 0) {
                Attack atk = pc.hitAttacks.Pop();
                pc.setFanSuccess(atk.releaser.transform.localScale.x, atk.releaser.transform.position.x);
                pc.hitAttacks.Clear();
            }
        }

    }
}
