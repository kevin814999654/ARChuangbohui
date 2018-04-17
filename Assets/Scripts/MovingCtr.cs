using Sample;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum AnimationsObject { 狮子山, 何山, 太湖, BackGroundAnimationPlay, 春台社戏,京杭运河}
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

    public void StartBackAnimation(AnimationsObject _animationsObject) {
        MoveClinet client = getClient(_animationsObject);
            switch (_animationsObject)
            {
                case AnimationsObject.狮子山:
                client.MoveBehavior(OpenText, client);                  
                    break;

                case AnimationsObject.何山:
                client.MoveBehavior(OpenText, client);
                    break;

                case AnimationsObject.太湖:
                   client.MoveBehavior(OpenText, client);
                    break;

            case AnimationsObject.春台社戏:
                client.MoveBehavior(OpenText, client);
                break;

            case AnimationsObject.京杭运河:
                client.MoveBehavior(OpenText, client);
                break;

            case AnimationsObject.BackGroundAnimationPlay:
                client.MoveBehavior(MoveBGAnim, client);
                    break;
                default:
                    break;
            }
    }

    MoveClinet getClient(AnimationsObject _animationsObject) {

        foreach (MoveClinet item in myclinet)
        {
            if (item.Name == _animationsObject)
            {
                return item;
            }
        }
        return null;
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
              //  Debug.Log(_MoveClinet.clip[i].name);
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
