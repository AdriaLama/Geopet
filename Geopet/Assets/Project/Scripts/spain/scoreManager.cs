using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI accuracyText;

    private int score = 0;
    private int combo = 0;
    private int maxCombo = 0;

    // Estadísticas
    private int perfectHits = 0;
    private int goodHits = 0;
    private int okHits = 0;
    private int misses = 0;

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points, string judgment)
    {
        // Calcular score con multiplicador de combo
        int comboMultiplier = Mathf.Min(combo / 10 + 1, 4);  // Max 4x
        score += points * comboMultiplier;

        // Actualizar combo
        if (points > 0)
        {
            combo++;
            if (combo > maxCombo)
                maxCombo = combo;
        }
        else
        {
            combo = 0;
        }

        // Actualizar estadísticas
        switch (judgment)
        {
            case "PERFECT!":
                perfectHits++;
                break;
            case "GOOD":
                goodHits++;
                break;
            case "OK":
                okHits++;
                break;
            case "MISS":
                misses++;
                break;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString("N0");

        if (comboText != null)
        {
            comboText.text = combo > 0 ? combo + "x" : "";

            // Cambiar color del combo según su tamaño
            if (combo >= 50)
                comboText.color = Color.magenta;
            else if (combo >= 20)
                comboText.color = Color.yellow;
            else
                comboText.color = Color.white;
        }

        if (accuracyText != null)
        {
            float accuracy = CalculateAccuracy();
            accuracyText.text = "Accuracy: " + accuracy.ToString("F1") + "%";
        }
    }

    float CalculateAccuracy()
    {
        int totalHits = perfectHits + goodHits + okHits + misses;
        if (totalHits == 0) return 100f;

        float weightedScore = (perfectHits * 100f) + (goodHits * 60f) + (okHits * 30f);
        float maxScore = totalHits * 100f;

        return (weightedScore / maxScore) * 100f;
    }

    public void ShowFinalStats()
    {
        Debug.Log("=== ESTADÍSTICAS FINALES ===");
        Debug.Log("Score Final: " + score);
        Debug.Log("Max Combo: " + maxCombo);
        Debug.Log("Accuracy: " + CalculateAccuracy().ToString("F2") + "%");
        Debug.Log("Perfect: " + perfectHits);
        Debug.Log("Good: " + goodHits);
        Debug.Log("OK: " + okHits);
        Debug.Log("Miss: " + misses);
    }
}
