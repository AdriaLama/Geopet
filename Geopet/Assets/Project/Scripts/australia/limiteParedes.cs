using UnityEngine;

public class limiteParedes : MonoBehaviour
{
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckHorizontalWrap();
    }

    private void CheckHorizontalWrap()
    {

        Vector3 camPos = mainCam.transform.position;
        float camHeight = 2f * mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;
        float leftLimit = camPos.x - camWidth / 2f;
        float rightLimit = camPos.x + camWidth / 2f;
        Vector3 pos = transform.position;


        if (pos.x > rightLimit)
        {
            pos.x = leftLimit;
            transform.position = pos;
        }
        else if (pos.x < leftLimit)
        {
            pos.x = rightLimit;
            transform.position = pos;
        }
    }
}
