using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject SelectLevelScreen;
    public GameObject settingsScreen;
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
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }

    public void onClickTutorial(){
        Debug.Log("Clicked Tutorial");
        SceneManager.LoadScene("Tutorial");
    }

    public void onClickSelectLevelScreen(){
        Debug.Log("Clicked Select Level");
        mainScreen.SetActive(false);
        SelectLevelScreen.SetActive(true);
    }

    public void onClickSettingsScreen(){
        Debug.Log("Clicked Settings Screen");
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void onClickMainMenu(){
        settingsScreen.SetActive(false);
        SelectLevelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void onClickLoadLevel(int level){
        Debug.Log($"Level {level} selected");
        SceneManager.LoadScene("Level_"+level);
    }
}
