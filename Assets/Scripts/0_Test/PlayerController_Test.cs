using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Test : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private BodyCollider_Test bodyColliderTest;
    [SerializeField] private FootCollider_Test footColliderTest;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private bool jumpFlag = false;

    [SerializeField] private bool isCanDoubleJump = false;

    [SerializeField] private float gravityScale = 1f;

    [SerializeField] private float gravityLimit = -10f;

    [SerializeField] private float ySpeed = 0f;
    // Start is called before the first frame update


    [SerializeField] public Vector2 animSpeed = Vector2.zero;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (footColliderTest.IsGrounded)
            {
                jumpFlag = true;
                isCanDoubleJump = true; // Allow double jump after jumping from the ground
            }
            else if (isCanDoubleJump)
            {
                jumpFlag = true;
                isCanDoubleJump = false; // Disable double jump after using it
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Animator>().SetTrigger("Event1");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int x_val = Input.GetAxisRaw("Horizontal") > 0 ? 1 : Input.GetAxisRaw("Horizontal") < 0 ? -1 : 0;
        //int y_val = Input.GetAxisRaw("Vertical") > 0 ? 1 : Input.GetAxisRaw("Vertical") < 0 ? -1 : 0;

        

        Vector2 velocity = new Vector2(0,0);
        if (x_val != 0)
        {
            velocity += new Vector2(x_val * speed, 0);
        }
        velocity += bodyColliderTest.speed;

        if (jumpFlag)
        {
            ySpeed = jumpForce;
            jumpFlag = false;
        }
        else
        {
                if (footColliderTest.IsGrounded)
            {
                ySpeed = 0f; // Reset vertical speed when grounded
            }
            else
            {
                ySpeed -= gravityScale * Time.fixedDeltaTime; // Apply gravity
                if (ySpeed < gravityLimit)
                {
                    ySpeed = gravityLimit;
                }
                
            }
        }
        velocity += new Vector2(0, ySpeed);

        velocity += animSpeed;

        

        

        //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        rb.velocity = velocity;

        

        
        
    }
}
