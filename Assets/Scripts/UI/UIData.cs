using UnityEngine;
using System.Collections;

public class UIData  {
    static UIData m_UIData = null;
    public static UIData instance
    {
        get
        {
            if (m_UIData == null) m_UIData = new UIData();
            return m_UIData;
        }
    }
    public float BreakSkillCD = 3f;
    public int[][] SkillEditList;//技能编辑的套路数据

    public UIData()
    {
        /*
            SkillEditList = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                SkillEditList[i] = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    SkillEditList[i][j] = -1;
                }
                SkillEditList[i][0] = 0;
            }
         */
        SkillEditList = new int[3][];
        SkillEditList[0] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, -1, -1 };
        for (int i = 1; i < 3; i++)
        {
            SkillEditList[i] = new int[10];
            for (int j = 0; j < 10; j++)
            {
                SkillEditList[i][j] = -1;
            }
            SkillEditList[i][0] = 0;
        }
    }


}
