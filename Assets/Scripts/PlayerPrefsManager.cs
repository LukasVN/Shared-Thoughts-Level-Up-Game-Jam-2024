using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentLevel")){
            PlayerPrefs.SetString("CurrentLevel","Tutorial");
            return;
        }

        if(!PlayerPrefs.HasKey("Level_1")){
            PlayerPrefs.SetString("CurrentLevel","Level_1");
            return;
        }


        if(!PlayerPrefs.HasKey("Level_2")){
            PlayerPrefs.SetString("CurrentLevel","Level_2");
            return;
        }


        if(!PlayerPrefs.HasKey("Level_3")){
            PlayerPrefs.SetString("CurrentLevel","Level_3");
            return;
        }

        if(!PlayerPrefs.HasKey("Level_4")){
            PlayerPrefs.SetString("CurrentLevel","Level_4");
            return;
        }

        if(!PlayerPrefs.HasKey("Level_5")){
            PlayerPrefs.SetString("CurrentLevel","Level_5");
            return;
        }

        PlayerPrefs.SetString("CurrentLevel","Tutorial");

    }

}
