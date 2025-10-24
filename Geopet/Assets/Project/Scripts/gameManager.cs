using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public bool canSpain = true;
    public bool canAustralia = true;
    public bool canJapan = true;
    public bool canArgentina = true;
    public static gameManager Instance;

    public int totalCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
    }


    public void LoadSpain()
    {

        if (canSpain)
        {
            SceneManager.LoadScene("juegoEspaña");
            Time.timeScale = 0;
        }

        
    }

    public void LoadAustralia()
    {
        if (canAustralia)
        {
            SceneManager.LoadScene("juegoAustralia");
            Time.timeScale = 0;
        }
        
    }

    public void LoadJapan()
    {
        if (canJapan)
        {
            SceneManager.LoadScene("juegojapon");
            Time.timeScale = 0;
        }
        
    }

    public void LoadArgentina()
    {

        if (canArgentina)
        {
            SceneManager.LoadScene("juegoArgentina");
            Time.timeScale = 0;
        }


    }

  
}
