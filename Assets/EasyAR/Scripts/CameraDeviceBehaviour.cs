//=============================================================================================================================
//
// Copyright (c) 2015-2017 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace EasyAR
{
    public class CameraDeviceBehaviour : CameraDeviceBaseBehaviour
    {
        private float AccDis=0;
        private bool IsWakeUp;
        private bool StartCoutDown;
        private Vector3 perviousAcc;
        [SerializeField]
        Text DebugText;
        protected override void Start()
        {
            base.Start();
            OpenAndStart();

           StartCoroutine(ScreenProtect());

        }


        IEnumerator ScreenProtect() {
            Vector3 Vector = Input.acceleration;
            float Value =Mathf.Abs(Vector.x - perviousAcc.x) + Mathf.Abs(Vector.y - perviousAcc.y) + Mathf.Abs(Vector.z - perviousAcc.z);
            DebugText.text = Value.ToString();
            perviousAcc = Vector;
            yield return new  WaitForSeconds(1);
        }


        private void Update()
        {

        }


    //    IEnumerator ScreenProtect()
    //    {
    //        float currentAccDis = Input.acceleration.magnitude;
    //        check(currentAccDis);

    //        yield return new WaitForSeconds(.5f);
    //        StartCoroutine(ScreenProtect());
    //    }


    //    void check(float _currentAccDis) {
    //        if (AccDis != _currentAccDis)
    //        {
    //            StopCoroutine(CountDown());
    //            if (!IsWakeUp)
    //            {
    //                IsWakeUp = true;
    //                WakeUp();
    //            }
    //        }
    //        else
    //        {

    //            if (!StartCoutDown)
    //            {
    //                StartCoutDown = true;
    //                StartCoroutine(CountDown());
    //            }

    //        }
    //    }

    //    IEnumerator CountDown() {
    //        int time = 0;
    //        while (StartCoutDown) {
    //            time++;
    //            yield return new WaitForSeconds(1f);
    //            if (time == 10) {
    //                Sleep();
    //            }
    //        }

    //    }

    //    void WakeUp()
    //    {
    //        OpenAndStart();
    //    }

    //    void Sleep()
    //    {
    //        Close();
    //        StartCoutDown = false;
    //        IsWakeUp = false;
    //    }
    //}
}
