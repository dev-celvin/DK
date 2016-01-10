using UnityEngine;
using System.Collections;

namespace KGCustom.Controller
{
    public class LightControl : MonoBehaviour
    {
        public GameObject[] m_light;
        public SpriteRenderer moon;
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < m_light.Length; i++)
            {

                StartCoroutine(WaitAndPrint(i, Random.Range(0, 1f)));
            }
        }

        IEnumerator WaitAndPrint(int i, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            m_light[i].SetActive(true);
        }

        bool isUp = false;
        float t = 1f;
        float count = 3f;
        void Update()
        {
            count -= Time.deltaTime;
            if (count < 0)
            {
                if (isUp)
                {
                    t += Time.deltaTime * 2f;
                    if (t > 1f)
                    {
                        isUp = false;
                        count = 3f;
                    }
                }
                else
                {
                    t -= Time.deltaTime * 2f;
                    if (t < 0f)
                    {
                        isUp = true;
                    }
                }
                moon.color = new Color(1, 1, 1, Mathf.Lerp(0.8f, 1f, t));
            }
        }

    }
}

