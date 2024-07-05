using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    public bool freeze = false;
    // private bool alreadyEnabled;

    private void Start() {
        // alreadyEnabled = true;
        GameManager.Instance.RegisterPlayer(this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // private void OnEnable() {
    //     if(!alreadyEnabled &&!GameManager.Instance.playerPool.Contains(this)) {
    //         GameManager.Instance.RegisterPlayer(this);
    //         alreadyEnabled = true;
    //     }
    // }

    // private void OnDisable() {
    //     if(alreadyEnabled && GameManager.Instance.playerPool.Contains(this)){
    //         GameManager.Instance.RemovePlayer(this);
    //     }
    // }

    private void Update(){
        if(freeze){
            return;
        }
        // Get input from keyboard
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate movement vector
        movement = new Vector2(moveX, moveY);

        // Apply movement

        // Clamp the position to keep the object within screen bounds
        // Vector3 clampedPosition = transform.position;
        // clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8f, 8f); // Adjust these values based on your screen size
        // clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.5f, 4.5f); // Adjust these values based on your screen size
        // transform.position = clampedPosition;
    }

    private void FixedUpdate() {
        if(movement != Vector2.zero){
            animator.SetBool("isMoving", true);
        }
        else if(animator.GetBool("isMoving")){
            animator.SetBool("isMoving", false);
        }
        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }
}

