using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public float radius;
    public float speed;

    public Screamer screamer;

    void Start()
    {
        screamer = GetComponentInParent<Screamer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x * speed * Time.deltaTime, transform.localScale.y * speed * Time.deltaTime, 1);
        if (transform.localScale.x >= screamer.screamRadius || !screamer.isScreaming)
            Destroy(this.gameObject);
    }
}
