using Global;
using KGCustom.Model;
using KGCustom.Model.Character;
using System;
using UnityEngine;

public class Player : Character {

    public float rage { get; set; }
    public float rageMax { get; set; }

    

    public float moveDragRate {
        get; set;
    }

    static Player m_Player = null;

    private Player(){
        xDirection = GlobalValue.XDIRECTION_RIGHT;
        yDirection = GlobalValue.YDIRECTION_UP;
        hp = 100;
        hpMax = 100;
        mp = 100;
        mpMax = 100;
        m_skills.skillList = new System.Collections.Generic.List<AttackEffect>() {
            new AttackEffect("atk_1", 5, 2.5f, 0.532f, 1.92f, 10, 1, 1.5f),
            new AttackEffect("atk_2", 5, 2.5f, 0.168f, 1.737f, 10, 1, 1.3f),
            new AttackEffect("atk_3", 5, 2.5f, 0.855f, 2.041f, 10, 1, 1.1f),
            new AttackEffect("atk_4", 5, 2.5f, 0.197f, 2.721f),
            new AttackEffect("skill_1", 5, 2.5f, 0.345f, 3.085f),
            new AttackEffect("skill_2", 5, 2.5f, 0.018f, 2.314f),
            new AttackEffect("skill_3", 5, 2.5f, 0, 3.62f),
            new AttackEffect("skill_4", 5, 2.5f, 1.268f, 2.674f),
            new AttackEffect("skill_5", 5, 2.5f, 0.891f, 4.84f),
            new AttackEffect("skill_6", 5, 2.5f, 0.983f, 3.78f),
            new AttackEffect("skill_7", 5, 2.5f, 0.256f, 9.46f),
            new AttackEffect("skill_8", 5, 2.5f, 0.898292f, 4.461f),
            new AttackEffect("run_atk", 5, 2.5f, 0.1f, 0.1f),
            new AttackEffect("fly_atk_4", 5, 0.166f, 0.898292f, 0.91f),
            new AttackEffect("fan", 0, 0, 0, 0)
        };
        characterType = CharacterType.Player;
    }

    public static Player instance {
        get {
            if (m_Player == null)
            {
                m_Player = new Player();
            }
            return m_Player;
        }
    }

    public float getNextSkillReadyTime()
    {
        int num = PlayerAttack.instance.skillAction[PlayerAttack.instance.skillIndex];
        if (num < 100) return 1;
        else
        {
            AttackEffect ae = m_skills.getBySkillName("skill_" + Convert.ToString(num % 100));
            if (Time.time - ae.lastUsedTime < ae.cd && ae.lastUsedTime != 0) return (Time.time - ae.lastUsedTime) / ae.cd;
            else return 1;
        }
    }
}
