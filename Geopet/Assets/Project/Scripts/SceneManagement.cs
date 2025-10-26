using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public bool canSpain = true;
    public bool canAustralia = true;
    public bool canJapan = true;
    public bool canArgentina = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
