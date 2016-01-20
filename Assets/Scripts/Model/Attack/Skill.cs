using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Model {

    public class Skill
    {

        public List<AttackEffect> skillList;

        public AttackEffect getBySkillName(string skillName) {
            for (int i = 0; i < skillList.Count; i++) {
                if (skillList[i].name == skillName) {
                    return skillList[i];
                }
            }
            return null;
        }

        public AttackEffect GetRandomAttack(float dis) {
            List<AttackEffect> aes = null;
            for (int i = 0; i < skillList.Count; i++) {
                if (skillList[i].hRange >= dis && skillList[i].IsAvailable()) {
                    if (aes == null) aes = new List<AttackEffect>();
                    aes.Add(skillList[i]);
                } 
            }
            if (aes == null)
            {
                return null;
            }
            else if(aes.Count == 0)return null;
            return aes[Random.Range(0, aes.Count - 1)];

        }


    }

}

