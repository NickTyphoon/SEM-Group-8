using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpCooldown = 1f;  // Set the cooldown time in seconds

    public Rigidbody2D rb;
    public int coinCount = 0;
    public bool onGround;
    private bool canJump = true;  // New variable to track if the player can jump

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Apply clamping to restrict X-axis movement
        float clampedX = Mathf.Clamp(transform.position.x + moveInput * moveSpeed * Time.deltaTime, -15f, 15f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Check if the player is pressing the jump key, is on the ground, and can jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(JumpCooldown());  
        }
    }

    // updated physics
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        onGround = (hit.collider != null);
    }

    // detects when a coin is collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            coinCount++;
            UpdateScoreText();
            Destroy(collision.gameObject);

            if (coinCount == 10)
            {
                PlayerPrefs.SetInt("FinalScore", 10);
                SceneManager.LoadSceneAsync("EndScreen");
            }
        }
    }

    // updates score 
    private void UpdateScoreText()
    {
        GameObject.Find("Number (1)").GetComponent<Text>().text = coinCount.ToString();
    }

    // adds the functionality to the end screen button
    private void EndScreenButton()
    {
        PlayerPrefs.SetInt("FinalScore", coinCount);
        SceneManager.LoadSceneAsync("EndScreen");
    }

    // stops the user being able to keep jumping off the top of the screen
    private IEnumerator JumpCooldown()
    {
        canJump = false;  
        yield return new WaitForSeconds(jumpCooldown);  
        canJump = true;  
    }
}
