using UnityEngine;
using KGCustom.Model;
using System.Collections;

namespace KGCustom.Controller {
    public class AttackObjectController : AttackController
    {
        public float FlySpeed = 0;
        public float DisappearTime = 3f;
        private sbyte _direction;
        public sbyte direction {
            get { return _direction; }
            set {
                _direction = value;
                transform.localScale -= Vector3.right * (transform.localScale.x + direction * transform.localScale.x);
            }
        }
        public AttackObjectType aoType;

        public void StartFlyForward() {
            StartCoroutine("FlyForward");
        }
        IEnumerator FlyForward() {
            while (true) {
                transform.Translate(Vector2.right * m_attack.direction * FlySpeed * Time.deltaTime);
                yield return 0;
            }
        }
        public void StopFly() {
            StopCoroutine("FlyForward");
        }

        void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.layer == LayerMask.NameToLayer("Ground") || col.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
                GetComponent<Collider2D>().enabled = false;
                StopFly();
                StartCoroutine(StartDisappear(DisappearTime));
            }
        }

        IEnumerator StartDisappear(float time) {
            Material mat = GetComponent<Renderer>().material;
            Color tColor = mat.color;
            while (time > 0) {
                tColor.a = Mathf.Lerp(0, 1, time / DisappearTime);
                mat.color = tColor;
                time -= Time.deltaTime;
                yield return 0;
            }
            PoolManager.instance.GetPoolByType(aoType).Push(gameObject);
            
        }
    }
}

