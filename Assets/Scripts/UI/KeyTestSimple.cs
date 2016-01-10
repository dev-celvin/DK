using UnityEngine;
using System.Collections;

public class KeyTestSimple : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(KeyManager.instance.GetKeyMessage(KeyManager.KeyCode.Run_Left))
		{
			print ("attack");
		}

	}
}
