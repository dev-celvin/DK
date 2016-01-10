using UnityEngine;
[System.Serializable]
public class AttackEffect
{

    public string name { set; get; }
    public float damageValue { set; get; }
    public float damageRange { get; set; }
    public float nRange { set; get; }//反方向攻击范围
    public float pRange { get; set; }//正方向攻击范围
    public float timeScale { get; set; }
    public float costMP { get; set; }
    public float lastUsedTime { get; set; }
    public float cd { get; set; }
    
    

    public AttackEffect(string name, float damageValue, float damageRange, float nRange, float pRange, float costMP = 10, float cd = 1.0f,  float timeScale = 1.0f )
    {
        this.name = name;
        this.damageValue = damageValue;
        this.damageRange = damageRange;
        this.timeScale = timeScale;
        this.costMP = costMP;
        this.cd = cd;
        this.nRange = nRange;
        this.pRange = pRange;
    }

    public float getDamageValue()
    {
        return damageValue + Random.Range(-damageRange, damageRange);
    }

    public float getSkillReadyTime()
    {
        return (Time.time - lastUsedTime < cd && lastUsedTime != 0) ? (cd + lastUsedTime - Time.time) : 0;
    }

    public bool IsAvailable() {
        if(Time.time - lastUsedTime < cd && lastUsedTime != 0)
        return false;
        return true;
    }

    public void CDReset()
    {
        lastUsedTime = Time.time;
    }

}