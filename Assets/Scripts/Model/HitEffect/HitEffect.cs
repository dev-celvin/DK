using UnityEngine;

public class HitEffect : MonoBehaviour {

    public SkeletonAnimation m_SkeletonAnimation;
    public MeshRenderer m_MeshRenderer;

    void Awake() {
        m_SkeletonAnimation.state.Complete += OnComplete;
    }

    void Start() {
        m_MeshRenderer.enabled = true;
    }

    private void OnComplete(Spine.AnimationState state, int trackIndex, int loopCount)
    {
        m_SkeletonAnimation.AnimationName = null;
        PoolManager.instance.GetHitEffectPool().Push(gameObject);
    }

    public void PlayHitEffect(int type)
    {
        string animName;
        switch (type)
        {
            case 1:
                animName = "defence_hit";
                break;
            case 2:
                animName = "hit_1";
                break;
            case 3:
                animName = "hit_2";
                break;
            case 4:
                animName = "hit_3";
                break;
            default:
                animName = null;
                break;
        }
        m_SkeletonAnimation.AnimationName = animName;
    }

}
