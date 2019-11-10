using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : InteractiveObject
{
    public Lock lockType;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    public SpriteRenderer spriteRenderer;

    public BoxCollider2D coll;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    public abstract void InteractDoor(PlayerInteractionController player);

    public override void Interact(PlayerInteractionController player)
    {
        if (lockType == Lock.Easy)
        {
            InteractDoor(player);
        }
    }

    public void TriggerDoor()
    {
        if (lockType == Lock.Easy || lockType == Lock.Normal)
            spriteRenderer.sprite = (spriteRenderer.sprite == sprite2) ? sprite1 : sprite2;
    }
}

public enum Lock { Easy, Normal, Hard }
