using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerArgentina : MonoBehaviour
{
    public static GameManagerArgentina instance;
    private textoScore ts;
    public GameObject panelFinal;
    public GameObject panelTut;
    public bool isWin = false;
    void Start()
    {
        ts = FindFirstObjectByType<textoScore>();
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    private void Update()
    {
        if (ts.score >= 7)
        {
            panelFinal.SetActive(true);
            SoundManager sm = FindFirstObjectByType<SoundManager>();

            if (sm != null)
            {
                sm.Victoria();
            }
            Time.timeScale = 0;
            
        }
    }
    public void ahorcadoArgentina()
    {
        SceneManager.LoadScene("ahorcadoArgentina");
    }
    public void empezarPartida()
    {
        Time.timeScale = 1;
        panelTut.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("levelSelector");
    }
}
