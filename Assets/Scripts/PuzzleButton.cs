using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite greenState;
    private Sprite redState;

    //Crate spawning options
    public bool crateSpawner;
    public Transform crateSpawnpoint;
    public GameObject crate;
    private GameObject spawnedCrate;

    //Obstacle remover options
    public bool obstacleManager;
    public List<GameObject> obstacles = new List<GameObject>();

    //Sound
    public AudioClip pressedButton;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        redState = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player" && spriteRenderer.sprite == redState){
            //Sound goes here
            spriteRenderer.sprite = greenState;
            LevelAudioManager.Instance.PlayEffectSound(pressedButton);
            if(crateSpawner){
                SpawnCrate();
            }
            if(obstacleManager){
                RemoveObstacles();
            }
        }
        else if(other.transform.tag == "Player" && spriteRenderer.sprite == greenState){
            //Sound goes here
            spriteRenderer.sprite = redState;
            LevelAudioManager.Instance.PlayEffectSound(pressedButton);
            if(crateSpawner){
                Destroy(spawnedCrate);
            }
            if(obstacleManager){
                ActivateObstacles();
            }
        }
    }

    private void SpawnCrate(){
        spawnedCrate = Instantiate(crate,crateSpawnpoint.position,crate.transform.rotation,transform);
    }

    private void RemoveObstacles(){
        if(obstacles.Count >0){
            foreach (GameObject obstacle in obstacles){
                obstacle.SetActive(false);
            }
        }
        
    }

    private void ActivateObstacles(){
        if(obstacles.Count >0){
            foreach (GameObject obstacle in obstacles){
                obstacle.SetActive(true);
            }
        }
    }
}   
