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
        oldVelocity = velocity;

        // Reset velocity.y if there's a collision above or below the player
        if (playerMovement.collisions.above || playerMovement.collisions.below && !playerInfo.isJumping)
            velocity.y = 0f;

        // Stores the horizontal and vertical axis
        Vector2 input = GetMovementInput();

        // Change velocity X based on Input and smooth the movement
        float targetVelocityX = input.x * movementSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);

        UpdatePlayerInfo(input);
        UpdatePlayerFacing();

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
        if (isJumpKeyPressed())
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

    public Vector2 GetMovementInput()
    {
        // Get the player who's is controlling the body movement.
        int playerControlling = 4;
        for (int i = 0; i < playerInfo.numberOfPlayers; i++)
            if (playerInfo.players[i].currentAction == Action.Movement)
                playerControlling = playerInfo.players[i].playerNumber;

        switch (playerControlling)
        {
            case 0:
                {
                    float xAxis = 0f;
                    if (Input.GetKey(KeyCode.D))
                        xAxis += 1f;
                    if (Input.GetKey(KeyCode.A))
                        xAxis -= 1f;

                    float yAxis = 0f;
                    if (Input.GetKey(KeyCode.W))
                        yAxis += 1f;
                    if (Input.GetKey(KeyCode.S))
                        yAxis -= 1f;

                    return new Vector2(xAxis, yAxis);
                }

            case 1:
                {
                    float xAxis = 0f;
                    if (Input.GetKey(KeyCode.RightArrow))
                        xAxis += 1f;
                    if (Input.GetKey(KeyCode.LeftArrow))
                        xAxis -= 1f;

                    float yAxis = 0f;
                    if (Input.GetKey(KeyCode.UpArrow))
                        yAxis += 1f;
                    if (Input.GetKey(KeyCode.DownArrow))
                        yAxis -= 1f;

                    return new Vector2(xAxis, yAxis);
                }

            case 2:
                {
                    return new Vector2(Mathf.RoundToInt(Input.GetAxisRaw("Joy0X")), Mathf.RoundToInt(Input.GetAxisRaw("Joy0Y")));
                }

            case 3:
                {
                    return new Vector2(Mathf.RoundToInt(Input.GetAxisRaw("Joy1X")), Mathf.RoundToInt(Input.GetAxisRaw("Joy1Y")));
                }

            default:
                {
                    return Vector2.zero;
                }
        }
    }

    public bool isJumpKeyPressed()
    {
        // Get the player who's controlling the jump
        int playerControlling = 4;
        for (int i = 0; i < playerInfo.numberOfPlayers; i++)
            if (playerInfo.players[i].currentAction == Action.Jump)
                playerControlling = playerInfo.players[i].playerNumber;

        switch (playerControlling)
        {
            case 0:
                {
                    return (Input.GetKeyDown(KeyCode.W));
                }

            case 1:
                {
                    return (Input.GetKeyDown(KeyCode.UpArrow));
                }

            case 2:
                {
                    return (Mathf.RoundToInt(Input.GetAxisRaw("Joy0Y")) == 1);
                }

            case 3:
                {
                    return (Mathf.RoundToInt(Input.GetAxisRaw("Joy1Y")) == 1);
                }

            default:
                {
                    return false;
                }
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

    private void UpdatePlayerFacing()
    {
        if (oldVelocity.x != velocity.x)
        {
            transform.localScale = new Vector3(Mathf.Sign(velocity.x), 1, 1);
            playerInfo.facing = Mathf.Sign(velocity.x) == 1 ? Direction.Right : Direction.Left;
        }
    }
}