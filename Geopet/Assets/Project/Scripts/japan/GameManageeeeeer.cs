using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("UI")]
    public TextMeshProUGUI textoPuntuacion;
    [Header("Puntuación")]
    private int puntuacionActual = 0;
    public int vidas = 3;
    public TextMeshProUGUI textoVidas;
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

        if (puntos < 0)
        {
            vidas--;
            if (vidas <= 0)
            {
                GameOver();
            }
        }
        ActualizarUI();
    }
    void ActualizarUI()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntuacionActual;
        }
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over! Puntuación final: " + puntuacionActual);

        Time.timeScale = 0f;
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "GAME OVER\nPuntuación: " + puntuacionActual;
        }
    }
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}