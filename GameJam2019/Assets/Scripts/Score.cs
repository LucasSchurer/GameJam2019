using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    private GameManager gameManager;
    private float secondsCount;

    void Start()
    {

        gameManager = GetComponent<GameManager>();

    }

    void Update()
    {
        if(!gameManager.gameEnded)
            UpdateTimerUI();

        Debug.Log(secondsCount);
    }

    void UpdateTimerUI()
    {

        secondsCount += Time.deltaTime % 60;
        
    }
}
