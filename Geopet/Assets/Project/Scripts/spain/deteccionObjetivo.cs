using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class deteccionObjetivo : MonoBehaviour
{
    public Transform left;
    public Transform right;

    private MovimientoBarra mb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mb = FindAnyObjectByType<MovimientoBarra>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barra") && Input.GetMouseButton(0))
        {
            float t = Mathf.PingPong(Time.time, 1f);
            transform.position = Vector3.Lerp(left.position, right.position, t);
            mb.speed += 0.3f;

        }
    }



}

