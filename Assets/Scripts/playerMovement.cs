using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 4;
    [SerializeField]
    float jumpForce = 300;
    [SerializeField]
    bool grounded = false;
    [SerializeField]
    float dashForce = 10;
    [SerializeField]
    float dashTime = 0.8f;
    

    
   public bool isDashing = false;

    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Rigidbody2D myRigidbody;
	// Use this for initialization
	void Start () {
        //this code teleports the gameobject to a new location
        //transform.position = new Vector3(0, 0, 0);

        myRigidbody = GetComponent<Rigidbody2D>();

	}

   private IEnumerator ResetIsDashingAfterTime()
    {
        yield return new WaitForSeconds(dashTime);
        myRigidbody.gravityScale = 1;
        isDashing = false;
    }

    // Update is called once per frame
    void Update () {
        Move();
        Jump();
        DetectGround();
        PlayerDash();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Move()
    {
        if (!isDashing)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            myRigidbody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidbody.velocity.y);
        }
    }


    void DetectGround()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        /*  Collider2D[] groundObjects = Physics2D.OverlapCircleAll(
            groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);

        isOnGround = groundObjects.Length > 0;*/
    }

    private void PlayerDash()
    {
        if (Input.GetButtonDown("Fire1") && !isDashing) 
            //upon pressing space or rmb the player dashes in whatever direction they are facing
            //if the player is not moving in either direction they do nothing
        {
            isDashing = true;

            if (Input.GetAxis("Horizontal") > 0)
            {
                myRigidbody.velocity = new Vector2(dashForce, 0);
                myRigidbody.gravityScale = 0;
                StartCoroutine(ResetIsDashingAfterTime());
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                myRigidbody.velocity = new Vector2((dashForce * -1), 0);
                myRigidbody.gravityScale = 0;
                StartCoroutine(ResetIsDashingAfterTime());
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                isDashing = false;
            }   
        }
    }

  
    //objective
    //create a game in which the player can dash and strike enemies. if the player is not dashing they will
    //"die" and be reset to their starting position upon contact with an enemy if the player is dashing the
    //enemy object will be deleted

    //player's collision handler
   
    
    //how to destroy enemy objects
    

}
