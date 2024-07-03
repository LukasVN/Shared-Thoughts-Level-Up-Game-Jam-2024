using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPlay(){
        Debug.Log("Clicked Play");
    }

    public void onClickSelectLevelScreen(){
        Debug.Log("Clicked Select Level");
    }

    public void onClickSettingsScreen(){
        Debug.Log("Clicked Settings Screen");
    }
}
