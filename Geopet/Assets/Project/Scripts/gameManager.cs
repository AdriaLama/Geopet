using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public int canSpain = 1;
    public int canAustralia = 1;
    public int canJapan = 1;
    public static gameManager Instance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("levelSelector");
    }

    public void LoadSpain()
    {

        if (canSpain == 1)
        {
            SceneManager.LoadScene("juegoEspaña");
        }

        
    }

    public void LoadAustralia()
    {
        if (canAustralia == 1)
        {
            SceneManager.LoadScene("juegoAustralia");
        }
        
    }

    public void LoadJapan()
    {
        if (canJapan == 1)
        {
            SceneManager.LoadScene("juegojapon");
        }
        
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
