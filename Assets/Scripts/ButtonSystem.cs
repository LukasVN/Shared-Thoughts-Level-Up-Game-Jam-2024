using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject SelectLevelScreen;
    public GameObject settingsScreen;
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public AudioClip clickSound;
    void Start(){
        settingsScreen.SetActive(false);
        SelectLevelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    void Update()
    {
        
    }

    public void onClickPlay(){
        Debug.Log("Clicked Play");
        effectsSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }

    public void onClickTutorial(){
        Debug.Log("Clicked Tutorial");
        effectsSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("Tutorial");
    }

    public void onClickSelectLevelScreen(){
        Debug.Log("Clicked Select Level");
        effectsSource.PlayOneShot(clickSound);
        mainScreen.SetActive(false);
        SelectLevelScreen.SetActive(true);
    }

    public void onClickSettingsScreen(){
        Debug.Log("Clicked Settings Screen");
        effectsSource.PlayOneShot(clickSound);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void onClickMainMenu(){
        effectsSource.PlayOneShot(clickSound);
        settingsScreen.SetActive(false);
        SelectLevelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void onClickLoadLevel(int level){
        effectsSource.PlayOneShot(clickSound);
        Debug.Log($"Level {level} selected");
        SceneManager.LoadScene("Level_"+level);
    }

    public void onClickLunvarian(){
        Application.OpenURL("https://x.com/LunvarianGames");
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
            effectsSource.volume = 0.5f;
        }
        else{
            effectsSource.volume = 0;
        }
        
    }
    
}
