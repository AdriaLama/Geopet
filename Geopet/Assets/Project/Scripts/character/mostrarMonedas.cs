using UnityEngine;
using TMPro;

public class mostrarMonedas : MonoBehaviour
{
    private gameManager gm;
    public TextMeshProUGUI monedasText;
    void Start()
    {
        gm = FindFirstObjectByType<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        monedasText.text = gm.totalCoins.ToString();
    }
}
