using UnityEngine;

namespace KGCustom.Model.Character {
[System.Serializable]
    public class Character
    {

        public float hp { get; set; }
        public float hpMax { get; set; }
        public float mp { get; set; }
        public float mpMax { get; set; }
        public float atk { get; set; }
        public float atkRange { get; set; }
        public float critCoefficient { get; set; }
        public float critRange { get; set; }
        public float critProbability { get; set; }
        public float def { get; set; }
        public float spd { get; set; }
        public float mpRestoreSpeed { get; set; }
        public int xDirection { get; set; }
        public int yDirection { get; set; }

        [HideInInspector]
        public CharacterType characterType;
        [HideInInspector]
        public Skill m_skills = new Skill();

        public CharacterBehavior curState ;

    }
}

