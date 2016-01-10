using UnityEngine;
using System.Collections;

public class GirlEffect : MonoBehaviour {

    public static GirlController girlController;
    private SkeletonAnimation m_SkeletonAnimation;

    void Awake()
    {
        m_SkeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    // Use this for initialization
    void Start()
    {
        if (girlController == null)
        {
            girlController = transform.parent.GetComponentInChildren<GirlController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = girlController.gameObject.transform.localScale;
        transform.localPosition = girlController.gameObject.transform.localPosition;
        if (m_SkeletonAnimation.AnimationName != null)
        {
            if (m_SkeletonAnimation.state.GetCurrent(0).time >= m_SkeletonAnimation.state.GetCurrent(0).endTime)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
    public void setEffect(int type, float direction)
    {
        m_SkeletonAnimation.timeScale = 1;
        if (type == 1)
        {
            m_SkeletonAnimation.AnimationName = "atk_1";
        }
        //this.direction = direction;
        transform.localScale = new Vector3(direction, 1, 1);
    }
}
