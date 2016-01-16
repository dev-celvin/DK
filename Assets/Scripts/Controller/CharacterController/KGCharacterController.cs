using KGCustom.Model;
using KGCustom.Model.Character;
using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Controller {
    public abstract class KGCharacterController : MonoBehaviour
    {
        public GameObject HitEffect;
        public Stack<Attack> hitAttacks = new Stack<Attack>();
        public Character character;
        public Pool attackEffectPool;
        public Rigidbody2D rigid2D;
        protected bool initFinished = false;

        protected virtual void init() { }
    }

}

