using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioSource[] musicSources;
    public int musicBPM, timeSignature, barsLength;

    private float loopPointMinutes, loopPointSeconds;
    private double time;
    private int nextSource;

    private float musicVolume = .15f;

    // Start is called before the first frame update
    void Start()
    {
        loopPointMinutes = (barsLength * timeSignature) / musicBPM;

        loopPointSeconds = loopPointMinutes * 60;

        time = AudioSettings.dspTime;

        musicSources[0].Play();
        nextSource = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSources[nextSource].isPlaying)
        {
            time = time + loopPointSeconds;

            musicSources[nextSource].PlayScheduled(time);

            nextSource = 1 - nextSource; //Switch to other AudioSource
        }
        
        foreach(AudioSource audioSource in musicSources)
        {
            audioSource.volume = musicVolume;
        }
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
