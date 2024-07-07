using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 spawnPoint;
    private float initialMoveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    public bool freeze = false;
    private SpriteRenderer spriteRenderer;
    public GameObject cooldownBar;
    public Slider cooldownSlider;
    private bool onCooldown;

    private void Start() {

        spawnPoint = transform.position;
        initialMoveSpeed = moveSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.Instance.RegisterPlayer(this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        if(onCooldown && cooldownSlider.value > 0){
            cooldownSlider.value -= Time.deltaTime;
        }
        if(freeze){
            return;
        }
        // Get input from keyboard
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate movement vector
        movement = new Vector2(moveX, moveY);

    }

    private void FixedUpdate() {
        bool isSide = animator.GetBool("isSide");
        bool isBack = animator.GetBool("isBack");
        bool isFront = animator.GetBool("isFront");
        bool flipX = spriteRenderer.flipX;

        if(movement == Vector2.zero){
            ResetAnimations();
        }

        if(freeze){
            return;
        }

        // Check for horizontal movement and set isSide accordingly
        if (movement.x != 0 && !isSide) {
            animator.SetBool("isSide", true);
        } else if (movement.x == 0 && isSide) {
            animator.SetBool("isSide", false);
        }

        // Flip the sprite based on the direction of horizontal movement
        if (movement.x < 0 && !flipX) {
            spriteRenderer.flipX = true;
        } else if (movement.x > 0 && flipX) {
            spriteRenderer.flipX = false;
        }

        // Check for vertical movement and set isBack or isFront accordingly
        if (movement.x == 0 && movement.y > 0 && !isBack) {
            animator.SetBool("isBack", true);
            animator.SetBool("isFront", false);
        } else if (movement.x == 0 && movement.y < 0 && !isFront) {
            animator.SetBool("isFront", true);
            animator.SetBool("isBack", false);
        }

        // Update the velocity of the Rigidbody
        rb.velocity = movement.normalized * moveSpeed * Time.deltaTime;
    }

    public void ResetAnimations(){
        animator.SetBool("isSide", false);
        animator.SetBool("isBack", false);
        animator.SetBool("isFront", false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        switch (other.tag)
        {
            case "Stop": 
                //Sound and indicator
                ResetAnimations();
                transform.position = other.transform.position + new Vector3(0,1,0);
                StartCoroutine(StopPlayer(cooldownSlider.maxValue));
            break;
            case "Spikes": 
                //Death sound
                GameManager.Instance.ResetAllPlayers();
            break;
            case "EndLevel_Tp":
                // Tp sound
                StartCoroutine("FadeOutAnimation");
            break;
        }
    }

    private IEnumerator StopPlayer(float secs){
        freeze = true;
        rb.velocity = Vector2.zero;
        movement = Vector2.zero;
        cooldownBar.SetActive(true);
        cooldownSlider.value = cooldownSlider.maxValue;
        onCooldown = true;
        yield return new WaitForSeconds(secs);
        onCooldown = false;
        freeze = false;
        cooldownBar.SetActive(false);
    }

    private IEnumerator DeathAnimation() {     
        freeze = true;   
        rb.velocity = Vector2.zero;
        movement = Vector2.zero;
        Color spriteColor = spriteRenderer.color;
        
        float fadeDuration = 1.0f; // Duration of the fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteColor.a = alpha;
            spriteRenderer.color = spriteColor;
            yield return null;
        }

        // Ensure the alpha is set to 0 at the end of the animation
        spriteColor.a = 0f;
        spriteRenderer.color = spriteColor;

        StartCoroutine(FadeInAnimation());
    }

    private IEnumerator FadeOutAnimation() {     
        freeze = true;   
        rb.velocity = Vector2.zero;
        movement = Vector2.zero;
        Color spriteColor = spriteRenderer.color;
        
        float fadeDuration = 1.0f; // Duration of the fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteColor.a = alpha;
            spriteRenderer.color = spriteColor;
            yield return null;
        }

        // Ensure the alpha is set to 0 at the end of the animation
        spriteColor.a = 0f;
        spriteRenderer.color = spriteColor;

        gameObject.SetActive(false);

    }

    private IEnumerator FadeInAnimation() {
        transform.position = spawnPoint;
        Color spriteColor = spriteRenderer.color;

        float fadeDuration = 1.0f; // Duration of the fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            spriteColor.a = alpha;
            spriteRenderer.color = spriteColor;
            yield return null;
        }

        // Ensure the alpha is set to 1 at the end of the animation
        spriteColor.a = 1f;
        spriteRenderer.color = spriteColor;

        freeze = false;

    }

    public void ResetPosition(){
        StartCoroutine("DeathAnimation");
    }
}

