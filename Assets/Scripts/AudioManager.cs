using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> {

	public AudioClip playerTakesDamage ;
    public AudioClip playerShoots;
    public AudioClip bulletHits;


	int audioSourcesForFx = 3;
	int clipsPerAudioSource = 5;
	List<AudioSource> audioSources = new List<AudioSource>();
	
	int audioClipCounter;

	void Start () {
		for (int i = 0 ; i < audioSourcesForFx;i++)
			audioSources.Add(gameObject.AddComponent<AudioSource>());
	}

    public static void PlayOneShot(AudioClip clip)
    {
        Instance.audioSources[Instance.audioClipCounter /Instance.clipsPerAudioSource].PlayOneShot (clip);
        Instance.audioClipCounter = (Instance.audioClipCounter + 1) % 
			(Instance.audioSourcesForFx * Instance.clipsPerAudioSource);
    }

}