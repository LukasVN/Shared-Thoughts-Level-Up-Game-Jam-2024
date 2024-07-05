using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<PlayerMovement> playerPool;
    public bool playersFrozen;
    public GameObject test1;
    public GameObject test2;

    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            test1.SetActive(true);
            test2.SetActive(true);
            if(DialogueManager.Instance.onDialogue){
                FreezeAllPlayers();
            }
        }
    }

    public void RegisterPlayer(PlayerMovement player){
        playerPool.Add(player);
    }

    public void RemovePlayer(PlayerMovement player){
        playerPool.Remove(player);
    }

    public void FreezeAllPlayers(){
        playersFrozen = true;
        foreach(PlayerMovement player in playerPool){
            player.freeze = true;
        }
    }

    public void UnFreezeAllPlayers(){
        playersFrozen = false;
        foreach(PlayerMovement player in playerPool){
            player.freeze = false;
        }
    }

}
