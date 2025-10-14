using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puntuacionBarra : MonoBehaviour
{
    private deteccionObjetivo det;
    public TextMeshProUGUI textScore;
    public GameObject panel;
    public int score = 0;
    public int maxScore;

    void Start()
    {
        det = FindAnyObjectByType<deteccionObjetivo>();
        if (textScore == null)
            textScore = FindAnyObjectByType<TextMeshProUGUI>();
    }

    void Update()
    {
        if (det.acertado)
        {
            score++;
            UpdateScoreText();
            det.acertado = false;
        }

        if (score >= maxScore)
        {
            panel.SetActive(true);
        }
    }

    void UpdateScoreText()
    {
        textScore.text = score.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("levelSelector");
    }


}
