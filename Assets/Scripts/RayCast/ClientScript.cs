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
        RayCast.OnLooking -= this.exitEvent;
        RayCast.OnLooking += this.enterEvent;
    }

    public void UnSubscribe()
    {
        RayCast.OnLooking -= this.enterEvent;
        RayCast.OnLooking += this.exitEvent;   
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

    public void GizemoDetectAnim(Transform transform) {
        LeanTween.scale(transform.gameObject, Vector3.one / 50, .4f).setEase(LeanTweenType.easeInOutElastic);
    }

    public void GizemoUnDetectAnim(Transform transform)
    {
        LeanTween.scale(transform.gameObject, new Vector3(.01f,.01f,01f), .4f).setEase(LeanTweenType.easeInOutElastic);
    }

    public void ShowText(Scroll scroll) {

        scroll.gameObject.SetActive(true);
        scroll.animation.Play(scroll.clips[0].name);
        LeanTween.value(0, 1, 1).setOnUpdate(delegate(float value) {
                float fillAmout = scroll.AnimationMask.GetComponent<Image>().fillAmount;
                //Debug.Log(fillAmout);

                float ypos = GlobalFun.instance.Map(fillAmout, 0f, 1f, scroll.startPos.y, scroll.EndPos.y);
                scroll.StartTrans.localPosition = new Vector3(0, ypos ,0);
        });
    }

    public void HideText(Scroll scroll) {
  
        scroll.animation.Play(scroll.clips[1].name);
        LeanTween.value(0, 1, 1).setOnUpdate(delegate (float value) {
            float fillAmout = scroll.AnimationMask.GetComponent<Image>().fillAmount;
            //Debug.Log(fillAmout);

            float ypos = GlobalFun.instance.Map(fillAmout, 0f, 1f,  scroll.startPos.y, scroll.EndPos.y);

            scroll.StartTrans.localPosition = new Vector3(0, ypos, 0);

        }).setOnComplete(delegate() {
            scroll.gameObject.SetActive(false);
        });
    }
}
