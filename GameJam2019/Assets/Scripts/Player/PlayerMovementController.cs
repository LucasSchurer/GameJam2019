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
    private float velocityXSmoothing;

    public float timeFloating = 0f;
    private const float coyoteEffectTime = 0.15f;
    public bool isCoyoteEffetWorking;
        
    public PlatformMovement2D playerMovement;
    private PlayerInfo playerInfo;

    void Start()
    {
        playerMovement = GetComponent<PlatformMovement2D>();
        playerInfo = GetComponentInParent<PlayerInfo>();    

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
    }

    // Update is called once per frame
    void Update()
    {
        // Reset velocity.y if there's a collision above or below the player
        if (playerMovement.collisions.above || playerMovement.collisions.below && !playerInfo.isJumping)
            velocity.y = 0f;

        // Stores the horizontal and vertical axis
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Change velocity X based on Input and smooth the movement
        float targetVelocityX = input.x * movementSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);

        UpdatePlayerInfo(input);

        isCoyoteEffetWorking = playerInfo.isRunning && !playerInfo.isJumping && timeFloating < coyoteEffectTime;

        if (!playerMovement.collisions.below)
            timeFloating += Time.deltaTime;
        else
            timeFloating = 0f;
                
        // Apply coyote effect
        if (isCoyoteEffetWorking)
            velocity.y = 0f;
        else
            velocity.y += gravity * Time.deltaTime;

        // Jump if space was pressed
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // Move the player
        playerMovement.Move(velocity * Time.deltaTime);

        playerMovement.VerticalCollisions();
    }

    public void Jump()
    {
        if (playerMovement.collisions.below || isCoyoteEffetWorking)
        {
            velocity.y = jumpVelocity;
            playerInfo.isJumping = true;
        }
            
    }

    private void UpdatePlayerInfo(Vector2 input)
    {
        playerInfo.ResetMovement();

        // Check for Y velocity
        if (velocity.y == 0)
        {
            if (input.x != 0)
                playerInfo.isRunning = true;
            else
                playerInfo.isIdle = true;
        }

        if (velocity.y > 0)
            playerInfo.isJumping = true;
        

        if (velocity.y < 0)
            playerInfo.isFalling = true;

    }
}
