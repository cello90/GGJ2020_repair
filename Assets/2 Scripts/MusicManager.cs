using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public float musicFade = 0.5f;

    //Ambience Settings
    private AudioSource _mp;
    private AudioSource _ap;
    private AudioClip newMusic;
    private AudioClip newAmbience;
    private bool changingMusic;
    private bool changingAmbience;
    private AudioSource[] sounds = new AudioSource[0];

    // Start is called before the first frame update
    void Start()
    {
        _mp = gameObject.AddComponent<AudioSource>();
        _ap = gameObject.AddComponent<AudioSource>();
    }


    public void SetMusic(AudioClip music)
    {
        if (music != _mp.clip)
        {
            changingMusic = true;
            newMusic = music;
        }
    }
    public void SetAmbience(AudioClip ambience)
    {
        if (ambience != _mp.clip)
        {
            changingAmbience = true;
            newAmbience = ambience;
        }
    }

    public void PlaySound(AudioClip sound)
    {
        AudioSource newSound = gameObject.AddComponent<AudioSource>();
        newSound.clip = sound;
        newSound.Play();
        AudioSource[] temp = sounds;
        sounds = new AudioSource[temp.Length + 1];
        int i = 0;
        while (i < temp.Length) {
            sounds[i] = temp[i];
        }
        sounds[temp.Length] = newSound;

    }

    // Update is called once per frame
    void Update()
    {
        if (changingMusic)
        {
            if (_mp.clip == newMusic)
            {
                _mp.volume += musicFade * Time.deltaTime;
                if (_mp.volume >= 1)
                {
                    changingMusic = false;
                    _mp.volume = 1;
                }
            }
            else
            {
                _mp.volume -= musicFade * Time.deltaTime;
                if (_mp.volume <= 0 )
                {
                    _mp.volume = 0;
                    _mp.clip = newMusic;
                    _mp.loop = true;
                    _mp.Play();
                }
            }
        }
        if (changingAmbience)
        {
            if (_ap.clip == newAmbience)
            {
                _ap.volume += musicFade * Time.deltaTime;
                if (_ap.volume >= 1)
                {
                    changingAmbience = false;
                    _ap.volume = 1;
                }
            }
            else
            {
                _ap.volume -= musicFade * Time.deltaTime;
                if (_ap.volume <= 0)
                {
                    _ap.volume = 0;
                    _ap.clip = newAmbience;
                    _ap.loop = true;
                    _ap.Play();
                }
            }
        }
        for(var i = 0; i < sounds.Length; i++)
        {
            if (!sounds[i].isPlaying)
            {
                Destroy(sounds[i]);
            }
        }
    }
}
