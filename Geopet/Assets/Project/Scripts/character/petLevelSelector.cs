using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class petLevelSelector : MonoBehaviour
{
    public CharacterDataBase characterDB;
    public SpriteRenderer artworkSprite;
    private PanelsLevelSelector ps;
    private int selectedOption = 0;
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

        ps = FindFirstObjectByType<PanelsLevelSelector>();
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
        if (ps.currentPanel > 2)
        {
            SceneManager.LoadScene("characterSelector");
        }
        
    }
}
