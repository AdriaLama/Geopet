using UnityEngine;
using UnityEngine.UI;

public class PanelsLevelSelector : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject button;
    public int currentPanel = 0;

    public GameObject gato;
    public GameObject fondo;

    public Button buttonEspaña;
    public Button buttonJapon;
    public Button buttonArgentina;
    public Button buttonAustralia;


    private Color oscuro = new Color(0.3f, 0.3f, 0.3f, 1f);   
    private Color normal = Color.white;                      
    private float alphaNormal = 1f;                           
    private float alphaTransparente = 0.4f;

    private petLevelSelector ps;

    void Start()
    {

        currentPanel = 0;

        if (PlayerPrefs.GetInt("finalPanel") == 1)
        {  
            button.SetActive(false);
            return; 
        }

        
        if (panels.Length > 0 && panels[0] != null)
        {
            panels[0].SetActive(true);
        }
        if (button != null)
        {
            button.SetActive(true);
        }

        ps = FindFirstObjectByType<petLevelSelector>();

    
    }

    void Update()
    {
        UpdateVisuals();
    }

    public void NextPanel()
    {
        panels[currentPanel].SetActive(false);
        currentPanel++;

        if (currentPanel < panels.Length)
        {
            panels[currentPanel].SetActive(true);
            
        }
        else
        {
            
            button.SetActive(false);
            PlayerPrefs.SetInt("finalPanel", 1);
            ps.canEnterPetSelector = true;
          
        }

        UpdateVisuals();
    }

    private void UpdateVisuals()
    {

        if (currentPanel == 0)
        {
            SetButtonFalse();
     
        }
        else if (currentPanel == 1)
        {
           
            SetImageColor(fondo, oscuro);
            SetImageColor(gato, oscuro);
            SetImageColor(buttonEspaña.gameObject, normal, alphaNormal);
            SetImageColor(buttonJapon.gameObject, normal, alphaNormal);
            SetImageColor(buttonArgentina.gameObject, normal, alphaNormal);
            SetImageColor(buttonAustralia.gameObject, normal, alphaNormal);
            SetButtonFalse();
        }
        else if (currentPanel == 2)
        {
            
            SetImageColor(fondo, oscuro);
            SetImageColor(buttonEspaña.gameObject, oscuro, alphaTransparente);
            SetImageColor(buttonJapon.gameObject, oscuro, alphaTransparente);
            SetImageColor(buttonArgentina.gameObject, oscuro, alphaTransparente);
            SetImageColor(buttonAustralia.gameObject, oscuro, alphaTransparente);
            SetImageColor(gato, normal);
            SetButtonFalse();
        }
        else
        {
        
            SetImageColor(fondo, normal);
            SetImageColor(gato, normal);
            SetImageColor(buttonEspaña.gameObject, normal, alphaNormal);
            SetImageColor(buttonJapon.gameObject, normal, alphaNormal);
            SetImageColor(buttonArgentina.gameObject, normal, alphaNormal);
            SetImageColor(buttonAustralia.gameObject, normal, alphaNormal);
            SetButtonTrue();
        }
    }

    
    private void SetImageColor(GameObject obj, Color color, float alpha = -1f)
    {
        if (obj == null) return;

        Image img = obj.GetComponent<Image>();
        if (img != null)
        {
            Color c = color;
            if (alpha >= 0f) c.a = alpha;  
            img.color = c;
            return;
        }

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = color;
            if (alpha >= 0f) c.a = alpha;
            sr.color = c;
        }
    }

    private void SetButtonFalse()
    {
        buttonEspaña.interactable = false;
        buttonJapon.interactable = false;
        buttonArgentina.interactable = false;
        buttonAustralia.interactable = false;
    }
    private void SetButtonTrue()
    {
        buttonEspaña.interactable = true;
        buttonJapon.interactable = true;
        buttonArgentina.interactable = true;
        buttonAustralia.interactable = true;
    }
}
