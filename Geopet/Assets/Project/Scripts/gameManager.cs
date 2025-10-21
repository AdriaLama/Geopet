using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public bool canSpain = true;
    public bool canAustralia = true;
    public bool canJapan = true;
    public bool canArgentina = true;

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

        if (canSpain)
        {
            SceneManager.LoadScene("juegoEspa�a");
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

    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();

    }
}
