using UnityEngine;
using System.Collections;

public class UISkillEditController : MonoBehaviour {
	int[][] SkillEditList;
	public int OpenNum;
	public int SkillTypeChoiseNum;//0是虎，1是龙，2是雀
	public int SkillSelectNum;
	
	
	
	
	string[] attack_effects = { "atk_1", "atk_2", "atk_3","atk_4" };
	string[] skill_effects = { "skill_1", "skill_2", "skill_3", "skill_4", "skill_5", "skill_6", "skill_7", "skill_8" };

	
	
	UIRoot mRoot;
	[HeaderAttribute("UI接入：")]//W代表窗口，B代表按钮
	public GameObject[] Button_OpenClose;
	public GameObject Button_HideShow;
	
	public GameObject[] Window_SkillEdit;
	
	
	public GameObject[] Button_SkillTypeChoise;
	
	
	public Transform[] PutPosition;
	public Transform[] PutSkillPanel;
	
	public GameObject SelectCircle;
	public GameObject[] Button_SkillSelect;
	
	public SkeletonAnimation PlayerActor;
	public SkeletonAnimation PlayerEffect;
	public GameObject[] SkillDescribe;
	
	public GameObject Button_GoBack;
	// Use this for initialization
	
	void Start () {



		mRoot = NGUITools.FindInParents<UIRoot>(this.gameObject);
		
		Init();
		
		for (int i = 0; i < Button_SkillTypeChoise.Length; i++)
		{
			UIEventListener.Get(Button_SkillTypeChoise[i]).onClick = SkillTypeChoise;
		}
		for (int i = 0; i < Button_SkillSelect.Length; i++)
		{
			UIEventListener.Get(Button_SkillSelect[i].transform.FindChild("Button").gameObject).onClick = SkillSelect;
			UIEventListener.Get(Button_SkillSelect[i].transform.FindChild("Button").gameObject).onDragStart = SkillSelectDragStart;
			UIEventListener.Get(Button_SkillSelect[i].transform.FindChild("Button").gameObject).onDrag = SkillSelectDraging;
			UIEventListener.Get(Button_SkillSelect[i].transform.FindChild("Button").gameObject).onDragEnd = SkillSelectDragEnd;
		}
		for (int i = 0; i < Button_OpenClose.Length; i++)
		{
			UIEventListener.Get(Button_OpenClose[i]).onClick = OpenClose;
		}
		UIEventListener.Get(Button_HideShow).onClick = HideShow;
		UIEventListener.Get(Button_GoBack).onClick = GoBack;
	}
	
	void Init()
	{
		PlayerEffect.gameObject.SetActive(false);
		PlayerActor.state.Complete+=new Spine.AnimationState.CompleteDelegate(PlayerActorComplete);
		
		OpenNum = 2;
		HideShow(null);
		isHiding=false;

		SkillEditList = new int[Button_SkillTypeChoise.Length][];
		for (int i = 0; i < Button_SkillTypeChoise.Length; i++)
		{
			SkillEditList[i] = new int[PutPosition.Length];
			for (int j = 0; j < PutPosition.Length; j++)
			{
				SkillEditList[i][j] = UIData.instance.SkillEditList[i][j];
			}
			SetSkillList(i, SkillEditList[i]);
		}
		
		
		
		SkillTypeChoise(Button_SkillTypeChoise[0]);


		this.gameObject.SetActive(false);//初始化后关闭
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	GameObject clone;
	int dragSkillNum;
	int dragPutNum;
	int deleteNum;
	void SkillSelectDragStart(GameObject button)
	{
		clone = NGUITools.AddChild(button.transform.parent.gameObject, button);
		UIEventListener.Get(clone).onClick = SkillEditDelectOne;
		for (int i = 0; i < Button_SkillSelect.Length;i++ )
		{
			if (Button_SkillSelect[i].transform.FindChild("Button").gameObject == button)
			{
				dragSkillNum = i;
			}
		}
	}
	void SkillSelectDraging(GameObject button, Vector2 delta)
	{
		float rate = 1f;
		if (OpenNum == 0)
		{
			rate = 1.8f;
		}
		else if (OpenNum == 1)
		{
			rate = 1.5f;
		}
		else if (OpenNum == 2)
		{
			rate = 1f;
		}
		clone.transform.localPosition += (Vector3)delta * mRoot.pixelSizeAdjustment/rate;
	}
	void SkillSelectDragEnd(GameObject button)
	{
		bool isAdd=false;
		for (int i = 0; i < PutPosition.Length; i++)
		{
			
			if (Vector3.Distance(clone.transform.position, PutPosition[i].position) < 0.08f)
			{
				dragPutNum = i;
				SkillEditList[SkillTypeChoiseNum][dragPutNum] = dragSkillNum;
				SetSkillList(SkillTypeChoiseNum, SkillEditList[SkillTypeChoiseNum]);
				
				/*if (PutPosition[i].transform.childCount > 0)
                {
                    Destroy(PutPosition[i].GetChild(0).gameObject);
                }
                

                clone.transform.SetParent(PutPosition[i]);
                clone.transform.localPosition = Vector3.zero;
                clone.transform.localScale = new Vector3(1, 1, 1)*0.8f;
                isAdd=true;*/
			}
			
		}
		if (!isAdd)
		{
			Destroy(clone);
		}
	
	}
	
	void SkillEditDelectOne(GameObject button)
	{
		int skillnum=0;
		foreach(int s in SkillEditList[SkillTypeChoiseNum])
		{
			if(s!=-1)
				skillnum++;
			
		}
		if(skillnum<=1)
		{
			return;
		}
		for (int i = 0; i < PutPosition.Length; i++)
		{
			
			if (Vector3.Distance(button.transform.position, PutPosition[i].position) < 0.08f)
			{
				deleteNum = i;
				SkillEditList[SkillTypeChoiseNum][deleteNum] = -1;
			}
			
		}
		
		Destroy(button);
	}
	
	void SetSkillList(int typeNum, int[] skillList)
	{
		for (int i = 0; i < PutSkillPanel[typeNum].transform.childCount; i++)
		{
			GameObject go = PutSkillPanel[typeNum].transform.GetChild(i).gameObject;
			Destroy(go);
		} 
		
		
		for(int i=0;i<PutPosition.Length;i++)
		{
			int num = skillList[i];
			if (num < 0)
			{
				continue;
			}
			GameObject clonePut = NGUITools.AddChild(PutSkillPanel[typeNum].gameObject,
			                                         Button_SkillSelect[num].transform.FindChild("Button").gameObject);
			
			clonePut.transform.localPosition =PutPosition[i].localPosition;
			clonePut.transform.localScale = new Vector3(1, 1, 1) * 0.8f;
			UIEventListener.Get(clonePut).onClick = SkillEditDelectOne;
		}
	}
	
	int selectNum;
	void SkillSelect(GameObject button)
	{
		SelectCircle.transform.SetParent(button.transform.parent);
		SelectCircle.transform.localPosition = Vector3.zero;
		
		for (int i = 0; i < Button_SkillSelect.Length; i++)
		{
			if (Button_SkillSelect[i].transform.FindChild("Button").gameObject == button)
			{
				if(selectNum==i)
				{break;}
				selectNum=i;
				
				//播放人物技能
				if(i==0)
				{
					PlayerActor.AnimationName=attack_effects[0];
					PlayerEffect.gameObject.SetActive(true);
					PlayerEffect.AnimationName=attack_effects[0];
				}else
				{
					PlayerActor.AnimationName=skill_effects[i-1];
					PlayerEffect.gameObject.SetActive(true);
					PlayerEffect.AnimationName=skill_effects[i-1];
				}
				
				
				SkillDescribe[i].SetActive(true);
				SkillDescribe[i].GetComponent<TypewriterEffect>().ResetToBeginning();
			}
			else {
				SkillDescribe[i].SetActive(false);
			}
		}
		
		
		
	}
	
	void SkillTypeChoise(GameObject button)
	{
		int ClickNum=-1;
		switch (button.name)
		{ 
			
		case "TigerChoise":
			if (SkillTypeChoiseNum == 0)
			{
				return;
			}
			else {
				ClickNum = 0;
			}
			break;
		case "DragonChoise":
			if (SkillTypeChoiseNum == 1)
			{
				return;
			}
			else
			{
				ClickNum = 1;
			}
			break;
		case "SuzakuChoise":
			if (SkillTypeChoiseNum == 2)
			{
				return;
			}
			else
			{
				ClickNum = 2; 
			}
			break;
		}
		
		for (int i = 0; i < Window_SkillEdit.Length; i++)
		{
			if (i == ClickNum)
			{
				
				Button_SkillTypeChoise[i].transform.FindChild("Pic").GetComponent<UISprite>().enabled = true;
				Window_SkillEdit[i].GetComponent<TweenScale>().delay = 0.15f;
				Window_SkillEdit[i].GetComponent<TweenScale>().PlayForward();
			}
			if (i == SkillTypeChoiseNum)
			{
				
				Button_SkillTypeChoise[i].transform.FindChild("Pic").GetComponent<UISprite>().enabled = false;
				Window_SkillEdit[i].GetComponent<TweenScale>().delay = 0f;
				Window_SkillEdit[i].GetComponent<TweenScale>().PlayReverse();
			}
			
		}
		SkillTypeChoiseNum = ClickNum;
	}
	bool isHiding;
	void HideShow(GameObject button)
	{

		if(OpenNum==2)
		{
			foreach(UIPlayTween pt in Button_OpenClose[1].GetComponents<UIPlayTween>())
			{
				pt.Play(true);
			}
			OpenNum=1;
			isHiding=true;
			
			Button_HideShow.transform.FindChild("Open2").gameObject.SetActive(false);
			Button_HideShow.transform.FindChild("Hide2").gameObject.SetActive(true);
		}else if(OpenNum==1)
		{
			if(isHiding)
			{
				foreach(UIPlayTween pt in Button_OpenClose[0].GetComponents<UIPlayTween>())
				{
					pt.Play(true);
				}
				OpenNum=0;
				
				Button_HideShow.transform.FindChild("Open1").gameObject.SetActive(false);
				Button_HideShow.transform.FindChild("Hide1").gameObject.SetActive(true);
			}else{
				foreach(UIPlayTween pt in Button_OpenClose[3].GetComponents<UIPlayTween>())
				{
					pt.Play(true);
				}
				OpenNum=2;
				
				Button_HideShow.transform.FindChild("Open2").gameObject.SetActive(true);
				Button_HideShow.transform.FindChild("Hide2").gameObject.SetActive(false);
			}
		}else if(OpenNum==0)
		{
			foreach(UIPlayTween pt in Button_OpenClose[2].GetComponents<UIPlayTween>())
			{
				pt.Play(true);
			}
			OpenNum=1;
			isHiding=false;
			
			Button_HideShow.transform.FindChild("Open1").gameObject.SetActive(true);
			Button_HideShow.transform.FindChild("Hide1").gameObject.SetActive(false);
		}
		
		
		
	}
	void OpenClose(GameObject button)
	{
		/*
        switch (button.name)
        {

            case "Close1":
                OpenNum = 0;
                Button_OpenClose[0].SetActive(false);
                Button_OpenClose[1].SetActive(false);
                Button_OpenClose[2].SetActive(true);
                Button_OpenClose[3].SetActive(false);
                break;
            case "Close2":
                OpenNum = 1;
                Button_OpenClose[0].SetActive(true);
                Button_OpenClose[1].SetActive(false);
                Button_OpenClose[2].SetActive(false);
                Button_OpenClose[3].SetActive(true);
                break;
            case "Open1":
                OpenNum = 1;
                Button_OpenClose[0].SetActive(true);
                Button_OpenClose[1].SetActive(false);
                Button_OpenClose[2].SetActive(false);
                Button_OpenClose[3].SetActive(true);
                break;
            case "Open2":
                OpenNum =2;
                Button_OpenClose[0].SetActive(false);
                Button_OpenClose[1].SetActive(true);
                Button_OpenClose[2].SetActive(false);
                Button_OpenClose[3].SetActive(false);
                break;
        }
*/
	}
	void GoBack(GameObject button)
	{
		this.gameObject.SetActive(false);
		
		
		SetSkillToData();

	}
	
	void SetSkillToData()
	{
		for (int type = 0; type < 3; type++)
		{
			UIData.instance.SkillEditList[type] = SkillEditList[type];
		}
	}
	
	void PlayerActorComplete(Spine.AnimationState state, int trackIndex, int loopCount)
	{
		PlayerActor.AnimationName="idle";
		PlayerEffect.AnimationName = null;
		PlayerEffect.gameObject.SetActive(false);
		
		
	}
	
}
