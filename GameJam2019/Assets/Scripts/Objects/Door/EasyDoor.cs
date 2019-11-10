using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDoor : Door
{
    public override void changeAvailability()
    {
        isAvailable = true;
    }
}
