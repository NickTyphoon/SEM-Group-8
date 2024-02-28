using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// player moving from side to side
public class movement : MonoBehaviour{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private int coinCount = 0;
    private bool onGround;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }
    
    void Update(){
        //Left and Right Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*moveSpeed, rb.velocity.y);

        //Jumping
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && onGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void FixedUpdate(){
         // Check if the player is grounded
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
        }
    }

    void UpdateScoreText(){
            GameObject.Find("Score").GetComponent<Text>().text = coinCount.ToString();
    }
}
