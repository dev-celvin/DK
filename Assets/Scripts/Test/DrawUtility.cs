using UnityEngine;
using System.Collections;

public class DrawUtility : MonoBehaviour {

    public static Vector2 v1 = new Vector2(0, 0);
    public static Vector2 v2 = new Vector2(0, 0);

    void OnDrawGizmos() {
        if (v1 != Vector2.zero && v2 != Vector2.zero) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(v1, v2);
        }
    }

}
