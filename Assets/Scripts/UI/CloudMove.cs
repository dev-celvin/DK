using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {
	public Transform[] cloud;
	public float[] movespeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<cloud.Length;i++)
		{
			cloud[i].localPosition+=new Vector3(movespeed[i]*Time.deltaTime*0.5f,0,0);
			if(cloud[i].localPosition.x>12f)
			{
				cloud[i].localPosition-=new Vector3(15f,0,0);
			}
		}
	}
}
