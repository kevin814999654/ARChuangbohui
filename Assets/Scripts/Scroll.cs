using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour {
    public RectTransform AnimationMask;
    public float AnimationTime = 0.45f;
    [HideInInspector]
    public Animation animation;
    public List<AnimationClip> clips;
    public RectTransform StartTrans,EndTrans;
    [HideInInspector]
    public Vector3 startPos, EndPos;

    public Text MainContent,bigTitle;
    public Image image;
    // Use this for initialization
    private void Awake()
    {
        animation = AnimationMask.GetComponent<Animation>();
        startPos = StartTrans.localPosition;
        EndPos = EndTrans.localPosition;
    }

    public void UpdateScroll(AnimationsObject EType) {
        this.name = EType.ToString();
        foreach (Information item in ReadJson.instance.myinformationList)
        {
            if (item.BigTitle.Equals(EType.ToString())) {
                image.sprite = item.sprite;
                MainContent.text = item.MainContent;
                bigTitle.text = item.BigTitle;
            }   
        } 
    }
}
