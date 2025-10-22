using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("UI")]
    public TextMeshProUGUI textoPuntuacion;
    [Header("Puntuación")]
    private int puntuacionActual = 0;
    public GameObject panelFinal;
    public GameObject empezar;
    public GameObject panelTut;
    void Awake()
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
    void Start()
    {
        ActualizarUI();
    }
    public void AgregarPuntos(int puntos)
    {
        puntuacionActual += puntos;

        if (puntuacionActual < 0)
        {
            puntuacionActual = 0;
        }
       

        ActualizarUI();
    }
    void ActualizarUI()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntuacionActual;
        }
       
    }

    private void Update()
    {
        if (puntuacionActual >= 250)
        {
            panelFinal.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ahorcadoJapon()
    {
        SceneManager.LoadScene("ahorcadoJapon");
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