using System.Collections;
using UnityEngine;

public class movPlataformas : MonoBehaviour
{
    public float speed;
    public float timer;
    public bool isRight;
    public bool isLeft;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cdMovimiento());
    }

    IEnumerator cdMovimiento()
    {
        if (isRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed );
            yield return new WaitForSeconds(timer);
            isLeft = true;
            isRight = false;
        }
        else if (isLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            yield return new WaitForSeconds(timer);
            isLeft = false;
            isRight = true;
        }
    }
}
