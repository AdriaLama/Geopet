using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource botones;
    public AudioSource musica;
    public AudioSource gato;
    public AudioSource comprar;
    public AudioSource bola;
    public AudioSource gradaGritando;
    public AudioSource victoria;
    public AudioSource sushi;
    public AudioSource fallo;
    public AudioSource moneda;
    public AudioSource palmadas;
    public AudioSource canguro;
    public AudioSource colchoneta;


    private FallingObject fo;
    private GameManagerArgentina gma;
    private LanzarBola lb;
    private Acertar ac;
    void Start()
    {
        lb = FindFirstObjectByType<LanzarBola>();
        ac = FindFirstObjectByType<Acertar>();
        gma = FindFirstObjectByType<GameManagerArgentina>();
        fo = FindFirstObjectByType<FallingObject>();

       
    }

    // Update is called once per frame
    void Update()
    {
        LanzarBola();
        Acertar();
       
       
    }

    public void BotonesRaton()
    {
        botones.Play();
    }

    public void GatoMaullido()
    {
        gato.Play();
    }
    public void ComprarSkin()
    {
        comprar.Play();
    }

    public void LanzarBola()
    {
        if (lb == null) return; 
        if (lb.isKick)
        {
            bola.Play();
            
        }
    }
    public void Acertar()
    {
        if (ac == null) return;
        if (ac.acertado)
        {
            gradaGritando.Play();
            ac.acertado = false;
        }

    }

    public void Victoria()
    {
        
        victoria.Play();
         
    }

    public void Sushi()
    {
        
         sushi.Play();
        
    }

    public void Fallo()
    {
        
         fallo.Play();
        
    }

    public void Moneda()
    {
        moneda.Play();
    }

    public void Palmadas()
    {
        palmadas.Play();
    }

    public void Canguro()
    {
        canguro.Play();
    }

    public void Colchoneta()
    {
        colchoneta.Play();
    }

}
