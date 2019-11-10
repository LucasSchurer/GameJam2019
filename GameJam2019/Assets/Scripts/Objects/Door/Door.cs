using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : InteractiveObject
{
    public Lock lockType;
    public int unlockLevel;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    public SpriteRenderer spriteRenderer;

    void Awake()    
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact(PlayerInteractionController player)
    {
        if (unlockLevel >= (int)lockType)
            ChangeDoorState();        
    }

    public void ChangeDoorState()
    {
        this.gameObject.layer = this.gameObject.layer == LayerMask.NameToLayer("NonCollidable") ? LayerMask.NameToLayer("Collidable") : LayerMask.NameToLayer("NonCollidable");

        TriggerDoor();
    }

    public void TriggerDoor()
    {
        if (lockType == Lock.Easy || lockType == Lock.Normal)
            spriteRenderer.sprite = (spriteRenderer.sprite == sprite2) ? sprite1 : sprite2;
    }
}

public enum Lock { Easy, Normal, Hard }
