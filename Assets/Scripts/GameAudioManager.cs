using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private float musicVolume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void updateVolume(float vol)
    {
        musicVolume = vol;
    }
}
