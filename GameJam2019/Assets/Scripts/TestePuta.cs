using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePuta : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log(new Vector2(Mathf.RoundToInt(Input.GetAxisRaw("Horizontal Joystick 2")), Mathf.RoundToInt(Input.GetAxisRaw("Vertical Joystick 2"))));

        

        /*if (Input.GetKey(KeyCode.Joystick1Button2))

        float yAxis = 0f;
        if (Input.GetKey(KeyCode.Joystick1Button3))
            yAxis += 1f;
        if (Input.GetKey(KeyCode.Joystick1Button0))
            yAxis -= 1f;*/
    }
}
