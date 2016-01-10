using UnityEngine;
using System.Collections;

public class CutScreen : MonoBehaviour {

    public Material bladeMaterial;

    /// <summary>
    /// size of the blade quad in pixels
    /// </summary>
    public float bladeSize = 128;

    /// <summary>
    /// duration of a cut
    /// </summary>
    public float cutDuration = .3f;

    /// <summary>
    /// delay between two cuts
    /// </summary>
    public float delayBetweenCuts = .5f;

    /// <summary>
    /// time for a single piece to fall down
    /// </summary>
    public float pieceFallTime = 1f;

    public SkeletonAnimation CutLine;

    public Material holdMaterial;
    private Material material;
    private float duration;
    public float effectTime;

    private Camera tempCamera;
    void Start()
    {
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Ninja Effect"));
            material.SetTexture("_Background", holdMaterial.mainTexture);
        }

        duration = 2 * (cutDuration + delayBetweenCuts) + pieceFallTime;

        

        tempCamera = gameObject.AddComponent<Camera>();
        tempCamera.cullingMask = 0;
        tempCamera.renderingPath = RenderingPath.Forward;
        tempCamera.depth = 1f;
        tempCamera.clearFlags = CameraClearFlags.Depth;
    }

    void Update()
    {
        

        if (effectTime>0)
        {
            CutLine.gameObject.SetActive(true);
            CutLine.AnimationName = "animation";
        }
        if (effectTime <= 0)
        {
            CutLine.gameObject.SetActive(false);
            CutLine.AnimationName = "";
        }
    }

    void OnPostRender() 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix();
        GL.LoadIdentity();

        DrawBackground();
        DrawPieces(effectTime);


        GL.PopMatrix();

        

    }

    private void DrawBackground()
    {
        material.SetFloat("_BlendMode", 0);
        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(0, 1, 0);
            GL.Vertex3(0, Screen.height, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(Screen.width, Screen.height, 0);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(Screen.width, 0, 0);
            GL.End();
        }
    }

    private void DrawPieces(float time)
    {
        material.SetFloat("_BlendMode", 1);

        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);

            string str = "";

            Vector3 progress = new Vector3(0, -Screen.height * SMTransitionUtils.SmoothProgress(cutDuration, pieceFallTime, time), 0);
            progress.y = time *Screen.height;
            float xoffset = progress.y * 0.2f * Screen.width / Screen.height;
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(-xoffset, -progress.y, 0);
            GL.TexCoord3(0, 1f , 0);
            GL.Vertex3(-xoffset, Screen.height - progress.y, 0);
            GL.TexCoord3(0.6f, 1, 0);
            GL.Vertex3(Screen.width * 0.6f - xoffset, Screen.height - progress.y, 0);
            GL.TexCoord3(0.4f , 0 , 0);
            GL.Vertex3(Screen.width * 0.4f - xoffset, -progress.y, 0);

            GL.TexCoord3(0.4f, 0, 0);
            GL.Vertex3(Screen.width * 0.4f + xoffset, progress.y, 0);
            GL.TexCoord3(0.6f, 1, 0);
            GL.Vertex3(Screen.width * 0.6f + xoffset, Screen.height + progress.y, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(Screen.width + xoffset, Screen.height + progress.y, 0);
            GL.TexCoord3(1f, 0, 0);
            GL.Vertex3(Screen.width + xoffset, progress.y, 0);

            
           
            GL.End();
        }
    }

	
   
}
