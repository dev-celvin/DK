using UnityEngine;
using System.Collections;

public class OldManTest : MonoBehaviour {
	public SpriteRenderer title;
	public GameObject SkillEditWindow;
	bool canClick=false;
	// Use this for initialization
	void Start () {
	
	}

	public void TouchPlayer(bool isTouch)
	{
		canClick=isTouch;
		if(isTouch)
		{
			title.color=new Color(1,1,1,1);
		}else
		{
			title.color=new Color(1,1,1,0);
		}

	}

	void OnMouseDown(){
		if(canClick)
		{
			SkillEditWindow.SetActive(true);
		}
	}
}
