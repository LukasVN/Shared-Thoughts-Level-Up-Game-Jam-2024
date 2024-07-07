using UnityEngine;
using UnityEngine.UI;

public class SelectableLevel : MonoBehaviour
{
    private Button button;
    public int level;
    void Start()
    {
        button = GetComponent<Button>();
        if(PlayerPrefs.HasKey("Level_"+level)){
            button.interactable = true;
        }
        else{
            button.interactable = false;
        }
    }

}
