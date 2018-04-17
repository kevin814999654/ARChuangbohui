//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using EasyAR;

namespace Sample
{

    public class SampleImageTargetBehaviour : ImageTargetBehaviour
    {
        public AnimationsObject animationsObject;
        public ClientScript clientScript;
        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
          //  Debug.Log(animationsObject.ToString());
        }

        void OnTargetFound(TargetAbstractBehaviour behaviour)
        {
            //Debug.Log("Found: " + Target.Id);
           // clientScript.ToRed();
            MovingCtr.instance.StartBackAnimation(animationsObject);           
        }

        void OnTargetLost(TargetAbstractBehaviour behaviour)
        {
            //  Debug.Log("Lost: " + Target.Id);
            clientScript.BackWhite();
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            //Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
       
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
          //  Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }
    }
}
