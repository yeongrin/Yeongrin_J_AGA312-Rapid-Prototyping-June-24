using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMoving : MonoBehaviour
{
    public Transform mCameraArm;

    public int speed;
    float inputX;
    float inputY;

    void Start()
    {

    }

    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        //inputY = Input.GetAxis("Vertical");

        //if (inputX != 0)
        //{
        //    RotateHorizontal();
        //}
        //if (inputY != 0)
        //{
        //    RotateVertical();
        //}

        LookAround();
    }

    void RotateHorizontal()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime * speed, 0f));
    }

    void RotateVertical()
    {
        transform.Rotate(new Vector3(inputY * Time.deltaTime * speed, 0f, 0f));
    }

    void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector3 camAngle = mCameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 45f);
        }
        else
        {
            x = Mathf.Clamp(x, 320f, 361f);
        }

        mCameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
