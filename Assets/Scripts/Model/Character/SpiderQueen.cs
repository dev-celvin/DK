using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Global;

namespace KGCustom.Model.Character.Enemy
{
    public class SpiderQueen : Character
    {
        static SpiderQueen m_SpiderQueen = null;

        public SpiderQueen()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 300;
            hpMax = 300;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.SpiderQueen;
            m_skills.skillList = new List<AttackEffect>()
            {
                new AttackEffect("atk_1", 5, 2.5f, 0.532f, 2.9f, 0, 20, 1f),
                new AttackEffect("atk_2", 5, 2.5f, 0.532f, 3.45f, 0, 30, 1f),
                new AttackEffect("atk_3", 5, 2.5f, 0.532f, 3.86f, 0, 15, 1f),
                new AttackEffect("atk_4", 5, 2.5f, 0.532f, 9.6f, 0, 40, 1f),
         };
        }
        public static SpiderQueen instance
        {
            get
            {
                if (m_SpiderQueen == null)
                {
                    m_SpiderQueen = new SpiderQueen();
                }
                return m_SpiderQueen;
            }
        }
    }

}