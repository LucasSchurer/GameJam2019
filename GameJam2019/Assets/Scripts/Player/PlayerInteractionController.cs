using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    public PlayerInputs[] playersInputs;


    void Start()
    {
        playerInfo = GetComponentInParent<PlayerInfo>();
        playersInputs = new PlayerInputs[playerInfo.playerNumber];
        for (int i = 0; i < playerInfo.playerNumber; i++)
            playersInputs[i] = new PlayerInputs(i);
    }

    void Update()
    {
        for (int i = 0; i < playersInputs.Length; i++)
        {
            for (int j = 0; j < playersInputs[i].buttons.Length; j++)
            {
                if (Input.GetKeyDown(playersInputs[i].buttons[j]))
                    Debug.Log(playersInputs[i].buttons[j].ToString());
            }
        }
    }

    public struct PlayerInputs
    {
        public KeyCode[] buttons;

        public PlayerInputs(int playerNumber)
        {
            buttons = new KeyCode[5];

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
