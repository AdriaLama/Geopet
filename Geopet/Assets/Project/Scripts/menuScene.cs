using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScene : MonoBehaviour
{
    public GameObject panelSettings;
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

    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();

    }

    public void Settings()
    {
        panelSettings.SetActive(true);
    } 

    public void closeSettings()
    {
        panelSettings.SetActive(false);
    }
}
