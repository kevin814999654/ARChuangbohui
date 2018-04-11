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
namespace EasyAR
{
    public class CameraDeviceBehaviour : CameraDeviceBaseBehaviour
    {
        private float AccDis=0;
        private bool IsWakeUp;
        private bool StartCoutDown;

        protected override void Start()
        {
            base.Start();
            OpenAndStart();
#if !UNITY_EDITOR
            StartCoroutine(ScreenProtect());
#endif
        }





        IEnumerator ScreenProtect()
        {
            float currentAccDis = Input.acceleration.magnitude;
            check(currentAccDis);

            yield return new WaitForSeconds(.5f);
            StartCoroutine(ScreenProtect());
        }


        void check(float _currentAccDis) {
            if (AccDis != _currentAccDis)
            {
                StopCoroutine(CountDown());
                if (!IsWakeUp)
                {
                    IsWakeUp = true;
                    WakeUp();
                }
            }
            else
            {

                if (!StartCoutDown)
                {
                    StartCoutDown = true;
                    StartCoroutine(CountDown());
                }

            }
        }

        IEnumerator CountDown() {
            int time = 0;
            while (StartCoutDown) {
                time++;
                yield return new WaitForSeconds(1f);
                if (time == 10) {
                    Sleep();
                }
            }

        }

        void WakeUp()
        {
            OpenAndStart();
        }

        void Sleep()
        {
            Close();
            StartCoutDown = false;
            IsWakeUp = false;
        }
    }
}
