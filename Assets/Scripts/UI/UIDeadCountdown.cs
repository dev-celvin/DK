using UnityEngine;
using System.Collections;

public class UIDeadCountdown : MonoBehaviour {
	public static UIDeadCountdown Instance;
	bool openWindow=false;
	public GameObject BackAll;
	public SkeletonAnimation[] fire;
	public GameObject Giveup_Button;
	public GameObject Continue_Button;

	float timeCount;
	// Use this for initialization
	void Start () {
		Instance = this;
		UIEventListener.Get (Giveup_Button).onClick = Giveup;
		UIEventListener.Get (Continue_Button).onClick = ContinueLevel;
	}

	int destroyNum=0;
	// Update is called once per frame
	void Update () {
		if (openWindow) {
			timeCount+=Time.deltaTime;
			if(timeCount > (destroyNum+3f))
			{
				fire[destroyNum].AnimationName="ximie";
				fire[destroyNum].timeScale=0.5f;
				Destroy(fire[destroyNum],0.9f);
				destroyNum++;
			}
			if(destroyNum >= 8)
			{
				openWindow=false;
				Invoke("GameOver",3f);
			}
		}

        if (Input.GetKeyDown(KeyCode.X))
        {
            UIFinishWindow.Instance.WindowOpen();
        }

	}

	public void WindowOpen()
	{
		openWindow = true;
		BackAll.SetActive (true);

	}
	void GameOver()
	{
		Application.LoadLevel (0);
	}
	void Giveup(GameObject button)
	{
		Application.LoadLevel (0);
	}
	void ContinueLevel(GameObject button)
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
