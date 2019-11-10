using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;
    public GameObject madnessWorld;
    public GameObject normalWorld;

    void Update()
    {
        if (gameEnded)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeDimension(Dimension dimension)
    {
        if (madnessWorld.activeSelf && normalWorld.activeSelf)
        {
            madnessWorld.SetActive(false);
            return;
        }

        if (dimension == Dimension.Normal) 
        {
            normalWorld.SetActive(true);
            madnessWorld.SetActive(false);
            return;
        }

        if (dimension == Dimension.Madness)
        {
            madnessWorld.SetActive(true);
            normalWorld.SetActive(false);
            return;
        }
    }
}

public enum Dimension { Normal, Madness };
