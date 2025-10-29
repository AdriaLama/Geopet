using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    
    public bool canSpain = true;
    public bool canAustralia = true;
    public bool canJapan = true;
    public bool canArgentina = true;
    public GameObject buttonEspa�a;
    public GameObject buttonJapon;
    public GameObject buttonArgentina;
    public GameObject buttonItalia;
    public GameObject buttonAustralia;
    public GameObject textoEspa�a;
    public GameObject textoJapon;
    public GameObject textoArgentina;
    public GameObject textoItalia;
    public GameObject textoAustralia;
    public GameObject panelPausa;

    public Sprite spriteEspa�aCompletado;
    public Sprite spriteJaponCompletado;
    public Sprite spriteArgentinaCompletado;
    public Sprite spriteItaliaCompletado;
    public Sprite spriteAustraliaCompletado;
    public Color color = Color.white;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeFlags();
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

    public void PauseGame()
    {
        if (!panelPausa.activeInHierarchy)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }

    public void ExitLevel()
    {

        SceneManager.LoadScene("levelSelector");
    }
    public void ExitMenu()
    {

        SceneManager.LoadScene("menuPrincipal");
    }
    public void changeFlags()
    {
        if (PlayerPrefs.GetInt("ahorcadoEspa�a") == 1)
        {
            buttonEspa�a.GetComponent<Image>().sprite = spriteEspa�aCompletado;
            buttonEspa�a.GetComponent<Image>().color = color;
            textoEspa�a.SetActive(false);
            Button btn = buttonEspa�a.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoArgentina") == 1)
        {
            buttonArgentina.GetComponent<Image>().sprite = spriteArgentinaCompletado;
            buttonArgentina.GetComponent<Image>().color = color;
            textoArgentina.SetActive(false);
            Button btn = buttonArgentina.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoItalia") == 1)
        {
            buttonItalia.GetComponent<Image>().sprite = spriteItaliaCompletado;
            buttonItalia.GetComponent<Image>().color = color;
            textoItalia.SetActive(false);
            Button btn = buttonItalia.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoAustralia") == 1)
        {
            buttonAustralia.GetComponent<Image>().sprite = spriteAustraliaCompletado;
            buttonAustralia.GetComponent<Image>().color = color;
            textoAustralia.SetActive(false);
            Button btn = buttonAustralia.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoJapon") == 1)
        {
            buttonJapon.GetComponent<Image>().sprite = spriteJaponCompletado;
            buttonJapon.GetComponent<Image>().color = color;
            textoJapon.SetActive(false);
            Button btn = buttonJapon.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }
    }
}
