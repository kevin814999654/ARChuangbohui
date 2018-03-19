using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip[] BGM;
    private Dictionary<AnimationsObject, AudioClip> BGMDictionary = new Dictionary<AnimationsObject, AudioClip>();
	// Use this for initialization
	void Start () {
        BGMDictionary.Add(AnimationsObject.ShiShan, BGM[0]);
        BGMDictionary.Add(AnimationsObject.HeShan, BGM[1]);
       // BGMDictionary.Add(AnimationsObject.ImageTrack3, BGM[2]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayBGM(SampleImageTargetBehaviour SampleImageTargetBehaviour)
    {
        audioSource.PlayOneShot(BGMDictionary[SampleImageTargetBehaviour.animationsObject]);
    }

    

    public void StopBGM() {
        audioSource.Stop();
    }
}
