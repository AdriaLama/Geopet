using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    
    public bool canSpain = true;
    public bool canAustralia = true;
    public bool canJapan = true;
    public bool canArgentina = true;
    public GameObject buttonEspaña;
    public GameObject buttonJapon;
    public GameObject buttonArgentina;
    public GameObject buttonItalia;
    public GameObject buttonAustralia;

    public Sprite spriteEspañaCompletado;
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
            SceneManager.LoadScene("juegoEspaña");
            Time.timeScale = 1;
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
    public void changeFlags()
    {
        if (PlayerPrefs.GetInt("ahorcadoEspaña") == 1)
        {
            buttonEspaña.GetComponent<Image>().sprite = spriteEspañaCompletado;
            buttonEspaña.GetComponent<Image>().color = color;

            Button btn = buttonEspaña.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoArgentina") == 1)
        {
            buttonArgentina.GetComponent<Image>().sprite = spriteArgentinaCompletado;
            buttonArgentina.GetComponent<Image>().color = color;

            Button btn = buttonArgentina.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoItalia") == 1)
        {
            buttonItalia.GetComponent<Image>().sprite = spriteItaliaCompletado;
            buttonItalia.GetComponent<Image>().color = color;

            Button btn = buttonItalia.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoAustralia") == 1)
        {
            buttonAustralia.GetComponent<Image>().sprite = spriteAustraliaCompletado;
            buttonAustralia.GetComponent<Image>().color = color;

            Button btn = buttonAustralia.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }

        if (PlayerPrefs.GetInt("ahorcadoJapon") == 1)
        {
            buttonJapon.GetComponent<Image>().sprite = spriteJaponCompletado;
            buttonJapon.GetComponent<Image>().color = color;

            Button btn = buttonJapon.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.normalColor = color;
            btn.colors = cb;
        }
    }
}
