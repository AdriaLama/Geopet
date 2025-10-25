using System.Collections;
using UnityEngine;

public class monedaClick : MonoBehaviour
{
    private moneda m;
    void Start()
    {
        m = FindFirstObjectByType<moneda>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.Instance.AddCoins(5);
        Destroy(gameObject);
        StartCoroutine(coinCD());
        
    }

    private IEnumerator coinCD()
    {
       yield return new WaitForSeconds(5f);
       m.SpawnCoin();
    }
}
