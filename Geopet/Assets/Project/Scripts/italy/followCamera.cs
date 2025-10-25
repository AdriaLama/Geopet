using UnityEngine;

public class followCamera : MonoBehaviour
{
    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
    }
}
