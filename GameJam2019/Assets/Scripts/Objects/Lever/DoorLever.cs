using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : Lever
{
    public GameObject door;

    public override void InteractLever(PlayerInteractionController player)
    {
        changeAvailability();

        if (door.activeSelf)
        {
            door.SetActive(false);
            return;
        }
        else
        {
            door.SetActive(true);
            return;
        }
    }
}
