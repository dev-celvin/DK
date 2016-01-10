using KGCustom.Controller;
using UnityEngine;

namespace KGCustom.Model {
    public class JumpAtk4 : PlayerBehavior<JumpAtk4>
    {

        public override void init()
        {
            yTransfer = 2.0f;

        }

        public override void execute(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            if (damageCount(pc)) return;
            //fallingExecute(pc);
            pc.transform.Translate(xTransfer * Time.deltaTime * Vector3.right);
        }

        public override void begin(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            pc.m_animator.SetBool("JumpAttack", false);
            Player.instance.yDirection = Global.GlobalValue.YDIRECTION_DOWN;
            GameObject atkEffect = (GameObject)GameObject.Instantiate(pc.AttackEffect, pc.transform.position, pc.AttackEffect.transform.rotation);
            atkEffect.GetComponent<AttackEffectUtility>().m_AttackEffectController.release(pc, pc.character.m_skills.getBySkillName("fly_atk_4"));
            atkEffect.transform.parent = pc.transform;
            pc.m_animator.SetInteger("AttackAction", 0);
            pc.m_animator.SetInteger("SkillAction", 0);
            pc.StopCoroutine("CheckGround");
        }

        public override void end(KGCharacterController cc)
        {
            PlayerController pc = (PlayerController)cc;
            Player.instance.yDirection = Global.GlobalValue.YDIRECTION_UP;
            pc.StartCoroutine("CheckGround");
        }

    }
}
