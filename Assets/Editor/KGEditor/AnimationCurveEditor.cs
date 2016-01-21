using UnityEngine;
using UnityEditor;
using KGCustom.Controller.CharacterController.EnemyController;

[CustomEditor(typeof(PikeManController))]
public class AnimationCurveEditor1 : Editor
{
    PikeManController pmc;
    int tmpIndex = -1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (pmc == null) pmc = PikeManController.instance;
            tmpIndex = EditorGUILayout.IntField("使用的技能(-1未设置):", tmpIndex);
            if (tmpIndex != pmc.AnimIndex)
            {
                if (tmpIndex < pmc.GetBehaviorCount() && tmpIndex != -1)
                {
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                else {
                    tmpIndex = -1;
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                    
            }
        }

    }

}

[CustomEditor(typeof(GunGirlController))]
public class AnimationCurveEditor2 : Editor
{
    GunGirlController pmc;
    int tmpIndex = -1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (pmc == null) pmc = GunGirlController.instance;
            tmpIndex = EditorGUILayout.IntField("使用的技能(-1未设置):", tmpIndex);
            if (tmpIndex != pmc.AnimIndex)
            {
                if (tmpIndex < pmc.GetBehaviorCount() && tmpIndex != -1)
                {
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                else
                {
                    tmpIndex = -1;
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
            }
        }

    }

}
[CustomEditor(typeof(SpiderQueenController))]
public class AnimationCurveEditor3 : Editor
{
    SpiderQueenController pmc;
    int tmpIndex = -1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (pmc == null) pmc = SpiderQueenController.instance;
            tmpIndex = EditorGUILayout.IntField("使用的技能(-1未设置):", tmpIndex);
            if (tmpIndex != pmc.AnimIndex)
            {
                if (tmpIndex < pmc.GetBehaviorCount() && tmpIndex != -1)
                {
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                else
                {
                    tmpIndex = -1;
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
            }
        }

    }
}
[CustomEditor(typeof(ZakoController))]
public class AnimationCurveEditor4 : Editor
{
    ZakoController pmc;
    int tmpIndex = -1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (pmc == null) pmc = ZakoController.instance;
            tmpIndex = EditorGUILayout.IntField("使用的技能(-1未设置):", tmpIndex);
            if (tmpIndex != pmc.AnimIndex)
            {
                if (tmpIndex < pmc.GetBehaviorCount() && tmpIndex != -1)
                {
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                else
                {
                    tmpIndex = -1;
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
            }
        }

    }
}
[CustomEditor(typeof(ZakoFarController))]
public class AnimationCurveEditor5 : Editor
{
    ZakoFarController pmc;
    int tmpIndex = -1;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (pmc == null) pmc = ZakoFarController.instance;
            tmpIndex = EditorGUILayout.IntField("使用的技能(-1未设置):", tmpIndex);
            if (tmpIndex != pmc.AnimIndex)
            {
                if (tmpIndex < pmc.GetBehaviorCount() && tmpIndex != -1)
                {
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
                else
                {
                    tmpIndex = -1;
                    pmc.AnimIndex = tmpIndex;
                    Debug.Log("编辑后记得复制组件然后再非编辑模式下覆盖原组件的值！");
                }
            }
        }

    }
}

