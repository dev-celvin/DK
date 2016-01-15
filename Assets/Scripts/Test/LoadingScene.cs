using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour {
    private AsyncOperation async;
    private uint _nowprocess;
    private GameObject _mCameraGameObject;
    public static LoadingScene Instance;
   
    void Awake()
    {
        Instance = this;
        _mCameraGameObject = transform.Find("Camera").gameObject;
        _mCameraGameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
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

        if (_nowprocess == 100)//async.isDone应该是在场景被激活时才为true
        {
            async.allowSceneActivation = true;
        }
	}
    public IEnumerator LoadScene(string SceneName)
    {
        _mCameraGameObject.SetActive(true);
        async = Application.LoadLevelAsync(SceneName);
        async.allowSceneActivation = false;
        yield return async;
    }
}
