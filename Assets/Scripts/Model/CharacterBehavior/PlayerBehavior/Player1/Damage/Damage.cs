using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Damage : PlayerBehavior<Damage>
    {
        public bool flyHit = false;
        public override void init()
        {
            xTransfer = 2;
            yTransfer = 15;
        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.transform.Translate(-Player.instance.xDirection * xTransfer * Time.deltaTime * Vector3.right);
            if (flyHit && pc.m_animator.GetBool("IsGround"))
                pc.m_animator.Play("damage_over");
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (!pc.m_animator.GetBool("IsGround"))
                flyHit = true;
            else flyHit = false;
            pc.StopSound();
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.m_animator.SetBool("Damage", false);
        }

    }
}
