using UnityEngine;
using UnityEngine.UI;

public class PanelsLevelSelector : MonoBehaviour
{

    public GameObject[] panels;
    public GameObject button;
    private int currentPanel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("finalPanel") == 0)
        {
            panels[0].SetActive(true);
            button.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextPanel()
    {
        panels[(int)currentPanel].SetActive(false);
        currentPanel++;

        if (currentPanel < panels.Length) {

            panels[(int)currentPanel].SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
            button.SetActive(false);
            PlayerPrefs.SetInt("finalPanel", 1);
        }

    }
}
