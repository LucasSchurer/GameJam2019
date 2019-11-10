using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : Door
{
    public override void changeAvailability()
    {
        isAvailable = true;
    }
}
