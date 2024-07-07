using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelName : MonoBehaviour
{
    private TextMeshProUGUI levelName;
    void Start()
    {
        levelName = GetComponent<TextMeshProUGUI>();
        levelName.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        
    }
}
