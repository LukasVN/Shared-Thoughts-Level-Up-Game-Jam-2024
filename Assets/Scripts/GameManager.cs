using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<PlayerMovement> playerPool;
    public bool playersFrozen;

    private void Awake() {
        Instance = this;
    }

    void Start(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 61;
        
    }

    void Update(){

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

    public void ResetAllPlayers(){
        foreach(PlayerMovement player in playerPool){
            player.ResetPosition();
        }
    }

}
