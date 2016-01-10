using KGCustom.Controller;
using UnityEngine;

[System.Serializable]
public class CharacterBehavior {

    public float xTransfer { get; set; }
    public float yTransfer { get; set; }
    [HideInInspector]
    public AnimationCurve animCurve;
    public BehaviorType behaviorType;
    protected float startTime;
    public virtual void execute(KGCharacterController cc)
    {
        if (animCurve != null) cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * animCurve.Evaluate(Time.time - startTime) * xTransfer * Vector2.right));
        else cc.transform.Translate(Time.deltaTime * (cc.character.xDirection * xTransfer * Vector2.right));
    }

    public virtual void begin(KGCharacterController cc)
    {
        startTime = Time.time;
    }

    public virtual void end(KGCharacterController cc) { }

    [System.Serializable]
    public enum BehaviorType {
        Null,
        CanThink,
        CanNotThink,
    }

    [System.Serializable]
    public class BehaviorCurve {
        public string animName;
        public float xTransfer;
        public AnimationCurve curve;
    }
}
