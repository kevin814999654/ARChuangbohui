using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GlobalFun :MonoBehaviour  {
    public static GlobalFun instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public float  Map(float value,float inputMin,float inputMax,float outputMin,float outputMax)
    {
        float outVal = ((value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin);
        return outVal;
    }

}
