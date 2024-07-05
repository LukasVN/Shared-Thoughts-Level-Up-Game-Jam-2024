using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentLevel")){
            PlayerPrefs.SetString("CurrentLevel","Tutorial");
        }
    }

    void Update()
    {
        
    }
}
