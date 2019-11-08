using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformMovement2D))]
public class PlayerMovementController : MonoBehaviour
{
    public float jumpHeight = 4f;
    public float timeToJumpApex = 0.4f;

    public float movementSpeed = 6f;
    public float accelerationTimeAirbone = 0.2f;
    public float accelerationTimeGrounded = 0.1f;

    private float jumpVelocity;
    private float gravity;
    private Vector2 velocity;
    private Vector2 oldVelocity;
    private float velocityXSmoothing;
        
    public PlatformMovement2D playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlatformMovement2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
    }

    // Update is called once per frame
    void Update()
    {
        // Reset velocity.y if there's a collision above or below the player
        if (playerMovement.collisions.above || playerMovement.collisions.below)
            velocity.y = 0f;

        // Stores the horizontal and vertical axis
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Jump if space was pressed
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // Change velocity X based on Input and smooth the movement
        float targetVelocityX = input.x * movementSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);

        velocity.y += gravity * Time.deltaTime;

        // Move the player
        playerMovement.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (playerMovement.collisions.below)
            velocity.y = jumpVelocity;
    }
}
