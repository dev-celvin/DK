using Global;
using System.Collections.Generic;
using KGCustom.Controller;

namespace KGCustom.Model.Character.Enemy
{
    public class Zako : Character
    {
        public Zako()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 200;
            hpMax = 200;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.Zako;
            m_skills.skillList = new List<AttackEffect>()
            {
                new AttackEffect("atk", 5, 2.5f, 0.532f, 2.6f, 0, 5, 1f),
         };
        }

    }

}

