using Sample;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum AnimationsObject { ShiShan, HeShan, ImageTrack3, BackGroundAnimationPlay, }
public class MovingCtr : MonoBehaviour {
    
    public static MovingCtr instance;

    [System.Serializable]
    public class MoveClinet {
        public string ObjectName;
        public AnimationsObject Name;
        public Transform[] Atransform;
        public AnimationClip[] clip;
        public  MoveClinet() {
        }

        public void MoveBehavior(Action<MoveClinet> action, MoveClinet moveClinet)
        {
            action(moveClinet);
        }
        public void MoveBehavior(Action action)
        {
            action();
        }

    }
    
    public List<MoveClinet> myclinet;
 //   private List<Animation> AnimationList;
    public List<SampleImageTargetBehaviour> SampleImageTargetBehaviourlist;
    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        }
    }

    public void StartBackAnimation() {
        for (int i = 0; i < myclinet.Count; i++)
        {
            switch (myclinet[i].Name)
            {
                case AnimationsObject.ShiShan:
                    myclinet[i].MoveBehavior(OpenText, myclinet[i]);
                   
                    break;

                case AnimationsObject.HeShan:
                    myclinet[i].MoveBehavior(OpenText, myclinet[i]);
                    break;

                case AnimationsObject.ImageTrack3:
                  //  myclinet[i].MoveBehavior(MoveFishingBoat, myclinet[i]);
                    break;

                case AnimationsObject.BackGroundAnimationPlay:
                    myclinet[i].MoveBehavior(MoveBGAnim, myclinet[i]);
                    break;
                default:
                    break;
            }
        }
    }


    public void ResetAnimation() {

    }

	// Update is called once per frame
	void Update () {

    }


    void MoveBGAnim(MoveClinet MoveClinet) {
        AnimationPlay(MoveClinet);

    }

    void OpenText(MoveClinet MoveClinet) {
        AnimationPlay(MoveClinet);
    }

    void AnimationPlay(MoveClinet _MoveClinet) {
            try
            {
            for (int i = 0; i < _MoveClinet.Atransform.Length; i++)
            {
                //Debug.Log(_MoveClinet .Name+ ":"+_MoveClinet.Atransform.Length);
                Animation anim = _MoveClinet.Atransform[i].GetComponent<Animation>();
                anim.Play(_MoveClinet.clip[i].name);
            }

                //       AnimationList.Add(anim);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
       // }
    }
}
