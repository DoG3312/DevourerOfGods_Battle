using UnityEngine;

public class Math : MonoBehaviour
{
    public static Math Instance { get; private set; }
    [SerializeField]private PlayerController playerController;


    private void Awake()
    {
        Instance = this;
        playerController = FindObjectOfType<PlayerController>();
    }

    public float PlayerAngl(Transform currentTransform)
    {
        Vector2 bosToPlayerDir = (playerController.transform.position - currentTransform.position).normalized;
        float angle = Mathf.Atan2(bosToPlayerDir.y, bosToPlayerDir.x) * Mathf.Rad2Deg;
        return angle;
    }
}
