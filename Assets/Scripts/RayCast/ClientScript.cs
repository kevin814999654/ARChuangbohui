using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        LeanTween.cancelAll();
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        //Debug.Log(this.name + "BackWhite " + "is triggered");
        sprite.color = new Color32(0, 0, 0, 0);
    }

    public void ShowText(GameObject _gameObject) {
        LeanTween.scaleY(_gameObject, 1F, .2f).setEase(LeanTweenType.easeInCubic);
    }

    public void HideText(GameObject _gameObject) {
        //Debug.Log("Hide");
        LeanTween.scaleY(_gameObject, 0, .2f).setEase(LeanTweenType.easeInCubic);
    }
}
