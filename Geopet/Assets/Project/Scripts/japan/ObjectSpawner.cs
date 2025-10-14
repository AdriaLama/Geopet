using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public GameObject[] objetosBuenos; 
    public GameObject objetoMalo;      

   
    public float tiempoEntreSpawns = 2f;
    public float rangoX = 8f; 
    public float alturaSpawn = 6f; 

    
    [Range(0f, 1f)]
    public float probabilidadObjetoMalo = 0.2f; 

    private float tiempoSiguienteSpawn;

    void Start()
    {
        tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
    }

    void Update()
    {
        if (Time.time >= tiempoSiguienteSpawn)
        {
            GenerarObjeto();
            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    void GenerarObjeto()
    {
        
        float posX = Random.Range(-rangoX, rangoX);
        Vector3 posicionSpawn = new Vector3(posX, alturaSpawn, 0f);

        
        GameObject objetoAGenerar;

        if (Random.value < probabilidadObjetoMalo)
        {
            
            objetoAGenerar = objetoMalo;
        }
        else
        {
            
            int indiceAleatorio = Random.Range(0, objetosBuenos.Length);
            objetoAGenerar = objetosBuenos[indiceAleatorio];
        }

        Instantiate(objetoAGenerar, posicionSpawn, Quaternion.identity);
    }
}
