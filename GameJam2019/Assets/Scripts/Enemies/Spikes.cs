using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
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
            Debug.Log("eae");

            playerInfo.Kill();
        }
    }
}
