using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool isOn = true;

    private SpriteRenderer spriteRenderer;
    private Light2D light2D;

    public Sprite lampOn;
    public Sprite lampOff;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        light2D = GetComponent<Light2D>();
    }

    void Change()
    {
        isOn ^= true;

        spriteRenderer.sprite = isOn ? lampOn : lampOff;
        light2D.enabled = isOn;
    }
}
