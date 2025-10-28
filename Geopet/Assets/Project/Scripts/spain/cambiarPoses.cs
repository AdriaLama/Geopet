using UnityEngine;

public class cambiarPoses : MonoBehaviour
{
    public Sprite[] poses;
    private static int currentPoseIndex = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (poses != null && poses.Length > 0)
            spriteRenderer.sprite = poses[currentPoseIndex];

        hitSpawner.OnSuccessfulHit.AddListener(ChangePose);


    }

    void OnDestroy()
    {
        hitSpawner.OnSuccessfulHit.RemoveListener(ChangePose);

    }

    void ChangePose()
    {
        if (poses == null || poses.Length == 0) return;

        currentPoseIndex = (currentPoseIndex + 1) % poses.Length;
        spriteRenderer.sprite = poses[currentPoseIndex];
    }

}
