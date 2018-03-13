using Sample;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MovingCtr : MonoBehaviour {
    public enum AnimationsObject { ImageTrack1, ImageTrack2, ImageTrack3, FishingBoat,Boat,}
    public static MovingCtr instance;
    [System.Serializable]



    public class MoveClinet {
        public AnimationsObject Name;
        public Transform transform;
        public AnimationClip clip;
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
    private List<Animation> AnimationList;
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
                case AnimationsObject.ImageTrack1:
                    myclinet[i].MoveBehavior(OpenText, myclinet[i]);
                    break;

                case AnimationsObject.ImageTrack2:
                   // myclinet[i].MoveBehavior(MoveFishingBoat, myclinet[i]);
                    break;

                case AnimationsObject.ImageTrack3:
                  //  myclinet[i].MoveBehavior(MoveFishingBoat, myclinet[i]);
                    break;

                case AnimationsObject.FishingBoat:
                    myclinet[i].MoveBehavior(MoveFishingBoat, myclinet[i]);
                    break;

                case AnimationsObject.Boat:
                    myclinet[i].MoveBehavior(BoatMove, myclinet[i]);
                    break;

                default:
                    break;
            }
        }
    }

    public void StopAnimation()
    {
        foreach (var items in AnimationList)
        {
            items.Stop();
        }
        AnimationList.Clear();
    }

    public void ResetAnimation() {

    }

	// Update is called once per frame
	void Update () {

    }


    void MoveFishingBoat(MoveClinet MoveClinet) {
        AnimationPlay(MoveClinet);
    }

    void BoatMove(MoveClinet MoveClinet) {
        AnimationPlay(MoveClinet);
    }

    void OpenText(MoveClinet MoveClinet) {
        AnimationPlay(MoveClinet);
    }

    void AnimationPlay(MoveClinet MoveClinet) {
        try
        {
            Animation anim = MoveClinet.transform.GetComponent<Animation>();
            anim.Play(MoveClinet.clip.name);
            AnimationList.Add(anim);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
