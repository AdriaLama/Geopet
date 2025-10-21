using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class porteroBola : MonoBehaviour
{
    public Transform bola;
    public GameObject targetLeft;
    public GameObject targetRight;
    public float speed;
    private LanzarBola lb;
    private bool diving = false;
    public float rotationAngle;
    public float rotationSpeed;
    private float targetRotation = 0f;
    private Vector3 targetPos;
    private Vector3 startPosition;
    private Vector3 bolaStartPos;

    void Start()
    {
        lb = FindFirstObjectByType<LanzarBola>();
        startPosition = transform.position;
        bolaStartPos = bola.position;
    }

    void Update()
    {

        if (lb.isMoving && !diving)
        {

            if (Mathf.Abs(bola.position.x - bolaStartPos.x) > 0.1f)
            {
                diving = true;

                if (bola.position.x < transform.position.x)
                {
                    targetPos = targetLeft.transform.position;
                    targetRotation = rotationAngle; 
                }
                else if (bola.position.x > transform.position.x)
                {
                    targetPos = targetRight.transform.position;
                    targetRotation = -rotationAngle; 
                }
            }
        }

        if (diving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            Quaternion desiredRotation = Quaternion.Euler(0, 0, targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                diving = false;
        }

        if (!lb.isMoving && !diving)
        {
            Quaternion neutralRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, neutralRotation, rotationSpeed * Time.deltaTime);
            transform.position = startPosition;
            bolaStartPos = bola.position;
        }
    }
}
