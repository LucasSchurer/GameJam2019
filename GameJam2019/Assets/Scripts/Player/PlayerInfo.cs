
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int numberOfPlayers = 2;
    public Player[] players;

    public bool isIdle;
    public bool isRunning;
    public bool isJumping;
    public bool isFalling;

    void Start()
    {
        players = new Player[numberOfPlayers];
        for (int i = 0; i < players.Length; i++)
            players[i] = new Player(i, numberOfPlayers);
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
        public int totalPlayers;
        public int playerNumber;
        public Action currentAction;

        public Vector2 availableActions;

        public Player(int playerNumber, int totalPlayers)
        {
            this.totalPlayers = totalPlayers;
            this.playerNumber = playerNumber;

            availableActions = totalPlayers <= 2 ? (playerNumber == 0 ? new Vector2(0, 2) : new Vector2(1, 3)) : new Vector2(playerNumber, playerNumber);

            currentAction = Action.Jump;
            UpdateCurrentAction(0);
        }
    
        public void UpdateCurrentAction(int availableActionNumber)
        {
            int targetAvailableAction = availableActionNumber == 0 ? (int)availableActions.x : (int)availableActions.y;

            currentAction = (Action)targetAvailableAction;
        }

        public void SwitchAction()
        {
            int desiredAvailableAction = (int)currentAction == (int)availableActions.x ? 1 : 0;
            UpdateCurrentAction(desiredAvailableAction);
        }
    }
}

public enum Action { Movement, Jump, Shoot, MadnessWorld };