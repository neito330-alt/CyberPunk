using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Test : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private BodyCollider_Test bodyColliderTest;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private float gravityScale = 1f;

    [SerializeField] private float gravityLimit = -10f;

    [SerializeField] private float ySpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ySpeed = jumpForce; // Apply jump force
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

        ySpeed -= gravityScale * Time.fixedDeltaTime;
        if (ySpeed < gravityLimit)
        {
            ySpeed = gravityLimit;
        }

        velocity += new Vector2(0, ySpeed);

        //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        rb.velocity = velocity;

        

        
        
    }
}
