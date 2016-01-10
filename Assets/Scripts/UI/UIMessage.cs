using UnityEngine;
using System.Collections;

public class UIMessage: MonoBehaviour {
	public Transform player;
	public Transform[] enemy;
	// Use this for initialization
	Transform playerHP;
	Transform playerMP;
	Transform playerANGER;
	Transform[] enemyHP;
	void Start () {
		playerHP=player.FindChild("Hp");
		playerMP=player.FindChild("Mp");
		playerANGER=player.FindChild("Anger");

		enemyHP=new Transform[enemy.Length];
		for(int i=0;i<enemy.Length;i++)
		{
			enemyHP[i]=enemy[i].FindChild("Hp");
		}
	}
	public int angernum;
	public float value;
	void Update(){
		if(Input.GetKeyDown(KeyCode.I))
		{
			SetPlayerAnger(++angernum);
		}
		if(Input.GetKeyDown(KeyCode.U))
		{
			SetPlayerAnger(--angernum);
		}

		SetPlayerHp(Player.instance.hp/Player.instance.hpMax);
		SetPlayerMp(Player.instance.mp/Player.instance.mpMax);


	}
	void SetPlayerHp(float value)
	{
		playerHP.GetComponent<SliderCut>().SetValue(value);
	}
	void SetPlayerMp(float value)
	{
		playerMP.GetComponent<SliderCut>().SetValue(value);
	}
	void SetPlayerAnger(int num)
	{

		for(int i=1;i<=5;i++)
		{
			if(i>num)
			{
				playerANGER.FindChild(i.ToString()+"/Full").gameObject.SetActive(false);
			}else{
				playerANGER.FindChild(i.ToString()+"/Full").gameObject.SetActive(true);
			}
		}
	}
	void SetEnemyHp(int num,float value)
	{
		enemyHP[num].GetComponent<SliderCut>().SetValue(value);
	}
}
