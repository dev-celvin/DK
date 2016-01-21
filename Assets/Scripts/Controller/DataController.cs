using KGCustom.Model;
using UnityEngine;

namespace KGCustom.Controller
{
    public class DataController : MonoSingleton<DataController>
    {

        public float JumpPower;
        public float RunSpeed;
        public float ShiftSpeed;

        public float Skill1Speed;
        public float Skill2Speed;
        public float Skill3Speed;
        public float Skill4Speed;
        public float Skill5Speed;
        public float Skill6Speed;
        public float Skill7Speed;
        public float Skill8Speed;

        public float NormolAttack1Speed;
        public float NormolAttack2Speed;
        public float NormolAttack3Speed;
        public float NormolAttack4Speed;

        public AnimationCurve NormolAttack1AnimationCurve;
        public AnimationCurve NormolAttack2AnimationCurve;
        public AnimationCurve NormolAttack3AnimationCurve;
        public AnimationCurve NormolAttack4AnimationCurve;

        public AnimationCurve Skill1AnimCurve;
        public AnimationCurve Skill2AnimCurve;
        public AnimationCurve Skill3AnimCurve;
        public AnimationCurve Skill4AnimCurve;
        public AnimationCurve Skill5AnimCurve;
        public AnimationCurve Skill6AnimCurve;
        public AnimationCurve Skill7AnimCurve;
        public AnimationCurve Skill8AnimCurve;

        // Use this for initialization
        void Start()
        {
            JumpPower = JumpUp.instance.yTransfer;
            RunSpeed = Run.instance.xTransfer;
            ShiftSpeed = Shift.instance.xTransfer;
            Skill1.instance.xTransfer = Skill1Speed;
            Skill2.instance.xTransfer = Skill2Speed;
            Skill3.instance.xTransfer = Skill3Speed;
            Skill4.instance.xTransfer = Skill4Speed;
            Skill5.instance.xTransfer = Skill5Speed;
            Skill6.instance.xTransfer = Skill6Speed;
            Skill7.instance.xTransfer = Skill7Speed;
            Skill8.instance.xTransfer = Skill8Speed;
            Attack1.instance.xTransfer = NormolAttack1Speed;
            Attack2.instance.xTransfer = NormolAttack2Speed;
            Attack3.instance.xTransfer = NormolAttack3Speed;
            Attack4.instance.xTransfer = NormolAttack4Speed;
        }

        // Update is called once per frame
        void Update()
        {
            //实时更新用
            JumpUp.instance.yTransfer = JumpPower;
            Run.instance.xTransfer = RunSpeed;
            Shift.instance.xTransfer = ShiftSpeed;
            Skill1.instance.xTransfer = Skill1Speed;
            Skill2.instance.xTransfer = Skill2Speed;
            Skill3.instance.xTransfer = Skill3Speed;
            Skill4.instance.xTransfer = Skill4Speed;
            Skill5.instance.xTransfer = Skill5Speed;
            Skill6.instance.xTransfer = Skill6Speed;
            Skill7.instance.xTransfer = Skill7Speed;
            Skill8.instance.xTransfer = Skill8Speed;
            Attack1.instance.xTransfer = NormolAttack1Speed;
            Attack2.instance.xTransfer = NormolAttack2Speed;
            Attack3.instance.xTransfer = NormolAttack3Speed;
            Attack4.instance.xTransfer = NormolAttack4Speed;

            //
            Attack1.instance.animCurve = NormolAttack1AnimationCurve;
            Attack2.instance.animCurve = NormolAttack2AnimationCurve;
            Attack3.instance.animCurve = NormolAttack3AnimationCurve;
            Attack4.instance.animCurve = NormolAttack4AnimationCurve;

            //
            Skill1.instance.animCurve = Skill1AnimCurve;
            Skill2.instance.animCurve = Skill2AnimCurve;
            Skill3.instance.animCurve = Skill3AnimCurve;
            Skill4.instance.animCurve = Skill4AnimCurve;
            Skill5.instance.animCurve = Skill5AnimCurve;
            Skill6.instance.animCurve = Skill6AnimCurve;
            Skill7.instance.animCurve = Skill7AnimCurve;
            Skill8.instance.animCurve = Skill8AnimCurve;
        }
    }
}

