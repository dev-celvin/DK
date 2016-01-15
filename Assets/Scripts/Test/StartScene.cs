using System.Collections;
using UnityEngine;
using AnimationState = Spine.AnimationState;

public class StartScene : MonoBehaviour
{
    public GameObject TouchUI;
    public SkeletonAnimation skeletonAnimation;
    private TweenOrthoSize tweenOrthoSize;
    private TweenPosition tweenPosition;

    public UISlider processBar;
    private AsyncOperation async;
    private uint _nowprocess;
    // Use this for initialization
    void Start()
    {
        _nowprocess = 0;
        tweenOrthoSize = GetComponent<TweenOrthoSize>();
        tweenPosition = GetComponent<TweenPosition>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0) && TouchUI!= null)
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

        if (async == null)
        {
            return;
        }

        uint toProcess;
        if (async.progress < 0.9f)//坑爹的progress，最多到0.9f
        {
            toProcess = (uint)(async.progress * 100);
        }
        else
        {
            toProcess = 100;
        }

        if (_nowprocess < toProcess)
        {
            _nowprocess++;
        }

        processBar.value = _nowprocess / 100f;

        if (_nowprocess == 100)//async.isDone应该是在场景被激活时才为true
        {
            async.allowSceneActivation = true;
        }
    }

    public void OnTouchThePad()
    {
        Destroy(TouchUI);
        Camera.main.backgroundColor = Color.white;
        skeletonAnimation.state.SetAnimation(0, "2", false);
        skeletonAnimation.state.AddAnimation(0, "3", true, 2.333f).Complete +=
            delegate(AnimationState state, int index, int count)
            {
                StartCoroutine(LoadScene());                
            };
        tweenOrthoSize.enabled = true;
        tweenPosition.enabled = true;
    }
    IEnumerator LoadScene()
    {
        processBar.gameObject.SetActive(true);
        async = Application.LoadLevelAsync("Main");
        async.allowSceneActivation = false;
        yield return async;
    }

}
