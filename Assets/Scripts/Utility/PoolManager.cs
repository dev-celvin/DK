using UnityEngine;
using KGCustom.Model;
using KGCustom.Model.Character;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager instance {
        get { return _instance; }
    }
    void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        Pool temp = GetPoolByType(CharacterType.Player_1);
        temp.Push(temp.Instantiate());
    }
    //The dic to find the pool of attack effect gameobject
    private Dictionary<CharacterType, Pool> AEPoolDic = new Dictionary<CharacterType, Pool>();
    private Dictionary<AttackObjectType, Pool> AObjectDic = new Dictionary<AttackObjectType, Pool>();
    private Pool hitPool;
    public Pool GetPoolByType(CharacterType ctype)
    {
        if (!AEPoolDic.ContainsKey(ctype))
        {
            Pool aePool = new Pool(ctype, Pool.PoolType.AttackEffectPool);
            AEPoolDic.Add(ctype, aePool);
            return aePool;
        }
        return AEPoolDic[ctype];
    }

    public Pool GetHitEffectPool()
    {
        if (hitPool == null) hitPool = new Pool(CharacterType.General, Pool.PoolType.HitEffectPool);
        return hitPool;
    }

    public Pool GetPoolByType(AttackObjectType aotype) {
        if (!AObjectDic.ContainsKey(aotype)) {
            Pool aoPool = new Pool(aotype);
            AObjectDic.Add(aotype, aoPool);
            return aoPool;
        }
        return AObjectDic[aotype];
    }
}
