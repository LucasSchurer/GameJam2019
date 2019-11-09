using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberOfPlayers = 2;

    void Awake()
    {
        numberOfPlayers = 2;
    }
}
