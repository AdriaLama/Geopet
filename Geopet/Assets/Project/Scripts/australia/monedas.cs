using UnityEngine;

public class monedas : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            gameManager.Instance.AddCoins(5);
            Destroy(gameObject);
        }
    }
}
