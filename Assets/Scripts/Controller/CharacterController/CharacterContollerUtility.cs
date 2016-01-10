
using KGCustom.Model;
using KGCustom.Model.Character;
using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Controller
{
    public class EffectPoolManager
    {
        //The dic to find the pool of attack effect gameobject
        private static Dictionary<CharacterType, Pool> AEPoolDic = new Dictionary<CharacterType, Pool>();
        public static Pool GetAttackEffectPoolByType(CharacterType ctype) {
            if (!AEPoolDic.ContainsKey(ctype)) {
                Pool aePool = new Pool(ctype, Pool.PoolType.AttackEffectPool);
                AEPoolDic.Add(ctype, aePool);
                return aePool;
            }
            return AEPoolDic[ctype];
        }
    }
}
