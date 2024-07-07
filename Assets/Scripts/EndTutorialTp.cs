using UnityEngine;

public class EndTutorialTp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            GameManager.Instance.RemovePlayer(other.gameObject.GetComponent<PlayerMovement>());
            Invoke("DelayedMethod",1f);
        }
    }

    private void DelayedMethod(){
        TutorialManager.Instance.OnCompletedTestStage();
    }

}
