using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    [SerializeField] GameObject wordContainer;
    [SerializeField] GameObject keyBoardContainer;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject letterButton;
    [SerializeField] GameObject panel;
    [SerializeField] TextAsset possibleWord;
    public GameObject australiaButton;
    
    

    private string word;
    private int incorrectGuesses, correctGuesses;

    void Start()
    {
        InitialiseButtons();
        InitialiseGame();

        
    }

    void InitialiseButtons()
    {
        for (int i = 65; i <= 90; i++)
        {
            CreateButton(i);
        }
    }

    private void InitialiseGame()
    {
        incorrectGuesses = 0;
        correctGuesses = 0;

        
        foreach (Button child in keyBoardContainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }

        
        foreach (Transform child in wordContainer.transform)
        {
            Destroy(child.gameObject);
        }

        
        word = generateWord().ToUpper();

        
        foreach (char letter in word)
        {
            var temp = Instantiate(letterContainer, wordContainer.transform);
        }
    }

    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyBoardContainer.transform);
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        Button btn = temp.GetComponent<Button>();
        string letter = ((char)i).ToString();
        btn.onClick.AddListener(delegate { CheckLetter(letter, btn); });
    }

    private string generateWord()
    {
        string[] wordList = possibleWord.text.Split("\n");
        string line = wordList[Random.Range(0, wordList.Length)];
        return line.Substring(0, line.Length);
    }

    private void CheckLetter(string inputLetter, Button btn)
    {
        bool letterInWord = false;

        
        btn.interactable = false;

        for (int i = 0; i < word.Length; i++)
        {
            if (inputLetter == word[i].ToString())
            {
                letterInWord = true;
                correctGuesses++;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }

        
        if (!letterInWord)
        {
            incorrectGuesses++;
        }

        CheckOutcome();
    }

    private void CheckOutcome()
    {
        if (correctGuesses == word.Length)
        {
            
            foreach (TextMeshProUGUI tmp in wordContainer.GetComponentsInChildren<TextMeshProUGUI>())
            {
                tmp.color = Color.green;
                panel.SetActive(true);
            }
            Invoke("InitialiseGame", 3f);
        }
    }

    public void BackToMenu()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "ahorcadoEspaña")
        {

            PlayerPrefs.SetInt("ahorcadoEspaña", 1);

            
        }
        if (currentScene == "ahorcadoJapon")
        {

            PlayerPrefs.SetInt("ahorcadoJapon", 1);

            
        }
        if (currentScene == "ahorcadoArgentina")
        {

            PlayerPrefs.SetInt("ahorcadoArgentina", 1);

            
        }
        if (currentScene == "ahorcadoItalia")
        {

            PlayerPrefs.SetInt("ahorcadoItalia", 1);

            
        }
        if (currentScene == "ahorcadoAustralia")
        {

            PlayerPrefs.SetInt("ahorcadoAustralia", 1);

            
        }
        
        SceneManager.LoadScene("levelSelector");
    }
}
