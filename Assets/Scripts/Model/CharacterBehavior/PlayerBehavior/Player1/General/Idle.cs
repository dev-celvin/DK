using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class Idle : PlayerBehavior<Idle>
    {
        float defCountDown = 0;
        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if(damageCount(pc))return;
            moveableExecute(pc);
            nextToAttackExecute(pc);
//#if UNITY_STANDALONE_WIN
//            if (Input.GetKey(KeyCode.K))
//            {
//                defCountDown++;
//                if (defCountDown >= 8.0f)
//                {
//                    pc.m_animator.SetBool("IsDefense", true);
//                }
//            }
//#else
//                if (KeyManager.instance.GetKeyMessage(KeyManager.KeyCode.Attack))
//                {
//                    defCountDown++;
//                    if (defCountDown >= 8.0f)
//                    {
//                        pc.m_animator.SetBool("IsDefense", true);
//                    }
//                }
//#endif
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            defCountDown = 0;
            pc.m_animator.SetBool("IsDefense", false);
        }

    }
}
