using UnityEngine;
using System.Collections;
using Global;

public class LoadingScene : MonoBehaviour
{
    //异步对象
    private AsyncOperation _async;

    private UISlider _progressbar;

    void Awake()
    {
        _progressbar = transform.Find("ProgressBar").GetComponent<UISlider>();
    }
    void Start()
    {
        //在这里开启一个异步任务
        //进入LoadScene方法。
        StartCoroutine(LoadScene());
    }
    //注意这里返回值一定是 IEnumerator
    IEnumerator LoadScene()
    {
        //异步读取场景。
        //Globe.LoadName 就是A场景中需要读取的C场景名称。  
        yield return new WaitForEndOfFrame();
        _async = Application.LoadLevelAsync(GlobalValue.LoadName);
        _async.allowSceneActivation = false;
        //读取完毕后返回 系统会自动进入C场景
        yield return _async;
    }

    private void Update()
    {
        //progress 的取值范围在0.1 - 1之间 但是它不会等于1
        //也就是说progress可能是0.9的时候就直接进入新场景了
        //所以在写进度条的时候需要注意一下。
        if (_async != null && !_async.isDone && _async.progress >= 0.9f)
        {
            _progressbar.value = 1;
            _async.allowSceneActivation = true;
        }
        else
        {
            _progressbar.value += Time.deltaTime;            
        }
    }
}
