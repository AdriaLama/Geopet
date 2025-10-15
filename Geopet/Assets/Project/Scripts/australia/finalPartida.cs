using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class finalPartida : MonoBehaviour
{
    public GameObject panelFinal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Final"))
        {
            panelFinal.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("ahorcadoAustralia");
    }


}
