using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class puntuacionBarra : MonoBehaviour
{
    private deteccionObjetivo det;
    public TextMeshProUGUI textScore;
    public int score = 0;
    void Start()
    {
        det = FindAnyObjectByType<deteccionObjetivo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (det.acertado)
        {
            score++;
            UpdateScoreText();
            det.acertado = false;
        }
    }

    void UpdateScoreText()
    {
        textScore.text = score.ToString();
    }
}
