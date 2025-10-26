using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    

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



   


}
