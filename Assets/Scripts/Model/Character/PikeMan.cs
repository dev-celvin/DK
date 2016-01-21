using Global;
using System.Collections.Generic;
using KGCustom.Controller;

namespace KGCustom.Model.Character.Enemy
{
    public class PikeMan : Character
    {
        static PikeMan m_PikeMan = null;
        
        public PikeMan()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 400;
            hpMax = 400;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.PikeMan;
            m_skills.skillList = new List<AttackEffect>()
            {
                new AttackEffect("atk_1", 5, 2.5f, 0.532f, 4.0f, 0, 8, 1f),
                new AttackEffect("atk_2", 5, 2.5f, 0.532f, 6.62f, 0, 15, 1f),
         };
        }

        public static PikeMan instance
        {
            get
            {
                if (m_PikeMan == null)
                {
                    m_PikeMan = new PikeMan();
                }
                return m_PikeMan;
            }
        }
    }

}

