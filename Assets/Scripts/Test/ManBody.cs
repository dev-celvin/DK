using UnityEngine;
using KGCustom.Controller;

public class ManBody : MonoBehaviour
{
    public AudioClip run_atk_attacked;
    private static ManController m_ManController;
    private static PlayerController m_PlayerController;
    private int attackHash = 0;
    void Awake()
    {
        if (m_ManController == null)
        {
            GameObject Girl = GameObject.FindGameObjectWithTag("Man");
            if (Girl != null)
            {
                m_ManController = Girl.GetComponent<ManController>();
            }
            else Debug.Log("GameObject(Player) not found in HitInspector.cs:start()!");
        }
        if (m_PlayerController == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                m_PlayerController = player.GetComponent<PlayerController>();
            }
            else Debug.Log("GameObject(Player) not found in HitInspector.cs:start()!");
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "PlayerAttack")
        {
            if (m_ManController != null)
            {
                if (!m_ManController.IsDamage() && attackHash == 0)
                {
                    if (m_PlayerController.CheckState("run_attack"))
                    {
                        m_ManController.AttackMove_Speed = 10.0f;
                        m_PlayerController.PlaySoundOneShot(run_atk_attacked);
                        attackHash = 1;
                    }
                    else if (m_PlayerController.CheckState("atk_2"))
                    {
                        m_ManController.AttackMove_Speed = 0.2f;
                    }
                    else if (m_PlayerController.CheckState("atk_3"))
                    {
                        m_ManController.AttackMove_Speed = 0.3f;
                    }
                    else if (m_PlayerController.CheckState("atk_4"))
                    {
                        m_ManController.AttackMove_Speed = 0.5f;
                    }
                    else if (m_PlayerController.CheckState("skill_2"))
                    {
                        m_ManController.AttackMove_Speed = 0.5f;
                    }
                    else if (m_PlayerController.CheckState("skill_3"))
                    {
                        m_ManController.AttackMove_Speed = 2.0f;
                    }
                    else if (m_PlayerController.CheckState("skill_5"))
                    {
                        m_ManController.AttackMove_Speed = 3.0f;
                    }
                    else if (m_PlayerController.CheckState("skill_6"))
                    {
                        m_ManController.AttackMove_Speed = 2.0f;
                    }
                    else
                    {
                        m_ManController.AttackMove_Speed = 0.0f;
                    }

                }
            }
            else Debug.Log("m_ManController not found in HitInspector.cs:OnTriggerEnter2D");
        }
    }

    void Update()
    {
        if (attackHash != 0 && m_PlayerController.CheckState("idle"))
        {
            attackHash = 0;
        }
    }
}
