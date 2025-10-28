using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;


public class hitSpawner : MonoBehaviour
{
    [Header("Timing Settings")]
    public float perfectWindow = 0.1f;  
    public float goodWindow = 0.25f;    
    public float okWindow = 0.4f;       

    [Header("Visual Settings")]
    public float lifeTime = 2f;         
    public Color approachColor = Color.white;
    public Color hitColor = Color.green;
    public Color missColor = Color.red;

    public static UnityEvent OnSuccessfulHit = new UnityEvent();

    private float spawnTime;
    private float hitTime;
    public bool wasHit = false;
    private SpriteRenderer spriteRenderer;
    private Transform approachCircle;
    private ScoreManager scoreManager;

    void Start()
    {
        spawnTime = Time.time;
        hitTime = spawnTime + lifeTime;

        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

       

        CreateApproachCircle();
    }

    void Update()
    {
        float elapsed = Time.time - spawnTime;
        float progress = elapsed / lifeTime;

        
        if (approachCircle != null)
        {
            float scale = Mathf.Lerp(3f, 1f, progress);
            approachCircle.localScale = Vector3.one * scale;
        }

        
        if (Time.time > hitTime + okWindow && !wasHit)
        {
            Miss();
        }
    }

    void CreateApproachCircle()
    {
        GameObject approachObj = new GameObject("ApproachCircle");
        approachObj.transform.SetParent(transform);
        approachObj.transform.localPosition = Vector3.zero;
        approachObj.transform.localScale = Vector3.one * 3f;

        SpriteRenderer sr = approachObj.AddComponent<SpriteRenderer>();
        sr.sprite = spriteRenderer.sprite;
        sr.color = approachColor;
        sr.sortingOrder = spriteRenderer.sortingOrder - 1;

        approachCircle = approachObj.transform;
    }

    void OnMouseDown()
    {
        if (wasHit) return;

        float timeDiff = Mathf.Abs(Time.time - hitTime);

        if (timeDiff <= perfectWindow)
        {
            Hit("PERFECT!", 300, hitColor);
        }
        else if (timeDiff <= goodWindow)
        {
            Hit("GOOD", 100, Color.cyan);
        }
        else if (timeDiff <= okWindow)
        {
            Hit("OK", 50, Color.yellow);
        }
        else
        {
            Miss();
        }
    }

 
    void Hit(string judgment, int points, Color color)
    {
        wasHit = true;
        OnSuccessfulHit?.Invoke();

        if (scoreManager != null)
        {
            scoreManager.AddScore(points, judgment);
        }

        spriteRenderer.color = color;
        ShowJudgment(judgment, color);

        Destroy(gameObject, 0.2f);
    }

    void Miss()
    {
        if (wasHit) return;
        wasHit = true;

        if (scoreManager != null)
        {
            scoreManager.AddScore(0, "MISS");
        }

        spriteRenderer.color = missColor;
        ShowJudgment("MISS", missColor);

        Destroy(gameObject, 0.3f);
    }
    void ShowJudgment(string text, Color color)
    {
        GameObject judgmentObj = new GameObject("Judgment");
        judgmentObj.transform.position = transform.position;

        TextMesh tm = judgmentObj.AddComponent<TextMesh>();
        tm.text = text;
        tm.fontSize = 12;
        tm.color = color;
        tm.anchor = TextAnchor.MiddleCenter;
        tm.alignment = TextAlignment.Center;

        
        judgmentObj.AddComponent<JudgmentAnimation>();

        Destroy(judgmentObj, 1f);
    }
}

public class JudgmentAnimation : MonoBehaviour
{
    private TextMesh textMesh;
    private float startTime;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        startTime = Time.time;
    }

    void Update()
    {
        float elapsed = Time.time - startTime;
        transform.position += Vector3.up * Time.deltaTime * 2f;

        Color c = textMesh.color;
        c.a = 1f - (elapsed / 1f);
        textMesh.color = c;
    }
}

