using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles player movement and interaction, including side-to-side movement, jumping, and coin collection.
/// </summary>
public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private int coinCount = 0;
    private bool onGround;

    /// <summary>
    /// Initializes the Rigidbody2D component and updates the score text on start.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }
    
    /// <summary>
    /// Handles player input for left and right movement, as well as jumping.
    /// </summary>
    void Update()
    {
        // Left and Right Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && onGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    /// <summary>
    /// Checks if the player is grounded by casting a ray downwards.
    /// </summary>
    void FixedUpdate()
    {
        // Check if the player is grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        onGround = (hit.collider != null);
    }

    /// <summary>
    /// Handles the player's interaction with coins, updates the score, and triggers a scene change when a certain number of coins is collected.
    /// </summary>
    /// <param name="collision">The collider with which the player interacts.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            coinCount++;
            UpdateScoreText();
            Destroy(collision.gameObject);

            if (coinCount == 10)
            {
                SceneManager.LoadSceneAsync("EndScreen");
            }
        }
    }

    /// <summary>
    /// Updates the score text UI with the current coin count.
    /// </summary>
    void UpdateScoreText()
    {
        GameObject.Find("Number (1)").GetComponent<Text>().text = coinCount.ToString();
    }
}
