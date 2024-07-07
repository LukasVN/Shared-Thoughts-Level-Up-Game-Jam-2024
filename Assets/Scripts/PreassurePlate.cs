using System.Collections.Generic;
using UnityEngine;

public class PreassurePlate : MonoBehaviour
{
    private bool activated;
    private bool playerIn;
    private SpriteRenderer spriteRenderer;
    private Sprite unpressedState;
    public Sprite pressedState;

    //Crate spawning options
    public bool crateSpawner;
    public Transform crateSpawnpoint;
    public GameObject crate;
    private GameObject spawnedCrate;

    //Obstacle remover options
    public bool obstacleManager;
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> removedObstacles = new List<GameObject>();
    
    //Sound
    public AudioClip pressedPlate;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        unpressedState = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            playerIn = true;
            if(spriteRenderer.sprite != pressedState){
                spriteRenderer.sprite = pressedState;
                LevelAudioManager.Instance.PlayEffectSound(pressedPlate);
                if(obstacleManager){
                    RemoveObstacles();
                }
                if(crateSpawner){
                    SpawnCrate();
                }
            }
        }
        else if(other.tag == "Crate"){
            activated = true;
            if(spriteRenderer.sprite != pressedState){
                spriteRenderer.sprite = pressedState;
                LevelAudioManager.Instance.PlayEffectSound(pressedPlate);
                if(obstacleManager){
                    RemoveObstacles();
                }
                if(crateSpawner){
                    SpawnCrate();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(activated && other.tag == "Crate"){
            activated = false;
        }
        if(playerIn && other.tag == "Player"){
            playerIn = false;
        }
        if(!playerIn && !activated && spriteRenderer.sprite != unpressedState){
            spriteRenderer.sprite = unpressedState;
            LevelAudioManager.Instance.PlayEffectSound(pressedPlate);
            if(obstacleManager){
                ActivateObstacles();
            }
            if(crateSpawner){
                Destroy(spawnedCrate);
            }
        }
    }

    private void SpawnCrate(){
        spawnedCrate = Instantiate(crate,crateSpawnpoint.position,crate.transform.rotation);
    }

    private void RemoveObstacles(){
        foreach (GameObject obstacle in obstacles){
            obstacle.SetActive(false);
        }
        foreach (GameObject removedObstacle in removedObstacles){
            removedObstacle.SetActive(true);
        }
    }

    private void ActivateObstacles(){
        foreach (GameObject obstacle in obstacles){
            obstacle.SetActive(true);
        }
        foreach (GameObject removedObstacle in removedObstacles){
            removedObstacle.SetActive(false);
        }
    }

    
}
