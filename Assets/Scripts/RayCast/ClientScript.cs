using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using Sample;
public class ClientScript : MonoBehaviour {
    public SampleImageTargetBehaviour sample;
    public bool ispopupwindow;
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
       // SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
       // LeanTween.value(0f, .1f, .8f).setLoopPingPong().setOnUpdate((float value) =>
      //  {
      //      sprite.color = new Color(1f, 0f, 0f, value);
      //  }); 
          
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
        if (!ispopupwindow)
        {
            scroll.gameObject.SetActive(true);
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-40, 40), 495);
            scroll.transform.parent.transform.localPosition = newPos;

            LeanTween.scale(scroll.gameObject, Vector3.one, 1f).setEase(LeanTweenType.easeInOutCubic);
            GizemoCtr.instance.GizemoCenterAnimation(1.5f, 1f);
            GizemoCtr.instance.IMG.fillAmount = 0;
            GizemoCtr.instance.GizemoCenter.SetActive(false);
        }
        else {
            string s = sample.animationsObject.ToString();
             Sprite sprite = ReadJson.instance.POPwindow[s];
            RayCast.instance.pop.LoadImage(sprite);
            LeanTween.scale(RayCast.instance.pop.gameObject, Vector3.one, 1f).setEase(LeanTweenType.easeInOutCubic);
        }

    }

    public void HideText(Scroll scroll) {
        if (!ispopupwindow)
        {
            LeanTween.scale(scroll.gameObject, Vector3.zero, 1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(delegate ()
            {
                GizemoCtr.instance.GizemoCenter.SetActive(true);
                GizemoCtr.instance.GizemoRing.SetActive(true);
                scroll.gameObject.SetActive(false);
            });
        }
        else {
            LeanTween.scale(RayCast.instance.pop.gameObject, Vector3.zero, 1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(delegate () { 
            
            });
    }

    }
}
