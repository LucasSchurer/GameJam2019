using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public Sprite movement;
    public Sprite jump;
    public Sprite interact;
    public Sprite dimensionChange;

    void Start()
    {
    }

    public Sprite returnAbilitySprite(int abilityNumber)
    {
        switch (abilityNumber)
        {
            case 0:
                {
                    return movement;
                }

            case 1:
                {
                    return jump;
                }

            case 2:
                {
                    return interact;
                }

            case 3:
                {
                    return dimensionChange;
                }

            default:
                {
                    return null;
                }
        }
    }
}
