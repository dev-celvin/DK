using KGCustom.Model.Character;
using System.Collections.Generic;
using UnityEngine;

namespace KGCustom.Model
{
    public class Pool
    {
        public Pool(CharacterType ctype, PoolType ptype) {
            switch (ptype) {
                case PoolType.AttackEffectPool:
                    switch (ctype)
                    {
                        case CharacterType.PikeMan:
                            m_pref = (GameObject)Resources.Load("Prefab/AttackEffect/pike_effect");
                            break;
                        case CharacterType.GunGirl:
                            m_pref = (GameObject)Resources.Load("Prefab/AttackEffect/gungirl_effect");
                            break;
                        case CharacterType.SpiderQueen:
                            m_pref = (GameObject)Resources.Load("Prefab/AttackEffect/SpiderQueen_effect");
                            break;
                        case CharacterType.Zako:
                            m_pref = (GameObject)Resources.Load("Prefab/AttackEffect/Zako_effect");
                            break;
                        case CharacterType.ZakoFar:
                            m_pref = (GameObject)Resources.Load("Prefab/AttackEffect/syuriken");
                            break;
                    }
                    break;
                case PoolType.HitEffectPool:
                    break;
            }

            
        }

        private LinkedList<GameObject> pool = new LinkedList<GameObject>();
        private GameObject m_pref;
        public GameObject Instantiate() {
            GameObject go = null;
            if (pool.Count == 0)
            {
                go = (GameObject)GameObject.Instantiate(m_pref, new Vector2(1000, 1000), m_pref.transform.rotation);
                return go;
            }
            else {
                go = pool.First.Value;
                go.SetActive(true);
                pool.RemoveFirst();
                return go;
            }
        }

        public void Push(GameObject go) {
            go.transform.position = Vector2.one * 1000;
            go.transform.rotation = Quaternion.identity;
            go.SetActive(false);
            pool.AddLast(go);
        }

        public enum PoolType {
            AttackEffectPool,
            HitEffectPool,
        }
    }
}
