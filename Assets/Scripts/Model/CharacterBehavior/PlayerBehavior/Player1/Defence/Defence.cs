using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Defence : PlayerBehavior<Defence>
    {
        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.m_animator.SetBool("Damage", false);
        }
        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (pc.hitAttacks.Count != 0) {
                Attack atk = pc.hitAttacks.Pop();
                pc.setDefenceSuccess(atk.hitPos);
                pc.hitAttacks.Clear();
                return;
            }
#if UNITY_STANDALONE_WIN
            if (Input.GetKeyUp(KeyCode.K))
            {
                    pc.m_animator.SetBool("IsDefense", false);
            }
#else
				if (!KeyManager.instance.GetKeyMessageUp(KeyManager.KeyCode.Attack))
                {
                    pc.m_animator.SetBool("IsDefense", false);
                }
#endif
        }
        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            base.end(pc);
        }

    }
}
