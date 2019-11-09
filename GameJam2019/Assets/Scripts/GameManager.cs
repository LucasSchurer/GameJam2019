using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject madnessWorld;
    public GameObject normalWorld;

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
