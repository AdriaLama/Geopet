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
        {
            selectedOption = 0;
            Save(); // Guardar el valor inicial
        }
        else
        {
            Load();
        }

        updateCharacter(selectedOption);

        if (buyButton != null)
            buyButton.onClick.AddListener(BuyCharacter);
        if (selectButton != null)
            selectButton.onClick.AddListener(SelectCharacter);
    }

    private void Update()
    {
        UpdateBuyButtonState();
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

        if (character == null)
        {
            Debug.LogError($"Character at index {selectedOption} is null!");
            return;
        }

        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

        if (character.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            if (moneda != null)
                moneda.gameObject.SetActive(false);
            if (priceText != null)
                priceText.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            if (moneda != null)
                moneda.gameObject.SetActive(true);
            if (priceText != null)
            {
                priceText.gameObject.SetActive(true);
                priceText.text = character.price.ToString();
            }
            selectButton.gameObject.SetActive(false);

            UpdateBuyButtonState();
        }
    }

    private void UpdateBuyButtonState()
    {
        Character character = characterDB.GetCharacter(selectedOption);

        if (character != null && !character.isUnlocked && buyButton != null)
        {
            bool canAfford = gameManager.Instance != null &&
                           gameManager.Instance.totalCoins >= character.price;

            buyButton.interactable = canAfford;
        }
    }

    public void BuyCharacter()
    {
        Character character = characterDB.GetCharacter(selectedOption);

        if (character == null || gameManager.Instance == null) return;

        if (!character.isUnlocked && gameManager.Instance.totalCoins >= character.price)
        {
            gameManager.Instance.totalCoins -= character.price;
            character.isUnlocked = true;
            characterDB.SaveUnlockState(selectedOption);

            if (gameManager.Instance != null)
            {
                PlayerPrefs.SetInt("TotalCoins", gameManager.Instance.totalCoins);
                PlayerPrefs.Save();
            }

            // IMPORTANTE: Actualizar la UI después de la compra
            updateCharacter(selectedOption);

            // Auto-seleccionar el personaje comprado
            SelectCharacter();
        }
    }

    public void SelectCharacter()
    {
        Character character = characterDB.GetCharacter(selectedOption);

        if (character != null && character.isUnlocked)
        {
            PlayerPrefs.SetInt("selectedOption", selectedOption);
            PlayerPrefs.Save();
            Debug.Log($"Personaje seleccionado: {character.characterName}");
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        PlayerPrefs.Save();
    }
}