using System.Collections.Generic;
using UnityEngine;

public class LevelAudioManager : MonoBehaviour
{
    public static LevelAudioManager Instance;
    public List<AudioClip> audioClips= new List<AudioClip>();
    public AudioSource musicSource;
    public AudioSource effectsSource;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        // musicSource = GetComponent<AudioSource>();
        // effectsSource = GetComponent<AudioSource>();
        musicSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        musicSource.Play();
    }

    void Update()
    {
        
    }

    public void PlayEffectSound(AudioClip effect){
        effectsSource.PlayOneShot(effect);
    }

    public void HandleMuteMusic(){
        if(musicSource.volume == 0){
            musicSource.volume = 0.2f;
        }
        else{
            musicSource.volume = 0;
        }
    }

    public void HandleMuteEffects(){
        if(effectsSource.volume == 0){
            effectsSource.volume = 0.2f;
        }
        else{
            effectsSource.volume = 0;
        }
        
    }


}
