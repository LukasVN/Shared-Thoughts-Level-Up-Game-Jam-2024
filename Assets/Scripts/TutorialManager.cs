using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;
    public GameObject currentStage;
    public List<GameObject> stage2 = new List<GameObject>();

    private void Awake() {
        Instance = this;
    }
    void Start(){
        
    }

    void Update()
    {
        
    }

    public void OnCompletedTestStage(){
        DialogueManager.Instance.currentDialogIndex = 0;
        DialogueManager.Instance.dialogSequenceIndex = 1;
        ActivateStage();
        DialogueManager.Instance.StartDialog();
        DialogueManager.Instance.DisplayNextDialog();
    }

    private void ActivateStage(){
        foreach (GameObject item in stage2){
            item.SetActive(true);
        }
        currentStage.SetActive(false);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players){
            GameManager.Instance.RegisterPlayer(player.GetComponent<PlayerMovement>());
        }
        GameManager.Instance.FreezeAllPlayers();
    }

}
