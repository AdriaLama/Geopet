using UnityEngine;

public class generarMoneda : MonoBehaviour
{
    public GameObject monedaPrefab;  
    public Transform zona;          
    private GameObject monedaActual;
    public bool isMoneda;

    public void Start()
    {
        Generar();
    }
    public void Generar()
    {
        
        if (monedaActual != null)
        {
            Destroy(monedaActual);
        }

        
        if (Random.value < 0.5f)
        {
            monedaActual = Instantiate(monedaPrefab, zona.position, Quaternion.identity);
            monedaActual.transform.SetParent(zona);
            isMoneda = true;
        }
    }
}
