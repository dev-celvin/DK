using System.Collections;
using Global;
using UnityEngine;
using AnimationState = Spine.AnimationState;

public class StartScene : MonoBehaviour
{
    private GameObject TouchUI;
    private SkeletonAnimation skeletonAnimation;
    private TweenOrthoSize tweenOrthoSize;
    private TweenPosition tweenPosition;

    // Use this for initialization
    void Start()
    {
        tweenOrthoSize = GetComponent<TweenOrthoSize>();
        tweenPosition = GetComponent<TweenPosition>();
        TouchUI = GameObject.Find("TouchUI");
        skeletonAnimation = GameObject.Find("title").GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0) && TouchUI != null)
        {
            OnTouchThePad();
        }
#else
        {
            if (Input.touchCount > 0 && TouchUI!= null)
            {
                OnTouchThePad();
            }
        }
        
#endif

    }

    public void OnTouchThePad()
    {
        Destroy(TouchUI);
        Camera.main.backgroundColor = Color.white;
        skeletonAnimation.state.SetAnimation(0, "2", false).Complete +=
            delegate(AnimationState state, int index, int count)
            {
                GlobalValue.LoadName = "Main";
                Application.LoadLevel("Loading");
            };
        tweenOrthoSize.enabled = true;
        tweenPosition.enabled = true;
    }

}
