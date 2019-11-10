using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDoor : Door
{
    public override void changeAvailability()
    {
        isAvailable = true;
    }

    public override void InteractDoor(PlayerInteractionController player)
    {
        this.gameObject.layer = this.gameObject.layer == LayerMask.NameToLayer("NonCollidable") ? LayerMask.NameToLayer("Collidable") : LayerMask.NameToLayer("NonCollidable");

        TriggerDoor();
    }
}
