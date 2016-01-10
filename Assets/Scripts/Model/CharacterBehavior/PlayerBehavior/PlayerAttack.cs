using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Model {
    public class PlayerAttack
    {
        public List<int> skillAction = null;
        public List<int> normalAction = null;
        public int runAttack { get; set; }
        public float chagneComboTime { get; set; }
        public bool combo{get; set;}
        public int skillIndex{get; set;}
        public int normalIndex{get; set;}
        static PlayerAttack m_PlayerAttack;
        public static PlayerAttack instance
        {
            get
            {
                if (m_PlayerAttack == null) m_PlayerAttack = new PlayerAttack();
                return m_PlayerAttack;
            }
        }

		public int getCurSkill() {
			return skillAction[(skillIndex + skillAction.Count - 1) % skillAction.Count];
		}
		public int getNextSkill() {
			return skillAction[skillIndex];
		}

		private PlayerAttack()
        {
            combo = false;
            chagneComboTime = -1;
            skillIndex = 0;
            normalIndex = 0;
            normalAction = new List<int>();
            skillAction = new List<int>();
            setNormalQueue(new int[]{1, 2, 3, 4 });
            setSkillQueue(new int[] { 107, 102, 103, 104, 105, 106, 107, 108 });
        }

        public void setSkillQueue(int[] queue)
        {
            if(skillAction.Count != 0)skillAction.Clear();
            skillIndex = 0;
            for (int i = 0; i < queue.Length; i++)
            {
                skillAction.Add(queue[i]);
            }
            chagneComboTime = Time.time;
        }

        public void setNormalQueue(int[] queue)
        {
            if(normalAction.Count != 0)normalAction.Clear();
            normalIndex = 0;
            for (int i = 0; i < queue.Length; i++)
            {
                normalAction.Add(queue[i]);
            }
        }

    }
}
