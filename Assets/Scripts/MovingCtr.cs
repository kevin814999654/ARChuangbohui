using Sample;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum AnimationsObject { 狮子山, 何山, 西部生态城, 枫桥, 京杭运河,科技城,灵岩山,斜桥分水,横山,东安桥, 遂初园, 济贫社仓, 法云庵, 瑞光塔, 文庙, 万年桥, 怡老园, 飞雪泉, 北寺塔, 阊门, 阊门吊桥, 山塘街, 半塘桥, 五人墓, 虎丘}
public class MovingCtr : MonoBehaviour {
    
    public static MovingCtr instance;

    [System.Serializable]
    public class MoveClinet {
        public string ObjectName;
        public AnimationsObject Name;
        public Transform Atransform;
        ////public AnimationClip[] clip;
        public MoveClinet() {
        }

        public void MoveBehavior(Action<MoveClinet,string> action, string s,MoveClinet moveClinet)
        {
            action(moveClinet,s);
        }
        public void MoveBehavior(Action action)
        {
            action();
        }

    }
    
    public List<MoveClinet> myclinet;
 //   private List<Animation> AnimationList;
    //public List<SampleImageTargetBehaviour> SampleImageTargetBehaviourlist;
    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        }
    }

    public void StartBackAnimation(AnimationsObject _animationsObject) {
        MoveClinet client = getClient(_animationsObject);

        client.MoveBehavior(OpenText, _animationsObject.ToString(), client);                  
 
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


    //void MoveBGAnim(MoveClinet MoveClinet) {
    //    AnimationPlay(MoveClinet);

    //}

    void OpenText(MoveClinet MoveClinet, string s) {
        AnimationPlay(MoveClinet,s);
    }

    void AnimationPlay(MoveClinet _MoveClinet, string s) {
            try
            {

            _MoveClinet.Atransform.GetComponentInChildren<TextMesh>().text = s;
            //for (int i = 0; i < _MoveClinet.Atransform.Length; i++)
            //{
            //    //Debug.Log(_MoveClinet .Name+ ":"+_MoveClinet.Atransform.Length);
            //    Animation anim = _MoveClinet.Atransform[i].GetComponent<Animation>();
            //    
            //  //  Debug.Log(_MoveClinet.clip[i].name);
            //    anim.Play(_MoveClinet.clip[i].name);
            //}

            //       AnimationList.Add(anim);
        }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
       // }
    }
}
