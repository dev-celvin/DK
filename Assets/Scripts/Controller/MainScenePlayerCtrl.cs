using UnityEngine;
using System.Collections;

public class MainScenePlayerCtrl : MonoBehaviour
{

    private Animator _mAnimator;
    public float Speed = 2.0f;
	// Use this for initialization
	void Start ()
	{
	    _mAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        Player.instance.moveDragRate = Input.GetAxis("Horizontal");
#else
        Player.instance.moveDragRate = KeyManager.instance.GetMoveDis();
#endif
        _mAnimator.SetFloat("MoveRate", Mathf.Abs(Player.instance.moveDragRate));
        //玩家转向
        if (Player.instance.moveDragRate > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Player.instance.xDirection = Global.GlobalValue.XDIRECTION_RIGHT;
        }
        else if (Player.instance.moveDragRate < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Player.instance.xDirection = Global.GlobalValue.XDIRECTION_LEFT;
        }
        transform.Translate(Player.instance.moveDragRate*Time.deltaTime*Speed, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Main/Gate")
        {
            StartCoroutine(LoadingScene.Instance.LoadScene("Battle"));
        }
        if (other.tag == "Main/OldMan")
        {
            other.GetComponent<OldManTest>().TouchPlayer(true);
        }
    }
}
