using System;
using System.Collections;
using UnityEngine;


public class moneda : MonoBehaviour
{
    private GameObject monedaActiva;
    public GameObject monedaPrefab;
    public float limiteXmin;
    public float limiteYmin;
    public float limiteXmax;
    public float limiteYmax;
    void Start()
    {
        StartCoroutine(coinCD());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin()
    {

        Vector2 min = new Vector2(limiteXmin, limiteYmin);
        Vector2 max = new Vector2(limiteXmax, limiteYmax);
        float randomX = UnityEngine.Random.Range(min.x, max.x);
        float randomY = UnityEngine.Random.Range(min.y, max.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

       
        monedaActiva = Instantiate(monedaPrefab, spawnPosition, Quaternion.identity);
    }

    private IEnumerator coinCD()
    {
        yield return new WaitForSeconds(5f);
        SpawnCoin();
    }
    
}
