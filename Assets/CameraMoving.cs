using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject Target;
    public Transform mCameraArm;

    public float offsetX = 0.0f;
    public float offsetY = 10.0f;
    public float offSetz = -10.0f;

    public float cameraSpeed = 10.0f;
    Vector3 TartgetPos;

    public float mouseSensivity = 500f;
    private float MouseX;
    private float MouseY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TartgetPos = new Vector3
            (Target.transform.position.x + offsetX, Target.transform.position.y + offsetY, Target.transform.position.z + offSetz);

        transform.position = Vector3.Lerp(transform.position, TartgetPos, Time.deltaTime * cameraSpeed);
    }

    void Update()
    {
        LookAround();
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
