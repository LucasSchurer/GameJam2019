using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public bool isScreaming;
    public float screamCooldown;
    public float screamCooldownLeft;
    public float screamRadius;
    public float screamTime;
    public float screamTimeLeft;
    public LayerMask screamMask;
    public LayerMask soundProofingMask;

    public GameObject shockWave;
    public float timeBetweenWaves;
    public float timeBeforeNewWave;

    //private Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (screamCooldownLeft <= 0 || isScreaming)
        {
            Scream();

            if (timeBeforeNewWave <= 0)
            {
                Instantiate(shockWave, transform.position, Quaternion.identity, transform);
                timeBeforeNewWave = timeBetweenWaves;
            }
            else
                timeBeforeNewWave -= Time.deltaTime;
        }
            
        else
        {
            screamCooldownLeft -= Time.deltaTime;
            isScreaming = false;
            timeBeforeNewWave = 0f;
        }
            

        //anim.SetBool("isScreaming", isScreaming);
    }

    public void Scream()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), screamRadius, screamMask);

        if (collider)
        {
            if (!Physics2D.Linecast(transform.position, collider.transform.position, soundProofingMask))
                playerInfo.Kill();
        }

        if (!isScreaming)
        {
            screamTimeLeft = screamTime;
            isScreaming = true;
            screamCooldownLeft = screamCooldown;
        }
            
        if (screamTimeLeft <= 0)
        {
            isScreaming = false;
        } else
        {
            screamTimeLeft -= Time.deltaTime;
        }
        
    }
}
