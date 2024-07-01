using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
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

