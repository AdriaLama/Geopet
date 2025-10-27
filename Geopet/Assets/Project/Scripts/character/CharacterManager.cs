using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase characterDB;
    public SpriteRenderer artworkSprite;
    public TextMeshProUGUI nameText;

    public Button buyButton;
    public TextMeshProUGUI priceText;
    public GameObject moneda;
    public Button selectButton;

    private int selectedOption = 0;

    private void Start()
    {
        characterDB.LoadUnlockStates(); 

        if (!PlayerPrefs.HasKey("selectedOption"))
            selectedOption = 0;
        else
            Load();

        updateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
            selectedOption = 0;

        updateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
            selectedOption = characterDB.CharacterCount - 1;

        updateCharacter(selectedOption);
        Save();
    }

    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

        
        if (character.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            moneda.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            moneda.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
            priceText.text = character.price.ToString();
        }
    }

    public void BuyCharacter()
    {
        Character character = characterDB.GetCharacter(selectedOption);

        if (!character.isUnlocked && gameManager.Instance.totalCoins >= character.price)
        {
            gameManager.Instance.totalCoins -= character.price;
            character.isUnlocked = true;
            characterDB.SaveUnlockState(selectedOption);
            updateCharacter(selectedOption); 
        }
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        PlayerPrefs.Save();
       
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
