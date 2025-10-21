using JetBrains.Annotations;
using UnityEngine;

public class movAcertar : MonoBehaviour
{
    public float speed;
    private int direction = 1;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("left"))
        {
            direction = 1;

        }
        else if (collision.gameObject.CompareTag("right"))
        {
            direction = -1;

        }
    }
}
