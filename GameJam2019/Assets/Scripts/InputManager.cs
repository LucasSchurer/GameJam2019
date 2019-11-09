using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int numberOfPlayers;
    public PlayerInputManager playerInputManager;
    public GameManager gameManager;

    private Inputs[] inputs;

    void Start()
    {
        this.numberOfPlayers = gameManager.numberOfPlayers;

        inputs = new Inputs[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
            inputs[i] = new Inputs(i);
    }

    void Update()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            for (int j = 0; j < inputs[i].buttons.Length; j++)
            {
                if (Input.GetKeyDown(inputs[i].buttons[j]))
                    playerInputManager.PassInput(j, inputs[i].playerNumber);
            }
        }
    }

    public struct Inputs
    {
        public KeyCode[] buttons;
        public int playerNumber;

        public Inputs(int playerNumber)
        {
            buttons = new KeyCode[5];
            this.playerNumber = playerNumber;

            switch (playerNumber)
            {
                case 0:
                    {
                        buttons[0] = KeyCode.A;
                        buttons[1] = KeyCode.D;
                        buttons[2] = KeyCode.W;
                        buttons[3] = KeyCode.S;
                        buttons[4] = KeyCode.G;

                        break;
                    }

                case 1:
                    {
                        buttons[0] = KeyCode.LeftArrow;
                        buttons[1] = KeyCode.RightArrow;
                        buttons[2] = KeyCode.UpArrow;
                        buttons[3] = KeyCode.DownArrow;
                        buttons[4] = KeyCode.M;

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
