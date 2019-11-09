using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StaticObjectCollision))]
public class ActionRandomizer : MonoBehaviour
{
    private StaticObjectCollision objectCollision;
    public PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        objectCollision = GetComponent<StaticObjectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectCollision.collisions.above || objectCollision.collisions.below || objectCollision.collisions.right || objectCollision.collisions.left)
        {
            playerInfo.RandomizeActions();
            Object.Destroy(this.gameObject);
        }
            
    }
}
