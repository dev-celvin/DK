using UnityEngine;
using System.Collections;

public class UISkillChange : MonoBehaviour {
	public GameObject[] SkillType;
	public GameObject[] SkillObj;
	public UIPlayTween Show;
	public UIPlayTween Hide;
    public int SkillNum = 0;
	// Use this for initialization
	void Start () {
		ChangeSkillType();
	}
	
	// Update is called once per frame
	void Update () {
		ShowSkill();


	}

	int skillIndexNow=0;
	void ShowSkill()
	{

		if(skillIndexNow==KGCustom.Model.PlayerAttack.instance.skillIndex)
		{
			return;
		}else{
			skillIndexNow=KGCustom.Model.PlayerAttack.instance.skillIndex;
		}
		if(skillIndexNow!=0)
		{
			SkillType[SkillNum].GetComponent<UIPlayTween>().Play(true);
		}

		int skillObjNum=-1;
		if(KGCustom.Model.PlayerAttack.instance.getNextSkill()<100)
		{
			skillObjNum=0;
		}else{
			skillObjNum=KGCustom.Model.PlayerAttack.instance.getNextSkill()-100;
		}

		if(Hide.transform.childCount!=0)
		{
			Destroy(Hide.transform.GetChild(0).gameObject);
		}
		if(Show.transform.childCount!=0)
		{
			Show.transform.GetChild(0).SetParent(Hide.transform,false);
		}
		GameObject obj=(GameObject)Instantiate(SkillObj[skillObjNum]);
		obj.transform.SetParent(Show.transform,false);
		
		Show.resetOnPlay=true;
		Show.Play(true);
		Hide.resetOnPlay=true;
		Hide.Play(true);
		
	}
	
	void OnClick()
    {
        SkillNum++;
		ChangeSkillType();

		if(Hide.transform.childCount!=0)//隐藏显示图标
		{
			Destroy(Hide.transform.GetChild(0).gameObject);
		}
		if(Show.transform.childCount!=0)
		{
			Destroy(Show.transform.GetChild(0).gameObject);
		}
    }

	void ChangeSkillType()
	{
		if (SkillNum >= SkillType.Length)
		{
			SkillNum = 0;
		}
		
		for(int i=0;i<SkillType.Length;i++)
		{
			if(i==SkillNum)
			{
				SkillType[i].SetActive(true);
			}else
			{
				SkillType[i].SetActive(false);
			}
			
		}
		
		SetSkillToPlayer(SkillNum);
	}

    public void SetSkillToPlayer(int type)
    {
        int num = 0;
        foreach (int s in UIData.instance.SkillEditList[type])
        {
            if (s != -1)
            {
                num++;
            }
        }
        int[] setSkill = new int[num];
        num = 0;
        foreach (int s in UIData.instance.SkillEditList[type])
        {
            if (s != -1)
            {
                if (s == 0)
                {
                    setSkill[num] = 1;
                }
                else
                {
                    setSkill[num] = s + 100;
                }
                num++;
            }
        }
        for (int i = 0; i < setSkill.Length; i++)
        {
            if (setSkill[i] == 1 && i > 0)
            {
                if (setSkill[i - 1] < 100)
                {
                    setSkill[i] = setSkill[i - 1] + 1;
                    setSkill[i] = setSkill[i] > 4 ? 1 : setSkill[i];

                }
            }
        }

        KGCustom.Model.PlayerAttack.instance.setSkillQueue(setSkill);
    }
}
