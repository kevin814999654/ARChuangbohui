using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GizemoCtr : MonoBehaviour {
    public GameObject GizemoCenter, GizemoRing;
    public static GizemoCtr instance;
   public Image IMG;
    // Use this for initialization
    void Start () {
        IMG = GizemoRing.GetComponent<Image>();
        if (instance==null) {
            instance = this;
        }

        GizemoCenterAnimation(1.5f, 1f);
    }

   public void GizemoCenterAnimation(float Scale,float time) {
        LeanTween.cancel(GizemoCenter);
        LeanTween.scale(GizemoCenter, Vector3.one * Scale, time).setLoopPingPong().setEaseInOutQuad();
    }

    public void Loadinfo(Action action)
    {
        GizemoCenterAnimation(1.8F, .3F);
        
        LeanTween.value(0f, 1F, 2F).setOnUpdate((float value) =>
        {
           
            IMG.fillAmount = value;
        }).setOnComplete(delegate(){
            action.Invoke();

        });
    }

    // Update is called once per frame
    void Update () {
		
	}
}
