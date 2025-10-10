using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;  
    public float smoothSpeed = 5f;  
    void Start()
    {
    
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calculamos la posición deseada
        float targetY = Mathf.Lerp(transform.position.y, target.position.y, smoothSpeed * Time.deltaTime);

        // Solo actualizamos el eje Y
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }
}
