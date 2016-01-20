using KGCustom.Model;
using KGCustom.Model.Character;
using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Controller {
    public abstract class KGCharacterController : MonoBehaviour
    {
        public Stack<Attack> hitAttacks = new Stack<Attack>();
        public Character character;
        public Pool attackEffectPool;
        public Rigidbody2D rigid2D;
        protected List<AttackEffectController> stopEffectList = new List<AttackEffectController>();
        protected bool initFinished = false;

        protected virtual void init() { }

        public void StopRunningEffect()
        {
            for (int i = 0; i < stopEffectList.Count; i++)
            {
                stopEffectList[i].TryStopEffect();
            }
            stopEffectList.Clear();
        }

        public void TryPushAtkEffect(AttackEffectController aeCtrl)
        {
            if (aeCtrl.CanStop) stopEffectList.Add(aeCtrl);
        }

        public void RemoveAtkEffect(AttackEffectController aeCtrl) {
            stopEffectList.Remove(aeCtrl);
        }
    }

}

