using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameManager gameManager;
    public Player[] players;

    public bool isIdle;
    public bool isRunning;
    public bool isJumping;
    public bool isFalling;

    void Start()
    {
        players = new Player[gameManager.numberOfPlayers];
        for (int i = 0; i < players.Length; i++)
            players[i] = new Player(i);
    }

    public void ResetMovement()
    {
        isIdle = false;
        isRunning = false;
        isJumping = false;
        isFalling = false;
    }

    public struct Player
    {
        public int playerNumber;
        public int actionNumber;
        public Vector2 availableActions;

        public Player(int playerNumber)
        {
            this.playerNumber = Mathf.Clamp(playerNumber, 0, 3);

            availableActions = playerNumber == 0 ? new Vector2(0, 2) : new Vector2(1, 3);

            this.actionNumber = (int)availableActions.x;
        }
    }
}
