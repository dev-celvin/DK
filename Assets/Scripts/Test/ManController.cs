using UnityEngine;
using System.Collections;

public class ManController : EnemyController
{	
	// Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //if (!current_stateInfo.IsTag("Damage"))
        //{
        //    if (toAttack)
        //    {
        //        if (current_stateInfo.IsName("atk_1"))
        //        {
        //            PlayManEffect(1);
        //        }
        //        toAttack = false;
        //    }
        //    if (current_stateInfo.IsName("idle"))
        //    {
        //        mAnimator.SetTrigger("Attack_1");
        //        toAttack = true;
        //    }
        //}

    }
}
