using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    public bool isAvailable = true;
    public abstract void Interact(PlayerInteractionController player);
    public abstract void changeAvailability();
}
