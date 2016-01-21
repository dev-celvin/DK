using UnityEngine;
using System.Collections.Generic;
using KGCustom.Model;
using System.Collections;

namespace KGCustom.Controller {
    public class PlayerController : KGCharacterController
    {
        public static PlayerController instance;

        public Transform checkGround;
        public Transform rootPos;
        public Transform headPos;
        public Animator m_animator;            //动画机
        public SkeletonGhost skeletonGhost;            //Ghosting
        public AudioSource audioSource;                //音源
        public string curState;
        public float curMoveRate { get; set; }
        public sbyte moveToRun { get; set; }//0代表常规状态，即无需动画过渡，1为走过渡到跑，-1为跑过渡到走
        AnimatorStateInfo m_CurStateInfo;    //动画机状态
        string[] states = {
        "idle", "run", "move", "run_attack", "shift", "jump_standby", "jump_up",
        "jump_flying", "jump_falling", "jump_over", "flying_atk_4", "AttackSelect",
        "atk_1", "atk_2", "atk_3", "atk_4", "atk_over", "SkillSelect", "skill_1",
        "skill_2", "skill_3", "skill_4", "skill_5", "skill_6", "skill_7", "skill_8",
        "def", "def_success", "damage", "damage_over", "fan", "fan_start"
         };

        void Awake() {
            instance = this;
        }

        void Start() {
            character = Player.instance;
            attackEffectPool = PoolManager.instance.GetPoolByType(character.characterType);
            StartCoroutine("CheckGround");
        }

        public AnimatorStateInfo getCurStateInfo()
        {
            return m_CurStateInfo;
        }


        string getCurState()
        {
            for (int i = 0; i < states.Length; i++)
                if (m_CurStateInfo.IsName(states[i]))
                    return states[i];
            return null;
        }
        void Update()
        {
            m_CurStateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
            if (curState == null || !m_CurStateInfo.IsName(curState))
            {
                curState = getCurState();
                changeState();
            }
            if (Player.instance.curState != null)
               Player.instance.curState.execute(this);



            /////////////////JOE镜头示例
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    CameraController.Instance.SetFace(FaceCode.Left);
            //}
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    CameraController.Instance.SetFace(FaceCode.Right);
            //}
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    CameraController.Instance.SetCameraEffect(CameraMode.Shake, 2f, 0.5f);
            //}
            if (Input.GetKeyDown(KeyCode.E))
            {
                CameraController.Instance.SetCameraEffect(CameraMode.Faint, 1f);
            }
            //if (Input.GetKeyDown(KeyCode.O))
            //{
            //    CameraController.Instance.SetCameraEffect(CameraMode.Focus, true, 2f, 1f, 0.5f, this.gameObject);
            //}
            //if (Input.GetKeyDown(KeyCode.P))
            //{
            //    CameraController.Instance.SetCameraEffect(CameraMode.Focus, false, -1f, -1f, -1f, null);
            //}
            if (Input.GetKeyDown(KeyCode.M))
            {
                CameraController.Instance.SetCameraEffect(CameraMode.Break, true, 0.1f, 0.2f);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                CameraController.Instance.SetCameraEffect(CameraMode.Break, false, -1f, -1f);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                iTween.CameraFadeAdd(new Texture2D(100, 100));
                iTween.CameraTexture(Color.white);
                iTween.CameraFadeTo(1f, 2f);
            }

            //if (curMoveRate > 0.9f)
            //{
            //    CameraController.Instance.SetCameraEffect(CameraMode.Blur, true, 2f);
            //}
            //else
            //{
            //    CameraController.Instance.SetCameraEffect(CameraMode.Blur, false, -1f);

            //}
        }


        private void changeState()
        {
            if (Player.instance.curState != null) Player.instance.curState.end(this);
            switch (curState)
            {
                case "idle":
                    Player.instance.curState = Idle.instance;
                    break;
                case "move":
                    Player.instance.curState = Move.instance;
                    break;
                case "run":
                    Player.instance.curState = Run.instance;
                    break;
                case "run_attack":
                    Player.instance.curState = RunAttack.instance;
                    break;
                case "shift":
                    Player.instance.curState = Shift.instance;
                    break;
                case "skill_1":
                    Player.instance.curState = Skill1.instance;
                    break;
                case "skill_2":
                    Player.instance.curState = Skill2.instance;
                    break;
                case "skill_3":
                    Player.instance.curState = Skill3.instance;
                    break;
                case "skill_4":
                    Player.instance.curState = Skill4.instance;
                    break;
                case "skill_5":
                    Player.instance.curState = Skill5.instance;
                    break;
                case "skill_6":
                    Player.instance.curState = Skill6.instance;
                    break;
                case "skill_7":
                    Player.instance.curState = Skill7.instance;
                    break;
                case "skill_8":
                    Player.instance.curState = Skill8.instance;
                    break;
                case "damage":
                    Player.instance.curState = Damage.instance;
                    break;
                case "damage_over":
                    Player.instance.curState = DamageOver.instance;
                    break;
                case "def":
                    Player.instance.curState = Defence.instance;
                    break;
                case "def_success":
                    Player.instance.curState = DefenceSuccess.instance;
                    break;
                case "flying_atk_4":
                    Player.instance.curState = JumpAtk4.instance;
                    break;
                case "jump_up":
                    Player.instance.curState = JumpUp.instance;
                    break;
                case "jump_flying":
                    Player.instance.curState = JumpFlying.instance;
                    break;
                case "jump_falling":
                    Player.instance.curState = JumpFalling.instance;
                    break;
                case "atk_1":
                    Player.instance.curState = Attack1.instance;
                    break;
                case "atk_2":
                    Player.instance.curState = Attack2.instance;
                    break;
                case "atk_3":
                    Player.instance.curState = Attack3.instance;
                    break;
                case "atk_4":
                    Player.instance.curState = Attack4.instance;
                    break;
                case "fan":
                    Player.instance.curState = Fan.instance;
                    break;
                case "fan_start":
                    Player.instance.curState = FanStart.instance;
                    break;
                default:
                    Player.instance.curState = Default.instance;
                    break;
            }
            if (Player.instance.curState != null) Player.instance.curState.begin(this);
        }

        /// <summary>
        /// 设置技能队列
        /// </summary>
        /// <param name="queue"></param>
        //动画状态监测
        public bool CheckState(string state, bool isTag = false)
        {
            if (isTag)
            {
                return m_CurStateInfo.IsTag(state);
            }
            return m_CurStateInfo.IsName(state);
        }

        public bool CheckState(string state, float from, float to, float total)
        {
            if (m_CurStateInfo.IsName(state))
            {
                if (m_CurStateInfo.normalizedTime > (from / total) && m_CurStateInfo.normalizedTime < (to / total))
                {
                    return true;
                }
            }
            return false;
        }
        //受伤状态监测
        public bool IsDamage()
        {
            return m_animator.GetBool("Damage");
        }
        //设置受伤
        public void setDamage(float direction, Vector3 pos)
        {
            transform.localScale = new Vector3(-direction, 1, 1);
            Player.instance.xDirection = (int)-direction;
            m_animator.SetBool("Damage", true);
            GameObject go = PoolManager.instance.GetHitEffectPool().Instantiate();
            go.transform.position = pos;
            go.GetComponent<HitEffect>().PlayHitEffect(2);
        }
        //设置防御成功
        public void setDefenceSuccess(Vector3 pos)
        {
            m_animator.SetTrigger("DefenseSuccess");
            GameObject go = PoolManager.instance.GetHitEffectPool().Instantiate();
            go.transform.position = pos;
            go.GetComponent<HitEffect>().PlayHitEffect(1);
        }
        //设置反打成功
        public void setFanSuccess(float direction, float positionX)
        {
            transform.position = new Vector3(positionX, transform.position.y);
            transform.localScale = new Vector3(-direction, 1, 1);
            Player.instance.xDirection = (int)-direction;
            GameObject atkEffect = attackEffectPool.Instantiate();
            atkEffect.transform.position = transform.position;
            atkEffect.GetComponent<AttackEffectUtility>().m_AttackEffectController.release(this, character.m_skills.getBySkillName("fan"));
            atkEffect.transform.parent = transform;
            m_animator.SetTrigger("FanSuccess");
        }

        //检测着地
        public IEnumerator CheckGround() {
            while (true) {
                if (Physics2D.Linecast(rootPos.position, checkGround.position, 1 << LayerMask.NameToLayer("Ground")))
                {
                    m_animator.SetBool("IsGround", true);
                }
                else {
                    m_animator.SetBool("IsGround", false);
                    if (rigid2D.velocity.y < 0 && !m_animator.GetBool("Damage"))
                        m_animator.Play("jump_falling");
                }
                yield return 0;
            }
        }



        //-------------- Animation Event（动画事件）
        public void MoveStart(float speed)
        {
            transform.Translate(Player.instance.xDirection * speed * Time.deltaTime * Vector3.right);
        }

        public void MoveStop()
        {
            transform.Translate(Player.instance.xDirection * 0 * Time.deltaTime * Vector3.right);
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        public void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
        public void CameraFocusOn()
        {
            CameraController.Instance.SetCameraEffect(CameraMode.Focus, true, 2f, 1f, 0.5f, this.gameObject);
        }

        public void CameraFocusOff()
        {
            CameraController.Instance.SetCameraEffect(CameraMode.Focus, false, -1f, -1f, -1f, null);
        }
    }
}

