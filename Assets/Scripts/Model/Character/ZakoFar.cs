using Global;
using System.Collections.Generic;
using KGCustom.Controller;

namespace KGCustom.Model.Character.Enemy
{
    public class ZakoFar : Character
    {
        public ZakoFar()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 100;
            hpMax = 100;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.ZakoFar;
            m_skills.skillList = new List<AttackEffect>()
            {
                new AttackEffect("atk_far", 5, 2.5f, 0, 1000, 1, 3),
         };
        }

    }

}

