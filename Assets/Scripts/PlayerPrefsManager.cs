using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentLevel")){
            PlayerPrefs.SetString("CurrentLevel","Tutorial");
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


        if(!PlayerPrefs.HasKey("Level_6")){
            PlayerPrefs.SetString("CurrentLevel","Level_6");
            return;
        }


        if(!PlayerPrefs.HasKey("Level_7")){
            PlayerPrefs.SetString("CurrentLevel","Level_7");
            return;
        }


        if(!PlayerPrefs.HasKey("Level_8")){
            PlayerPrefs.SetString("CurrentLevel","Level_8");
            return;
        }

        if(!PlayerPrefs.HasKey("Level_9")){
            PlayerPrefs.SetString("CurrentLevel","Level_9");
            return;
        }

        if(!PlayerPrefs.HasKey("Level_10")){
            PlayerPrefs.SetString("CurrentLevel","Level_10");
            return;
        }

        PlayerPrefs.SetString("CurrentLevel","Tutorial");

    }

}
