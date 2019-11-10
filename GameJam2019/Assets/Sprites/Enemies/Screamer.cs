using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public float screamCooldown;
    public float screamCooldownLeft;
    public float screamRadius;
    public LayerMask screamMask;
    public LayerMask soundProofingMask;

    void Update()
    {
        Scream();
    }

    public void Scream()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), screamRadius, screamMask);

        if (collider)
        {
            if (!Physics2D.Linecast(transform.position, collider.transform.position, soundProofingMask))
                playerInfo.Kill();
        }
            
        
    }
}
