using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject completedScreen;
    public List<PlayerMovement> playerPool;
    public bool playersFrozen;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI effectsText;
    public int levelPlayerCount;
    public int succesfulPlayers = 0;
    public string nextLevel;

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
            player.gameObject.SetActive(true);
            player.ResetPosition();
            succesfulPlayers = 0;
        }
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Main_Menu");
    }

    public void ResetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MuteMusic(){
        if(musicText.text == "Unmute Music"){
            musicText.text = "Mute Music";
        }
        else{
            musicText.text = "Unmute Music";
        }
        LevelAudioManager.Instance.HandleMuteMusic();
    }

    public void MuteSFX(){
        if(effectsText.text == "Unmute SFX"){
            effectsText.text = "Mute SFX";
        }
        else{
            effectsText.text = "Unmute SFX";
        }
        LevelAudioManager.Instance.HandleMuteEffects();
    }

    public void NextLevel(){
        if(nextLevel == "End"){
            return;
        }
        SceneManager.LoadScene(nextLevel);
    }

    public void SuccesfullPlayerRoom(){
        succesfulPlayers++;
        if(succesfulPlayers == levelPlayerCount){
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name,"Completed");
            completedScreen.SetActive(true);
        }
    }

}
