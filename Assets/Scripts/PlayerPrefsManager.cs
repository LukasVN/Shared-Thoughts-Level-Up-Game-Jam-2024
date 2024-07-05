using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentLevel")){
            PlayerPrefs.SetString("CurrentLevel","Tutorial");
        }

        // if(SceneManager.GetActiveScene().name != "Tutorial" || SceneManager.GetActiveScene().name != "Main_Menu"){
        //     PlayerPrefs.SetString("CurrentLevel",SceneManager.GetActiveScene().name);
        // }
    }

    void Update()
    {
        
    }
}
