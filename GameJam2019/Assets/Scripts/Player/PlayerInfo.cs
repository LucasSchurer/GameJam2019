
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameManager gameManager;
    
    public int numberOfPlayers = 2;
    public Player[] players;

    public bool isInMadnessDimension = false;
    
    public bool isIdle;
    public bool isRunning;
    public bool isJumping;
    public bool isFalling;

    public float jumpCooldown = 2.5f;
    public float dimensionChangeCooldown = 5f;

    public float jumpCooldownLeft;
    public float dimensionChangeCooldownLeft;

    public bool canJump;
    public bool canChangeDimension;

    public Direction facing;

    void Awake()
    {
        players = new Player[numberOfPlayers];
        for (int i = 0; i < players.Length; i++)
            players[i] = new Player(i, numberOfPlayers);
    }

    void Update()
    {
        /*for (int i = 0; i < numberOfPlayers; i++)
        {
            Debug.Log("Player " + (i + 1) + "\nCurrentAction: " + players[i].currentAction.ToString());
            Debug.Log("AvailableActions: " + (Action)players[i].availableActions.x + ", " + (Action)players[i].availableActions.y);
        }*/

        jumpCooldownLeft = jumpCooldownLeft > 0 ? jumpCooldownLeft - Time.deltaTime : 0;

        dimensionChangeCooldownLeft = dimensionChangeCooldownLeft > 0 ? dimensionChangeCooldownLeft - Time.deltaTime : 0;

        canJump = jumpCooldownLeft == 0;
        canChangeDimension = dimensionChangeCooldownLeft == 0;
    }

    public void ResetMovement()
    {
        isIdle = false;
        isRunning = false;
        isJumping = false;
        isFalling = false;
    }

    public void RandomizeActions()
    {
        if (numberOfPlayers == 2)
        {
            Vector2 availabeActionsAux = players[0].availableActions;
            players[0].availableActions = players[1].availableActions;
            players[1].availableActions = availabeActionsAux;

            players[0].UpdateCurrentAction(0);
            players[1].UpdateCurrentAction(0);

            return;
        }

        players[0].availableActions = new Vector2(3, 3);
        players[1].availableActions = new Vector2(2, 2);
        players[2].availableActions = new Vector2(1, 1);
        players[3].availableActions = new Vector2(0, 0);

        players[0].UpdateCurrentAction(0);
        players[1].UpdateCurrentAction(0);
        players[2].UpdateCurrentAction(0);
        players[3].UpdateCurrentAction(0);
    }

    public void Kill()
    {
        gameManager.gameEnded = true;
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

public enum Action { Movement, Jump, Interact, ChangeDimension };
public enum Direction { Left, Right };
