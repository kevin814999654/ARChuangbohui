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

using EasyAR;

    public class CameraDeviceBehaviour : CameraDeviceBaseBehaviour
    {
        public Color ScreenProtectColor;
        public Color ScreenRunningColor;
        [SerializeField]
        RawImage rawImage;
        [SerializeField]
        Text text;
        public int ScreenProtectWaitTime;
        private int CountDownTime;
        private bool IsWakeUp=true;
        private Vector3 perviousAcc;
        //[SerializeField]
        //Text DebugText;
        protected override void Start()
        {
            base.Start();
            OpenAndStart();

           StartCoroutine(ScreenProtect());
           StartCoroutine(StartCountDown());
        }


        IEnumerator ScreenProtect() {
            Vector3 Vector = Input.acceleration;
            float Value =Mathf.Abs(Vector.x - perviousAcc.x) + Mathf.Abs(Vector.y - perviousAcc.y) + Mathf.Abs(Vector.z - perviousAcc.z);
            //DebugText.text = Value.ToString();
            perviousAcc = Vector;

            if (Value > 0.01)
            {
                CountDownTime = 0;
                if (!IsWakeUp)
                {
                    WakeUp();
                }
            }
            yield return new WaitForSeconds(1);
            StartCoroutine(ScreenProtect());
        }


        IEnumerator StartCountDown()
        {
            CountDownTime++;
            if (CountDownTime == ScreenProtectWaitTime) {
                if (IsWakeUp) {
                   
                    Sleep();
                }
            }
            yield return new WaitForSeconds(1);
            StartCoroutine(StartCountDown());
        }


        void Sleep()
        {
            IsWakeUp = false;
        ChangeRawImageAlpha(rawImage, 0, 1, 1f);
        ChangeTextAlpha(text, 0, 1, 1f);

        StopCapture();
            Close();
    }

        void WakeUp()
        {
            IsWakeUp = true;
        ChangeRawImageAlpha(rawImage, 1, 0, 1f);
        ChangeTextAlpha(text, 1, 0, 1f);
            StartCapture();
            OpenAndStart();
        }


        void ChangeRawImageAlpha(RawImage rawImage,float from, float to, float time) {
            LeanTween.value(from, to, time).setOnUpdate((float value)=>{
                rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, value);
        });
        }

        void ChangeTextAlpha(Text text, float from, float to, float time) {
            LeanTween.value(from, to, time).setOnUpdate((float value) => {
                text.color = new Color(text.color.r, text.color.g, text.color.b, value);
            });
        }
    }
