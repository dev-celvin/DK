using UnityEngine;
using System.Collections;

public class UIFinishWindow : MonoBehaviour {
	public static UIFinishWindow Instance;
	bool openWindow=false;
	public GameObject BackAll;

	float timeCount;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	public void WindowOpen()
	{
		openWindow = true;
		BackAll.SetActive (true);
		
	}
	// Update is called once per frame
	void Update () {
		if (openWindow) {
			timeCount+=Time.deltaTime;
			if(timeCount > 35f)
			{
				Application.LoadLevel(0);
			}

		}
        //if (Input.GetKeyDown (KeyCode.C)) {
        //    UIDeadCountdown.Instance.WindowOpen();
        //}
	}
}
