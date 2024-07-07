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

        if(PlayerPrefs.GetString("MuteMusic") == "Muted"){
                musicSource.volume = 0;
        }
        else{
            PlayerPrefs.SetString("MuteMusic","Unmuted");
        }
        
        if(PlayerPrefs.GetString("MuteEffects") == "Muted"){
            effectsSource.volume = 0;
        }
        else{
            PlayerPrefs.SetString("MuteEffects","Unmuted");
        }
        musicSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        musicSource.Play();
    }

    public void PlayEffectSound(AudioClip effect){
        if(effectsSource != null){
            effectsSource.PlayOneShot(effect);
        }
    }

    public void HandleMuteMusic(){
        if(musicSource.volume == 0){
            PlayerPrefs.SetString("MuteMusic","UnMuted");
            musicSource.volume = 0.2f;
        }
        else{
            PlayerPrefs.SetString("MuteMusic","Muted");
            musicSource.volume = 0;
        }
    }

    public void HandleMuteEffects(){
        if(effectsSource.volume == 0){
            PlayerPrefs.SetString("MuteEffects","UnMuted");
            effectsSource.volume = 0.5f;
        }
        else{
            PlayerPrefs.SetString("MuteEffects","UnMuted");
            effectsSource.volume = 0;
        }
        
    }


}
