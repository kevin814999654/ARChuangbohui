using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class ClientScript : MonoBehaviour {

    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;
    
    // Use this for initialization
    public void SubScribe()
    {
        enterEvent();
    }

    public void UnSubscribe()
    {
        exitEvent();
    }

    private void OnEnable()
    {

        RayCast.OnClicking += OnClick;
    }

    private void OnDisable()
    {
        RayCast.OnClicking -= OnClick;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void enterEvent() {
        EnterEvent.Invoke();
    }

    public void exitEvent()
    {
        ExitEvent.Invoke();
    }

    public void OnClick() {

    }


    public void ToRed() {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        LeanTween.value(0f, .1f, .8f).setLoopPingPong().setOnUpdate((float value) =>
        {
            sprite.color = new Color(1f, 0f, 0f, value);
        }); 
          
     //   Debug.Log(this.name+" " + "is triggered");
    }

    public void BackWhite() {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        //Debug.Log(this.name + "BackWhite " + "is triggered");
        sprite.color = new Color32(0, 0, 0, 0);
    }

    public void GizemoDetectAnim(Transform _transform) {
        //LeanTween.cancel(_transform.gameObject);
        //LeanTween.scale(_transform.gameObject, Vector3.one / 50, .4f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(delegate (){
        //    LeanTween.color(_transform.gameObject, new Color(GlobalFun.instance.GizemoColor.r, GlobalFun.instance.GizemoColor.g, GlobalFun.instance.GizemoColor.b, 0f), .5f).setEase(LeanTweenType.easeOutCubic);
        //});
    }

    public void GizemoUnDetectAnim(Transform _transform)
    {
        //LeanTween.cancel(_transform.gameObject);
        //LeanTween.color(_transform.gameObject, GlobalFun.instance.GizemoColor, .5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(delegate () {
        //    LeanTween.scale(_transform.gameObject, new Vector3(.01f, .01f, 01f), .4f).setEase(LeanTweenType.easeInOutElastic);
        //});
       
    }

    public void ShowText(Scroll scroll) {
       // Debug.Log(scroll.name + "_" + "Show Text");
        scroll.gameObject.SetActive(true);
        scroll.animation.Play(scroll.clips[0].name);
        LeanTween.value(0, 1, 1).setOnUpdate(delegate(float value) {
                float fillAmout = scroll.AnimationMask.GetComponent<Image>().fillAmount;
                //Debug.Log(fillAmout);

                float xpos = GlobalFun.instance.Map(fillAmout, 0f, 1f, scroll.startPos.x, scroll.EndPos.x);
                scroll.StartTrans.localPosition = new Vector3(xpos, scroll.StartTrans.localPosition.y, scroll.StartTrans.localPosition.z);
        }).setOnComplete(delegate(){
           GizemoCtr.instance.GizemoCenterAnimation(1.5f, 1f);
            GizemoCtr.instance.IMG.fillAmount = 0;
        });
    }

    public void HideText(Scroll scroll) {
       // Debug.Log(scroll.name + "_" + "Hide Text");
        scroll.animation.Play(scroll.clips[1].name);
        LeanTween.value(0, 1, 1).setOnUpdate(delegate (float value) {
            float fillAmout = scroll.AnimationMask.GetComponent<Image>().fillAmount;
            //Debug.Log(fillAmout);

            float xpos = GlobalFun.instance.Map(fillAmout, 0f, 1f,  scroll.startPos.x, scroll.EndPos.x);

            scroll.StartTrans.localPosition = new Vector3(xpos, scroll.StartTrans.localPosition.y, scroll.StartTrans.localPosition.z);

        }).setOnComplete(delegate() {
            scroll.gameObject.SetActive(false);
            RayCast.instance.EnableRaycast = true;
        });
    }
}
