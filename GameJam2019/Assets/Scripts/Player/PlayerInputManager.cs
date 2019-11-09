using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private PlayerMovementController playerMovement;

    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        playerMovement = GetComponent<PlayerMovementController>();
    }

    public void PassInput(int button, int playerNumber)
    {

        PlayerInfo.Player player = playerInfo.players[playerNumber];

        // Act based on which action the player can use.
        // 0 - Walk
        // 1 - Jump
        // 2 - Shoot
        // 3 - Madness World
        // 4 - Change action
        switch (player.actionNumber)
        {
            case 0:
                {
                    int direction = button == 0 ? -1 : 1;
                    playerMovement.Move(direction);

                    break;
                }

            case 1:
                {
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

            case 4:
                {
                    break;
                }
        }
    }
}
