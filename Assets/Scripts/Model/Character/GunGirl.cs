using Global;

namespace KGCustom.Model.Character.Enemy {
    public class GunGirl : Character
    {

        static GunGirl m_GunGirl = null;

        public GunGirl()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 200;
            hpMax = 200;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.GunGirl;
            m_skills.skillList = new System.Collections.Generic.List<AttackEffect>()
            {
                new AttackEffect("atk_1", 5, 2.5f, 0.532f, 9.0f, 0, 10, 1f),
                new AttackEffect("atk_2", 5, 2.5f, 0.532f, 4.38f, 0, 15, 1f),
                new AttackEffect("atk_3", 5, 2.5f, 0.532f, 7.54f, 0, 20, 1f),
         };
        }

        public static GunGirl instance
        {
            get
            {
                if (m_GunGirl == null)
                {
                    m_GunGirl = new GunGirl();
                }
                return m_GunGirl;
            }
        }
    }

}

