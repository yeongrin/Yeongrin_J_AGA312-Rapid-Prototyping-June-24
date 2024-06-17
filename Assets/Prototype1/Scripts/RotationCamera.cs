using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject Target;
    public float offsetX = 0.0f;            
    public float offsetY = 10.0f;           
    public float offsetZ = -10.0f;          

    public float CameraSpeed = 10.0f;      
    Vector3 TargetPos;

    void Start()
    {
        
    }

   
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }

    void FixtedUpdate()
    {
        TargetPos = new Vector3(
           Target.transform.position.x + offsetX,
           Target.transform.position.y + offsetY,
           Target.transform.position.z + offsetZ
           );

       
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    
    }

}
