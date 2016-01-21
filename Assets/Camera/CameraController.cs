using UnityEngine;
using System.Collections;
using DG.Tweening;

public enum FaceCode
{
    Left,
    Right,
    Up,
    Down,
}
public enum CameraMode
{
    Break,
    Focus,
    Faint,
    Blur,
    Shake,
}

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public GameObject BindingPlayer;
    public CameraFilterPack_Blur_Focus BlurScreen;
    public CameraFilterPack_FX_Drunk FaintScreen;
    public CutScreen BreakScreen;
    FaceCode face;

    [HeaderAttribute("镜头初始Size")]
    public float cameraStartSize = 2.8f;

    public Vector2 Location_Start;
    [HeaderAttribute("限制镜头移动位置(X:左 Y:右 W:上 H:下)")]
    public Rect Limit_Screen;




    Vector2 targetoffset;//镜头跟随偏移量
    [HeaderAttribute("镜头左右偏移量")]
    public float V_offsetvalue = 3f;//偏移量数值
    [HeaderAttribute("镜头上下偏移量")]
    public float H_offsetvalue = 1f;//偏移量数值
    [HeaderAttribute("镜头上下中心偏移")]
    public float H_middlevalue = -1f;//偏移量数值
    //镜头移动顺滑度
    float _smooth = 4f;
    public float Smooth
    {
        set { this._smooth = value; }
    }


    void Init()
    {
        Instance = this;

        face = FaceCode.Right;//开始是向右看
        FaceTurn();

        transform.position = new Vector3(Location_Start.x, Location_Start.y, transform.position.z);//初始化镜头位置
        lastCameraPoint = Location_Start;

        focusTransform = BindingPlayer;//开始聚焦点是主角
    }

    bool turning = false;//镜头转向中
    public void SetFace(FaceCode f)
    {

        if (face != f)
        {
            turning = true;
        }
        face = f;

        FaceTurn();
    }


    void FaceTurn()
    {
        if (face == FaceCode.Right)
        {
            targetoffset = new Vector2(V_offsetvalue, 0);
        }
        else if (face == FaceCode.Left)
        {
            targetoffset = new Vector2(-V_offsetvalue, 0);
        }
    }

    float cameraSpeed;
    Vector2 lastCameraPoint;
    void FollowSmooth()//跟随
    {
        Vector2 targetpoint;
        targetpoint = new Vector2(BindingPlayer.transform.position.x + targetoffset.x,
            (Mathf.Abs(transform.localPosition.y - BindingPlayer.transform.position.y + H_middlevalue) > H_offsetvalue) ? (BindingPlayer.transform.position.y - H_offsetvalue) : transform.localPosition.y);


        bool overScreen = false;
        if ((Limit_Screen.x - targetpoint.x) > 0)
        {
            targetpoint = new Vector2(Limit_Screen.x, targetpoint.y);
            overScreen = true;
        }
        if ((targetpoint.x - Limit_Screen.y) > 0)
        {
            targetpoint = new Vector2(Limit_Screen.y, targetpoint.y);
            overScreen = true;
        }
        if (Limit_Screen.width < targetpoint.y)
        {
            targetpoint = new Vector2(targetpoint.x, Limit_Screen.width);

        }
        if (Limit_Screen.height > targetpoint.y)
        {
            targetpoint = new Vector2(targetpoint.x, Limit_Screen.height);

        }

        transform.localPosition += new Vector3((targetpoint.x - transform.localPosition.x) * _smooth * Time.fixedDeltaTime,
            (targetpoint.y - transform.localPosition.y) * _smooth * Time.fixedDeltaTime, 0);

        if (!overScreen)
        {

            if (!turning)
            {

                if ((face == FaceCode.Right && transform.localPosition.x < BindingPlayer.transform.position.x) ||
                    (face == FaceCode.Left && transform.localPosition.x > BindingPlayer.transform.position.x))
                {

                    transform.localPosition = new Vector3(BindingPlayer.transform.position.x, transform.localPosition.y, transform.localPosition.z);

                }
                if ((face == FaceCode.Right && transform.localPosition.x > (BindingPlayer.transform.position.x + targetoffset.x)) ||
                   (face == FaceCode.Left && transform.localPosition.x < (BindingPlayer.transform.position.x + targetoffset.x)))
                {
                    transform.localPosition = new Vector3(BindingPlayer.transform.position.x + targetoffset.x, transform.localPosition.y, transform.localPosition.z);
                }


            }
            else
            {
                if ((face == FaceCode.Right && transform.localPosition.x > BindingPlayer.transform.position.x) ||
                    (face == FaceCode.Left && transform.localPosition.x < BindingPlayer.transform.position.x))
                {

                    turning = false;
                }
            }

        }
        cameraSpeed = Vector2.Distance(transform.localPosition, lastCameraPoint) / Time.fixedDeltaTime;
        lastCameraPoint = transform.localPosition;
    }

    bool startBlur = false;
    float blurMaxUseTime = 1f;//镜头模糊到最大所花时间
    float blurTime = 0;
    /*
    void BlurMode()
    {
        if (cameraSpeed > 1f)
        {
            BlurScreen.enabled = true;
        }else {
            if (blurTime < 0)
            {
                BlurScreen.enabled = false;
            }
        }

        if (cameraSpeed > blurStartSpeed)
        {
            Debug.LogError(Mathf.Lerp(20f, 5f, (blurTime - 1f)));
            if((blurTime-1)<blurMaxUseTime)
                blurTime += Time.fixedDeltaTime;

            if (blurTime > 1f)
            {
                BlurScreen._Eyes = Mathf.Lerp(20f, 5f, (blurTime - 1f)/blurMaxUseTime);
            }
        }
        else
        {
            BlurScreen._Eyes = Mathf.Lerp(64f, 20f, (cameraSpeed - 1f) / 4f);
            if (blurTime > 0)
            {
                blurTime -= Time.fixedDeltaTime;
            }
        }
  
    }*/
    void BlurMode()//模糊
    {

        if (startBlur)
        {
            BlurScreen.enabled = true;
            if (blurTime < blurMaxUseTime)
            {
                blurTime += Time.fixedDeltaTime;
            }

        }
        else
        {
            if (blurTime > 0)
            {
                blurTime -= Time.fixedDeltaTime;
            }
            else
            {
                BlurScreen.enabled = false;
            }

        }
        BlurScreen._Size = Mathf.Lerp(1f, 2f, blurTime / blurMaxUseTime);
        BlurScreen._Eyes = Mathf.Lerp(64f, 10f, blurTime / blurMaxUseTime);
        BlurScreen.CenterX = (BindingPlayer.transform.position.x - transform.position.x) / GetComponent<Camera>().orthographicSize;
        BlurScreen.CenterX = (BlurScreen.CenterX > 1f) ? 1f : BlurScreen.CenterX;
        BlurScreen.CenterX = (BlurScreen.CenterX < -1f) ? -1f : BlurScreen.CenterX;
        BlurScreen.CenterY = (transform.position.y - BindingPlayer.transform.position.y) / GetComponent<Camera>().orthographicSize;
        BlurScreen.CenterY = (BlurScreen.CenterY > 1f) ? 1f : BlurScreen.CenterY;
        BlurScreen.CenterY = (BlurScreen.CenterY < -1f) ? -1f : BlurScreen.CenterY;
    }

    bool startFocus = false;
    GameObject focusTransform;
    float focusSize;
    float focusDegree;
    float focusMaxTime = 0.2f;
    float focusTime;
    void FocusMode()//聚焦
    {
        Vector2 focusOffset = transform.localPosition - focusTransform.transform.position;
        if (startFocus)
        {
            if (focusTime < (focusDegree * focusMaxTime))
            {
                focusTime += Time.fixedDeltaTime;
            }
        }
        else
        {
            if (focusTime > 0)
            {
                focusTime -= Time.fixedDeltaTime;
            }

        }
        transform.parent.position = new Vector2(Mathf.Lerp(0, -focusOffset.x, focusTime / focusMaxTime), 0);//只需左右移动，上下聚焦不用太刻意
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(cameraStartSize, focusSize, focusTime / focusMaxTime);
    }


    float shakeDegree = 1f;
    float shakeTime = 0.2f;
    void ShakeMode()//抖动
    {
        //GetComponent<Camera> ().DOShakePosition (0.1f, 0.5f, 10, 0f);
        iTween.ShakeRotation(gameObject, iTween.Hash("z", 1f * shakeDegree, "time", shakeTime));
        iTween.ShakePosition(gameObject.transform.parent.parent.gameObject, iTween.Hash("x", 0.1f * shakeDegree, "y", 0.1f * shakeDegree, "time", shakeTime, "islocal", true));
    }

    float faintTime = 0;
    void FaintMode()//眩晕
    {
        if (faintTime > 0)
        {
            faintTime -= Time.fixedDeltaTime;
            FaintScreen.enabled = true;
        }
        else
        {
            FaintScreen.enabled = false;
        }
    }


    bool startBreak = false;
    float breakDegree;
    float breakMaxTime = 0.1f;
    float breakTime;
    void BreakMode()
    {

        if (startBreak)
        {
            if (breakTime < breakMaxTime)
            {
                breakTime += Time.fixedDeltaTime;
            }
        }
        else
        {
            if (breakTime > 0)
            {
                breakTime -= Time.fixedDeltaTime;
            }

        }
        BreakScreen.effectTime = Mathf.Lerp(0, breakDegree, breakTime / breakMaxTime);
    }

    void Start()
    {

        Init();
    }





    /// <summary>
    ///<para>Faint:float(经历时间)</para> 
    ///<para>Blur:bool(开/关),float(变化时间)</para> 
    ///<para>Focus:bool(开/关),float(聚焦镜头尺寸),float(聚焦镜头程度[百分比0-1]),float(变化时间),GameObject(聚焦角色,不改变则填null)</para> 
    ///<para>Shake:float(程度[1为基础,数值越大抖动越大]),float(经历时间)</para> 
    ///<para>Break:bool(开/关),float(程度[百分比0-1]),float(经历时间)</para> 
    ///<para>注：所有float类型,-1代表不改变数值</para> 
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="list"></param>
    public void SetCameraEffect(CameraMode mode, params object[] list)
    {

        switch (mode)
        {
            case CameraMode.Faint:
                faintTime = (float)list[0];
                break;
            case CameraMode.Blur:
                startBlur = (bool)list[0];
                if ((float)list[1] > 0)
                    blurMaxUseTime = (float)list[1];
                break;
            case CameraMode.Break:
                startBreak = (bool)list[0];
                if ((float)list[1] > 0)
                    breakDegree = (float)list[1];
                if ((float)list[2] > 0)
                    breakMaxTime = (float)list[2];
                break;
            case CameraMode.Focus:
                startFocus = (bool)list[0];
                if ((float)list[1] > 0)
                    focusSize = (float)list[1];
                if ((float)list[2] > 0)
                    focusDegree = (float)list[2];
                if ((float)list[3] > 0)
                    focusMaxTime = (float)list[3];
                if ((GameObject)list[4] != null)
                {
                    focusTransform = (GameObject)list[4];
                }
                break;
            case CameraMode.Shake:
                if ((float)list[0] > 0)
                    shakeDegree = (float)list[0];
                if ((float)list[1] > 0)
                    shakeTime = (float)list[1];
                ShakeMode();
                break;
        }
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        BreakMode();
        FocusMode();
        FaintMode();
        BlurMode();
        FollowSmooth();

    }
}
