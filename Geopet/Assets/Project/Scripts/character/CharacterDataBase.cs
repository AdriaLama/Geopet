using UnityEngine;



[CreateAssetMenu]
public class CharacterDataBase : ScriptableObject
{
    public Character[] character;
    public int CharacterCount
    {
        get
        {

            return character.Length;
        }
    }
    public Character GetCharacter(int index)
    {

        return character[index];
    }

    public void LoadUnlockStates()
    {
        for (int i = 0; i < character.Length; i++)
        {
            character[i].isUnlocked = PlayerPrefs.GetInt("CharacterUnlocked" + i, i == 0 ? 1 : 0) == 1;
            
        }
    }

    public void SaveUnlockState(int index)
    {
        PlayerPrefs.SetInt("CharacterUnlocked" + index, character[index].isUnlocked ? 1 : 0);
    }
}
