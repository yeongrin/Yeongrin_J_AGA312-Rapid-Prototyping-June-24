using UnityEngine;

public class ParallaxBackground3 : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    private Vector3 cameraStartPosition;
    private float distance;

    private Material[] materials;
    private float[] layerMoveSpeed;

    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float parallaxSpeed;

    private void Awake()
    {
        cameraStartPosition = cameraTransform.position;

        int backgroundCount = transform.childCount;
        GameObject[] background = new GameObject[backgroundCount];

        materials = new Material[backgroundCount];
        layerMoveSpeed = new float[backgroundCount];

        for (int i = 0; i < backgroundCount; ++i)
        {
            background[i] = transform.GetChild(i).gameObject;
            materials[i] = background[i].GetComponent<Renderer>().material;
        }

        CalculateMoveSpeedByLayer(background, backgroundCount);
    }

    void CalculateMoveSpeedByLayer(GameObject[] background, int count)
    {
        float farthestBackDistance = 0;

        for(int i = 0; i<count; ++i)
        {
            if((background[i].transform.position.z - cameraTransform.position.z) > farthestBackDistance)
            {
                farthestBackDistance = background[i].transform.position.z - cameraTransform.position.z;
            }
        }

        for(int i = 0; i<count; ++i)
        {
            layerMoveSpeed[i] = 1 - (background[i].transform.position.z - cameraTransform.position.z) / farthestBackDistance; 
        }
    }

    void Start()
    {
        
    }

    void LateUpdate()
    {
        distance = cameraTransform.position.x - cameraStartPosition.x;

        transform.position = new Vector3(cameraTransform.position.x, transform.position.y, 0);

        for (int i = 0; i < materials.Length; ++i)
        {
            float speed = layerMoveSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
