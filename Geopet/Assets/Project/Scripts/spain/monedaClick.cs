using System.Collections;
using UnityEngine;

public class monedaClick : MonoBehaviour
{
    private moneda m;

    void Start()
    {
        m = FindFirstObjectByType<moneda>();
    }

    private void OnMouseDown()
    {
        SoundManager sm = FindFirstObjectByType<SoundManager>();
        sm.Moneda();
        gameManager.Instance.AddCoins(5);
        m.StartCoroutine(m.RespawnCoin());
        Destroy(gameObject);
    }
}
