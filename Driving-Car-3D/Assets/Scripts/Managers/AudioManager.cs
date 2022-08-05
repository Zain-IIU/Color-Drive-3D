using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] sounds;

    AudioSource source;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        EventsManager.OnCarCollision += PlayHitSfx;
        EventsManager.OnGameWin += PlayWinSfx;
        EventsManager.OnGameLose += PlayLoseSfx;
    }

    private void OnDisable()
    {
        EventsManager.OnCarCollision -= PlayHitSfx;
        EventsManager.OnGameWin -= PlayWinSfx;
        EventsManager.OnGameLose -= PlayLoseSfx;
    }
    
   

    public void Play(string sound)
    {
        var s = Array.Find(sounds, item => item.name == sound);

        source.loop = s.loop;
        source.clip = s.clip;
        source.volume = s.volum;
        source.pitch = s.pitch;
        source.Play();
        
    }
   

    #region Event Callbacks
    private void PlayHitSfx()
    {
        Play("Hit");
    }

    private void PlayWinSfx()
    {
        Play("Win");
    }

    private void PlayLoseSfx()
    {
        Play("Lose");
    }
    #endregion
 
    
}