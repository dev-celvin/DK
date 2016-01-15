using UnityEngine;
using System.Collections.Generic;
using KGCustom.Model;
using System;

namespace KGCustom.Controller {
    public class PlayerAttackEffectController : AttackEffectController
    {
        
        bool playCheck = false;

        void Start() {
            init();
        }
        // Update is called once per frame
        void Update()
        {

            if (!playCheck && Player.instance.curState is Damage)
            {
                playCheck = true;
                GameObject.Destroy(gameObject);

                //switch (m_SkeletonAnimation.AnimationName)
                //{
                //    case "skill_2":
                //        if (m_SkeletonAnimation.state.GetCurrent(0).time < 0.25f) GameObject.Destroy(gameObject);
                //        break;
                //    case "skill_5":
                //        if (m_SkeletonAnimation.state.GetCurrent(0).time < 0.8f) GameObject.Destroy(gameObject);
                //        break;
                //    default:
                //        GameObject.Destroy(gameObject);
                //        break;
                //}
            }
        }

        

		

    }
}

