using UnityEngine;
using System.Collections;

public class BackMove : MonoBehaviour {
	public Transform[] back;
	public Transform m_camera;
	public float[] movespeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<back.Length;i++)
		{
			back[i].localPosition=new Vector3(-m_camera.localPosition.x*movespeed[i],back[i].localPosition.y,back[i].localPosition.z);
		}
	}
}
