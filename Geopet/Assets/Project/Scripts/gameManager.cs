using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        SceneManager.LoadScene("juegoEspaña");
    }

    public void LoadAustralia()
    {
        SceneManager.LoadScene("juegoAustralia");
    }

  
    public void LoadJapan()
    {
        SceneManager.LoadScene("juegojapon");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
