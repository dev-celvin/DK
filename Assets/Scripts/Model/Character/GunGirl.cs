using Global;

namespace KGCustom.Model.Character.Enemy {
    public class GunGirl : Character
    {
        public GunGirl()
        {
            xDirection = -Player.instance.xDirection;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 100;
            hpMax = 100;
            mp = 100;
            mpMax = 100;
            characterType = CharacterType.GunGirl;
            m_skills.skillList = new System.Collections.Generic.List<AttackEffect>()
            {
                new AttackEffect("atk_1", 5, 2.5f, 0.532f, 0f, 20f, 1, 1.5f),
                new AttackEffect("atk_2", 5, 2.5f, 0.532f, 0, 20f, 1, 1.5f),
                new AttackEffect("atk_3", 5, 2.5f, 0.532f, 0f, 10f, 1, 1.5f),
         };
        }

    }

}

