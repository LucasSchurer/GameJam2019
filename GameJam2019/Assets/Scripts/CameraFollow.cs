
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private float initialZ;


    private void Start()
    {
        initialZ = transform.position.z;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, initialZ);
    }
}
