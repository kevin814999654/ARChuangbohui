using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public RectTransform AnimationMask;
    public float AnimationTime = 0.45f;
    [HideInInspector]
    public Animation animation;
    public List<AnimationClip> clips;
    public RectTransform StartTrans,EndTrans;
    [HideInInspector]
    public Vector3 startPos, EndPos;
    // Use this for initialization
    private void Awake()
    {
        animation = AnimationMask.GetComponent<Animation>();
        startPos = StartTrans.localPosition;
        EndPos = EndTrans.localPosition;
    }
}
