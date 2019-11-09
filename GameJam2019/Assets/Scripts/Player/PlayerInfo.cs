
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameManager gameManager;
    
    public int numberOfPlayers = 2;
    public Player[] players;

    public bool isIdle;
    public bool isRunning;
    public bool isJumping;
    public bool isFalling;

    public Direction facing;

    void Start()
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

        Action[] actions = new Action[4];

        for (int i = 0; i < 4; i++)
            actions[i] = (Action)i;

        if (numberOfPlayers == 4)
        {
            players[2].currentAction = Action.Movement;
            players[0].currentAction = Action.ChangeDimension;
            players[1].currentAction = Action.Jump;
        }
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
