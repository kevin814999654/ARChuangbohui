using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour {

    public Text MainContent,bigTitle;
    public Image image;
    // Use this for initialization
    private void Awake()
    {
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
