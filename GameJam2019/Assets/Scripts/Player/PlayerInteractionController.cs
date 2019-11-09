using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private BoxCollider2D coll;
    public LayerMask interactionMask;


    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        SwitchAction();
        ChangeDimension();

        if (isInteractionKeyPressed())
            Interact();
    }

    public void ChangeDimension()
    {
        // Get the player who's controlling the dimension change
        int playerControlling = 4;
        for (int i = 0; i < playerInfo.numberOfPlayers; i++)
            if (playerInfo.players[i].currentAction == Action.ChangeDimension)
                playerControlling = playerInfo.players[i].playerNumber;

        switch (playerControlling)
        {
            case 0:
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Madness);
                        playerInfo.isInMadnessDimension = true;
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        playerInfo.isInMadnessDimension = false;
                        break;
                    }

                    break;
                }

            case 1:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Madness);
                        playerInfo.isInMadnessDimension = true;
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        playerInfo.isInMadnessDimension = false;
                        break;
                    }

                    break;
                }

            case 2:
                {
                    float input = Mathf.RoundToInt(Input.GetAxis("Joy0Y"));

                    if (input == 1)
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Madness);
                        playerInfo.isInMadnessDimension = true;
                        break;
                    }

                    if (input == -1)
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        playerInfo.isInMadnessDimension = false;
                        break;
                    }

                    break;
                }

            case 3:
                {
                    float input = Mathf.RoundToInt(Input.GetAxis("Joy1Y"));

                    if (input == 1)
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Madness);
                        playerInfo.isInMadnessDimension = true;
                        break;
                    }

                    if (input == -1)
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        playerInfo.isInMadnessDimension = false;
                        break;
                    }

                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    public void SwitchAction()
    {
        for (int i = 0; i < playerInfo.numberOfPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    {
                        if (Input.GetKeyDown(KeyCode.G))
                            playerInfo.players[i].SwitchAction();

                        break;
                    }

                case 1:
                    {
                        if (Input.GetKeyDown(KeyCode.M))
                            playerInfo.players[i].SwitchAction();

                        break;
                    }

                case 2:
                    {
                        break;
                    }

                case 3:
                    {
                        break;
                    }
            }
        }
    }

    public void Interact()
    {
        float directionX = playerInfo.facing == Direction.Left ? -1 : 1;
        float rayLength = 1f;

        int rayCount = 4;
        float raySpacing = coll.bounds.size.y / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            Vector2 rayOrigin = new Vector2(directionX == 1 ? coll.bounds.min.x : coll.bounds.max.x, coll.bounds.max.y);
            rayOrigin += Vector2.down * (raySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, interactionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.blue);

            if (hit)
            {
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
                interactiveObject.Interact(this);
            }
        }
    }

    public bool isInteractionKeyPressed()
    {
        // Get the player who's controlling the interact button
        int playerControlling = 4;
        for (int i = 0; i < playerInfo.numberOfPlayers; i++)
            if (playerInfo.players[i].currentAction == Action.Interact)
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
                    return (Mathf.RoundToInt(Input.GetAxis("Joy0Y")) == 1);
                }

            case 3:
                {
                    return (Mathf.RoundToInt(Input.GetAxis("Joy1Y")) == 1);
                }

            default:
                {
                    return false;
                }
        }
    }
}



