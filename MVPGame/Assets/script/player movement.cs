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
            GameObject.Find("Number (1)").GetComponent<Text>().text = coinCount.ToString();
    }



    /*
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("move parameter")]
    public float peed = 8f;
    public float crouchSpeedDivisor = 3f;

    [Header("Jump parameter ")]
    public float jumpForce = 6.3f;
    public float jumpHoldForce = 1.9f;
    public float jumpHoldDuration = 0.1f;
    public float crouchJumpBoost = 2.5f;

    float jumpTime;

    [Header("state")]
    public bool isCrouch;
    public bool isOnGround;
    public bool isJump;

    [Header("environment test")]
    public LayerMask groundLayer;

    float xVelocity;

    //Buttons set
    bool jumpPressed;
    bool jumpHeld;
    bool crouchHeld;

    private int coinCount = 0;

    //Collider size
    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    Vector2 colliderCrouchSize;
    Vector2 colliderCouchOffset;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        colliderStandSize = coll.size;
        colliderStandOffset = coll.offset;
        //colliderCrouchSize = new Vector2(coll.size.x, coll.size.y / 2f);
        //colliderCouchOffset = new Vector2(coll.offset.x, coll.offset.y / 2f);
    }
    void Update()
    {
        jumpPressed = Input.GetButtonDown("Vertical");
        //jumpHeld = Input.GetButton("Jump");
        //crouchHeld = Input.GetButton("Crouch");
        physicsCheck();
        GroundMovement();
        MidAirMovement();

    }

    private void FixedUpdate()
    {
        //physicsCheck();
        //GroundMovement();
        //MidAirMovement();
    }

    void physicsCheck()
    {
        if (coll.IsTouchingLayers(groundLayer))
            isOnGround = true;
        else isOnGround = false;
        {

        }
    }



    void GroundMovement()
    {

        /*if (crouchHeld && !isCrouch && isOnGround)
            Crouch();
        else if (!crouchHeld && isCrouch)
            StandUp();
        else if (!isOnGround && isCrouch)
            StandUp();

        xVelocity = Input.GetAxis("Horizontal");

        /*if (isCrouch)
            xVelocity /= crouchSpeedDivisor;

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        FilpDirction();
    }

    void MidAirMovement()
    {
        if (jumpPressed && isOnGround && !isJump)
        {
            if (jumpPressed && isOnGround)
            {

                StandUp();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            }

            isOnGround = false;
            isJump = true;

            jumpTime = Time.time + jumpHoldDuration;


            rb.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse);
        }

        else if (isJump)
        {
            /*if (jumpHeld)
                rb.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse);
            if (jumpTime < Time.time)
                isJump = false;
        }

    }

    The image direction changes when the player moves left or right
    void FilpDirction()
    {
        if (xVelocity < 0)
            transform.localScale = new Vector2(1, 1);
        else if (xVelocity > 0)
            transform.localScale = new Vector2(-1, 1);
    }

    // Crouch
    /*void Crouch()
    {
        isCrouch = true;
        coll.size = colliderCrouchSize;
        coll.offset = colliderCouchOffset;
    }

    void StandUp()
    {
        isCrouch = false;
        coll.size = colliderStandSize;
        coll.offset = colliderStandOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            coinCount++;
            //int num = int.Parse(GameObject.Find("Number (1)").GetComponent<Text>().text);
            //num++;
            GameObject.Find("Number (1)").GetComponent<Text>().text = coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }
    */
}
