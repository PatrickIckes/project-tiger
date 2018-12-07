﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private Collider2D playerGroundCollider;

    [SerializeField]
    private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;

    [SerializeField]
    private Collider2D groundDetectTrigger;

    private Checkpoint currentCheckpoint;
    private float horizontalInput;
    private bool isOnGround;
    public bool isDead = false;
    public bool hasRing = false;
    private Collider2D[] groundHitDetectionResults = new Collider2D[32];
    bool facingRight = true;
    private int scoreCount;
    public Text countText;
    public Text deathText;
    

    Animator anim;
    bool grounded = false;
    //public Transform groundCheck;
    //float groundRadius = 0.2f;
    //public LayerMask whatIsGround;

    [SerializeField]
    private float jumpForce = 10;

    [SerializeField]
    private float accelerationforce = 5;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scoreCount = 0;
        SetScoreCount();
        
    }
    // Update is called once per frame
    void Update()
    {
        UpdateIsOnGround();
        UpdateHorizontalInput();
        HandleJumpInput();
        AreTheyDead();

        if (horizontalInput > 0 && !facingRight)
            Flip();
        else if (horizontalInput < 0 && facingRight)
            Flip();

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if(isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
        }


    }
    private void FixedUpdate()
    {
        UpdatePhysicsMaterial();
        Move();

        anim.SetBool("Ground", isOnGround);
        anim.SetFloat("vSpeed", rb2d.velocity.y);
    }

    private void UpdatePhysicsMaterial()
    {
        if(Mathf.Abs(horizontalInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
        }
        else
        {
            playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
        }
    }
    private void UpdateIsOnGround()
    {
        isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;
        // Debug.Log("IsOnGround?: " + isOnGround);

    }
    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") & isOnGround)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Move()
    {
        rb2d.AddForce(Vector2.right * horizontalInput * accelerationforce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void AreTheyDead()
    {
        switch (isDead)
        {
            case false:

                break;

            case true:

                //Time.timeScale = 0;
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("isDead", true);
                deathText.text = "Press R to respawn";
                //rb2d.

                if (Input.GetKeyUp(KeyCode.R))
                {
                    isDead = false;
                    Debug.Log("R key pressed");
                    //Time.timeScale = 1;
                    Unfreeze();
                    Respawn();
                }
                break;
        }
    }
    public void Respawn()
    {

        deathText.text = " ";
            if (currentCheckpoint == null)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
            {
                rb2d.velocity = Vector2.zero;
                transform.position = currentCheckpoint.transform.position;
            }
    }
    public void Unfreeze()
    {
        anim.SetBool("isDead", false);
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void SetScoreCount()
    {
        countText.text = "Count: " + scoreCount.ToString();
        deathText.text = " ";
    }
    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {
        if(currentCheckpoint != null)
            currentCheckpoint.SetIsActivated(false);

        currentCheckpoint = newCurrentCheckpoint;
        currentCheckpoint.SetIsActivated(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            scoreCount++;
            SetScoreCount();
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            isDead = true;
        }

        if (other.gameObject.CompareTag("Ring"))
        {
            other.gameObject.SetActive(false);
            hasRing = true;
            Debug.Log("Ring!");

            
        }
    }
}
