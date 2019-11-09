using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float movementSpeed = 2f;
    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);

    }
    
}
