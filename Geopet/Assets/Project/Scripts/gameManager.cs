using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
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

        changeFlags();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        
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
