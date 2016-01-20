using UnityEngine;
[System.Serializable]
public class AttackEffect
{

    public string name { set; get; }
    public float damageValue { set; get; }
    public float damageRange { get; set; }
    public float vRange { set; get; }//垂直方向攻击范围
    public float hRange { get; set; }//水平方向攻击范围
    public float timeScale { get; set; }
    public float costMP { get; set; }
    public float lastUsedTime = -100;
    public float cd { get; set; }
    public float stoppableTime;
    public AttackEffect(string name, float damageValue, float damageRange, float vRange, float hRange, float costMP, float cd,  float timeScale = 1.0f, float stoppableTime = 1000)
    {
        this.name = name;
        this.damageValue = damageValue;
        this.damageRange = damageRange;
        this.timeScale = timeScale;
        this.costMP = costMP;
        this.cd = cd;
        this.vRange = vRange;
        this.hRange = hRange;
        this.stoppableTime = stoppableTime;
    }

    public float getDamageValue()
    {
        return damageValue + Random.Range(-damageRange, damageRange);
    }

    public float getSkillReadyTime()
    {
        return (Time.time - lastUsedTime < cd) ? (cd + lastUsedTime - Time.time) : 0;
    }

    public bool IsAvailable() {
        if(Time.time - lastUsedTime < cd)
        return false;
        return true;
    }

    public void CDReset()
    {
        lastUsedTime = Time.time;
    }

}