using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int playerNumber = 2;

    public bool isIdle;
    public bool isRunning;
    public bool isJumping;
    public bool isFalling;

    public void ResetMovement()
    {
        isIdle = false;
        isRunning = false;
        isJumping = false;
        isFalling = false;
    }
}
