using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lever : InteractiveObject
{
    public Sprite sprite1;
    public Sprite sprite2;

    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public abstract void InteractLever(PlayerInteractionController player);

    public override void Interact(PlayerInteractionController player)
    {
        if (isAvailable)
        {
            InteractLever(player);
            TriggerLever();
        }
    }

    public override void changeAvailability()
    {
        isAvailable ^= true;
    }

    public void TriggerLever()
    {
        spriteRenderer.sprite = (spriteRenderer.sprite == sprite2) ? sprite1 : sprite2;
    }

}
