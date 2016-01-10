using UnityEngine;
using KGCustom.Controller;

public class GirlBody : MonoBehaviour {
    public AudioClip run_atk_attacked;
    private static PlayerController m_PlayerController;
    private static GirlController m_GirlController;
    private int attackHash = 0;
	void Awake () {
        if (m_GirlController == null)
        {
            GameObject Girl = GameObject.FindGameObjectWithTag("Girl");
            if (Girl != null)
            {
                m_GirlController = Girl.GetComponent<GirlController>();
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
            if (m_GirlController != null)
            {
                if (!m_GirlController.IsDamage() && attackHash == 0)
                {
                    if (m_PlayerController.CheckState("run_attack"))
                    {
                        m_GirlController.AttackMove_Speed = 10.0f;
                        m_PlayerController.PlaySoundOneShot(run_atk_attacked);
                        attackHash = 1;
                    }
                    else if (m_PlayerController.CheckState("atk_2"))
                    {
                        m_GirlController.AttackMove_Speed = 0.1f;
                    }
                    else if (m_PlayerController.CheckState("atk_3"))
                    {
                        m_GirlController.AttackMove_Speed = 0.2f;
                    }
                    else if (m_PlayerController.CheckState("atk_4"))
                    {
                        m_GirlController.AttackMove_Speed = 0.5f;
                    }
                    else if (m_PlayerController.CheckState("skill_2"))
                    {
                        m_GirlController.AttackMove_Speed = 0.5f;
                    }
                    else if (m_PlayerController.CheckState("skill_3"))
                    {
                        m_GirlController.AttackMove_Speed = 2.0f;
                    }
                    else if (m_PlayerController.CheckState("skill_5"))
                    {
                        m_GirlController.AttackMove_Speed = 2.0f;
                    }
                    else if (m_PlayerController.CheckState("skill_6"))
                    {
                        m_GirlController.AttackMove_Speed = 1.0f;
                    }
                    else
                    {
                        m_GirlController.AttackMove_Speed = 0.0f;
                    }
                }
            }
            else Debug.Log("GirlController not found in HitInspector.cs:OnTriggerEnter2D");
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
