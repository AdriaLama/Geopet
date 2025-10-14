using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    [SerializeField] GameObject wordContainer;
    [SerializeField] GameObject keyBoardContainer;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject letterButton;
    [SerializeField] TextAsset possibleWord;

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

        // Habilitar todos los botones del teclado
        foreach (Button child in keyBoardContainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }

        // Limpiar las letras de la palabra anterior (NO el teclado)
        foreach (Transform child in wordContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Generar nueva palabra
        word = generateWord().ToUpper();

        // Crear contenedores para cada letra
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
        string line = wordList[Random.Range(0, wordList.Length - 1)];
        return line.Substring(0, line.Length - 1);
    }

    private void CheckLetter(string inputLetter, Button btn)
    {
        bool letterInWord = false;

        // Deshabilitar el botón después de hacer clic
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

        // Solo incrementar si la letra NO está en la palabra
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
            // Cambiar color a verde
            foreach (TextMeshProUGUI tmp in wordContainer.GetComponentsInChildren<TextMeshProUGUI>())
            {
                tmp.color = Color.green;
            }
            Invoke("InitialiseGame", 3f);
        }
    }
}
