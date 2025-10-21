using TMPro;
using UnityEngine;

public class textoScore : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString();
    }
}
