using UnityEngine;

public class cambiarPoses : MonoBehaviour
{
    public Sprite[] poses;
    private static int currentPoseIndex = 0;
    private SpriteRenderer spriteRenderer;
    private hitSpawner hs;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (poses != null && poses.Length > 0)
            spriteRenderer.sprite = poses[currentPoseIndex];

        hs = FindFirstObjectByType<hitSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hs.wasHit)
        {
            ChangePose();
        }
    }

    void ChangePose()
    {
        if (poses == null || poses.Length == 0) return;

        currentPoseIndex = (currentPoseIndex + 1) % poses.Length;
        spriteRenderer.sprite = poses[currentPoseIndex];
    }

}
