using UnityEngine;
using System.Collections.Generic;

public class KeyManager : MonoSingleton<KeyManager>
{
    public GameObject[] button;
    public bool[] boolcheck;

    public enum KeyCode
    {
        Hitback,
        Combo,
        Evade,
        Attack,
        Jump,
        Walk_Left,
        Walk_Right,
        Run_Left,
        Run_Right

    }
    Dictionary<KeyCode, bool> keyMessageDown = new Dictionary<KeyCode, bool>();
    Dictionary<KeyCode, bool> keyMessage = new Dictionary<KeyCode, bool>();
    Dictionary<KeyCode, bool> keyMessageUp = new Dictionary<KeyCode, bool>();
    // Use this for initialization
    void Start()
    {
        InitKey();
        for (int i = 0; i < button.Length; i++)
            UIEventListener.Get(button[i]).onPress = ButtonPress;

    }

    int statuNum;
    void InitKey()
    {
        statuNum = System.Enum.GetNames(typeof(KeyCode)).GetLength(0);
        for (int i = 0; i < statuNum; i++)
        {
            keyMessageDown.Add((KeyCode)i, false);
        }
        for (int i = 0; i < statuNum; i++)
        {
            keyMessageUp.Add((KeyCode)i, false);
        }
        for (int i = 0; i < statuNum; i++)
        {
            keyMessage.Add((KeyCode)i, false);
        }

    }


    public void ReceiveMoveDrag(KeyCode key, bool value)
    {
        keyMessageDown[key] = value;
    }
    float movedis = 0f;
    public void ReceiveMoveDis(float dis)
    {
        movedis = dis;
    }
    public float GetMoveDis()
    {
        return movedis;
    }

    void ButtonPress(GameObject button, bool ispress)
    {
        for (int i = 0; i < statuNum; i++)
        {
            if (button.name == ((KeyCode)i).ToString())
            {

                keyMessage[(KeyCode)i] = ispress;
            }
            if (button.name == ((KeyCode)i).ToString())
            {

                keyMessageDown[(KeyCode)i] = ispress;
            }
            if (button.name == ((KeyCode)i).ToString())
            {

                keyMessageUp[(KeyCode)i] = !ispress;
            }
        }

    }
    public bool GetKeyMessage(KeyCode key)
    {
        return keyMessage[key];
    }
    public bool GetKeyMessageDown(KeyCode key)
    {
        return keyMessageDown[key];
    }
    public bool GetKeyMessageUp(KeyCode key)
    {
        return keyMessageUp[key];
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < statuNum; i++)
        {
            keyMessageDown[(KeyCode)i] = false;
        }
        for (int i = 0; i < statuNum; i++)
        {
            keyMessageUp[(KeyCode)i] = false;
        }
    }

    void LateUpdate()
    {
        
    }

}
