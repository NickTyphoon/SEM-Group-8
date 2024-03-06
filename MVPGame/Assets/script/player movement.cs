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
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if the player is pressing the jump key, is on the ground, and can jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(JumpCooldown());  // Start the jump cooldown
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        onGround = (hit.collider != null);
    }

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

    private void UpdateScoreText()
    {
        GameObject.Find("Number (1)").GetComponent<Text>().text = coinCount.ToString();
    }

    private void EndScreenButton()
    {
        PlayerPrefs.SetInt("FinalScore", coinCount);
        SceneManager.LoadSceneAsync("EndScreen");
    }

    private IEnumerator JumpCooldown()
    {
        canJump = false;  // Set the flag to false
        yield return new WaitForSeconds(jumpCooldown);  // Wait for the cooldown duration
        canJump = true;  // Set the flag to true after the cooldown
    }
}
