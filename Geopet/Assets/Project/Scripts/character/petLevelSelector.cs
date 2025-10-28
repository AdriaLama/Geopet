using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class petLevelSelector : MonoBehaviour
{
    public CharacterDataBase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    public bool canEnterPetSelector = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;

        }
        else
        {
            Load();
        }

        
        updateCharacter(selectedOption);
    }

    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        

    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    void OnMouseDown()
    {
        if (canEnterPetSelector)
        {
            SceneManager.LoadScene("characterSelector");
        }
        
    }
}
