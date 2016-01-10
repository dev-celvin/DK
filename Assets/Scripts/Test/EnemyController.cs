using UnityEngine;
using System.Collections;


public enum ENEMYAISTS //-----敌人AI State------
{
    /// <summary>
    /// Action选择（思考）
    /// </summary>
    ACTIONSELECT,
    /// <summary>
    /// 等待
    /// </summary>
    WAIT,   
    /// <summary>
    /// 向玩家移动
    /// </summary>     
    MOVETOPLAYER,
    /// <summary>
    /// 跳向玩家
    /// </summary>
    JUMPTOPLAYER,
    /// <summary>
    /// 逃离玩家
    /// </summary>
    ESCAPE,
    /// <summary>
    /// 不移动立即攻击（远距离攻击用）
    /// </summary>
    ATTACKONSIGHT,
    /// <summary>
    /// 行动停止（但是移动处理继续）
    /// </summary>
    FREEZ,
}
public class EnemyController : MonoBehaviour {


    public GameObject EffectGameObject;
    public GameObject HitEffect;
    public Transform HitEffectTransform;
    protected Animator mAnimator;
    protected AnimatorStateInfo current_stateInfo;
    protected bool toAttack = true;//是否首次进入攻击状态
    protected float direction = 1.0f;
    public float AttackMove_Speed = 0.0f;
    protected virtual void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        current_stateInfo = mAnimator.GetCurrentAnimatorStateInfo(0); 
        //受伤
        if (current_stateInfo.IsTag("Damage"))
        {
            mAnimator.SetBool("Damage", false);
            SetAttackMove(AttackMove_Speed);
        }
    }
    public void PlayManEffect(int type)
    {
        GameObject atkEffect = (GameObject)Instantiate(EffectGameObject, transform.position, EffectGameObject.transform.rotation);
        atkEffect.GetComponent<ManEffect>().setEffect(type, transform.localScale.x);
        atkEffect.transform.parent = transform.parent;
    }
    public void PlayGirlEffect(int type)
    {
        GameObject atkEffect = (GameObject)Instantiate(EffectGameObject, transform.position, EffectGameObject.transform.rotation);
        atkEffect.GetComponent<GirlEffect>().setEffect(type, transform.localScale.x);
        atkEffect.transform.parent = transform.parent;
    }
    //受伤状态监测
    public bool IsDamage()
    {
        return mAnimator.GetBool("Damage");
    }
    public virtual void SetDamage(float direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);
        this.direction = direction;
        mAnimator.SetBool("Damage", true);
        GameObject go = (GameObject)Instantiate(HitEffect, HitEffectTransform.position, HitEffect.transform.rotation);
        go.GetComponent<HitEffect>().PlayHitEffect(3);
    }

    protected void SetAttackMove(float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime * Vector3.right);
    }
    

}
