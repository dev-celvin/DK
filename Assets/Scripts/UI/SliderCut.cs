using UnityEngine;
using System.Collections;

public class SliderCut : MonoBehaviour {
	[SerializeField, Range(0, 1)]
	float value;
	public float cutSpeed;
	public UISprite current;
	public ParticleSystem effect;
	UISlider slider;
	// Use this for initialization
	void Start () {
		slider=GetComponent<UISlider>();

		slider.value=value;
		current.fillAmount=value;
	}
	
	// Update is called once per frame
	void Update () {

		if(reaching)
		{
			Reach();
		}
	}
	public void SetValue(float v)
	{
		if(value>=v)//减血过渡，加血不过度
		{
			reaching=true;
			if(effect!=null)
			{
				if(reaching)
				{
					if(!effect.isPlaying)
					{
						effect.Play();
					}
				}

			}
		}else{
			slider.value=v;
		}
		value=v;
		current.fillAmount=value;

	}

	bool reaching=false;
	void Reach()//过渡抵达
	{

		if(slider.value>=current.fillAmount)
		{
			slider.value-=cutSpeed*0.01f*Time.deltaTime;
		}else{
			reaching=false;
			if(effect!=null)
			{
				effect.Stop();
			}
		}
	}
}
