using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public GameManager gameManager;

    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
    }

    void Update()
    {
        SwitchAction();
        ChangeDimension();
    }

    public void ChangeDimension()
    {
        // Get the player who's controlling the jump
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
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        break;
                    }
                        
                    break;
                }

            case 1:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Madness);
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        playerInfo.gameManager.ChangeDimension(Dimension.Normal);
                        break;
                    }

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

    
}

