using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : Lever
{
    public Door door;
    public bool isUsed = false;

    public override void InteractLever(PlayerInteractionController player)
    {
        if (!isUsed)
        {
            isUsed = true;
            door.unlockLevel++;
            door.Interact(player);
        } else
        {
            isUsed = false;
            door.unlockLevel--;
            door.Interact(player);
        }
    }
}
