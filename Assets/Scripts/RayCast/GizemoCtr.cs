using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GizemoCtr : MonoBehaviour {
    public GameObject GizemoCenter, GizemoRing;
    public static GizemoCtr instance;
   public Image IMG;

  public  bool isbreak = false;
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
        GizemoCenter.transform.localScale = Vector3.one;
        LeanTween.scale(GizemoCenter, Vector3.one * Scale, time).setLoopPingPong().setEaseInOutQuad();
    }

    public IEnumerator Loadinfo(Action action)
    {
        float value = 0;
        while (!isbreak)
        {
            value += 0.02f;
            yield return new WaitForSeconds(.033f);
            IMG.fillAmount = Mathf.Clamp01(value);
            if (value >= 1) {
                action.Invoke();
                break;
            }
        }

        while (isbreak)
        {
            value -= 0.02f;
            yield return new WaitForSeconds(.033f);
            IMG.fillAmount = Mathf.Clamp01(value);
            if (value<=0)
            {
                break;
            }
        }

        yield return new WaitForFixedUpdate();
    }

    public void CancelAndReturn() {
      //  LeanTween.cancel(GizemoRing);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
