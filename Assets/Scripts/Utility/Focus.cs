using KGCustom.Controller;
using UnityEngine;

public class Focus : MonoBehaviour
{

    public Transform target;
    public float minAngle = 0;
    public float maxAngle = 0;
    private Vector3 tmp;
    private Vector3 goal;
    private Vector2 tarPos;
    private float smoothSpeed = 1;

    void Start() {
        if (target == null) target = PlayerController.instance.headPos;
    }
    void LateUpdate()
    {
        tmp = transform.localEulerAngles;
        if (target.position.x > transform.position.x)
        {
            tarPos.x = 2 * transform.position.x - target.position.x;
            tarPos.y = target.position.y;
        }
        else tarPos = target.position;
        transform.LookAt(tarPos);
        transform.up = transform.forward;
        if (transform.localEulerAngles.z < (360 + maxAngle) && transform.localEulerAngles.z > minAngle)
        {
            transform.localEulerAngles = tmp;
        }
    }
}
