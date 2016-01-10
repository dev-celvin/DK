using UnityEngine;
using System.Collections;

public class MoveDragButton : MonoBehaviour
{
    public float draglimit;
    public GameObject button;
    public GameObject pic;
    // Use this for initialization
    void Start()
    {
        UIEventListener.Get(button).onDrag = ButtonMove;
        UIEventListener.Get(button).onPress = ButtonPress;

    }
    void Update()
    {

        KeyManager.instance.ReceiveMoveDis(pic.transform.localPosition.x / draglimit);
    }
    float del = 0f;
    void ButtonMove(GameObject buttongameobj, Vector2 delta)
    {
        del += delta.x * (800f / (float)Screen.height);
        

        float a = del;
        if (a < -draglimit)
        {
            a = -draglimit;
        }
        if (a > draglimit)
        {
            a = draglimit;
        }
        //button.transform.localPosition+=new Vector3(delta.x/transform.localScale.x,0,0);
        //pic.transform.localPosition+=new Vector3(a,0,0);
        pic.GetComponent<SpringPosition>().target = new Vector3(a, 0, 0);
        pic.GetComponent<SpringPosition>().enabled = true;

        if (pic.transform.localPosition.x > draglimit / 4)
        {
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Right, true);
        }
        else if (pic.transform.localPosition.x < -draglimit / 4)
        {
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Left, true);
        }
        else
        {
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Left, false);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Right, false);
        }
        if (pic.transform.localPosition.x > draglimit)
        {

            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Right, true);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Right, false);
        }
        else if (pic.transform.localPosition.x < -draglimit)
        {


            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Left, true);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Left, false);
        }
        else
        {
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Left, false);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Right, false);
        }
    }


    void ButtonPress(GameObject buttongameobj, bool ispress)
    {

        if (ispress)
        {
#if UNITY_STANDALONE_WIN
            del = (Input.mousePosition.x) * (800f / (float)Screen.height) - transform.localPosition.x;
#else

            //del = (Input.GetTouch(Input.touchCount-1).position.x) * (800f / (float)Screen.height)-transform.localPosition.x;
            del = (Input.mousePosition.x) * (800f / (float)Screen.height) - transform.localPosition.x;
#endif
            pic.GetComponent<SpringPosition>().target = new Vector3(del, 0, 0);
            pic.GetComponent<SpringPosition>().enabled = true;

        }
        else
        {

            del = 0f;

            pic.GetComponent<SpringPosition>().target = new Vector3(0, 0, 0);
            pic.GetComponent<SpringPosition>().enabled = true;

            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Left, false);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Walk_Right, false);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Left, false);
            KeyManager.instance.ReceiveMoveDrag(KeyManager.KeyCode.Run_Right, false);
        }
    }
    void GetButtonStatu()
    {

    }
}
