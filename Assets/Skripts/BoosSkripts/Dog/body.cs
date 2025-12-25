using UnityEngine;

public class body : MonoBehaviour
{
    private Head head;
    public Transform parenNode;
    public BaseStats stats;
    Vector3 destinationPoint;

    void Start()
    {
        head = FindObjectOfType<Head>();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, destinationPoint, stats.bodySpeed);

        RotateTowardsDestination();

    }

    void RotateTowardsDestination()
    {
        Vector2 direction = destinationPoint - transform.position;

        if (direction == Vector2.zero) return;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, stats.bodyRotation * Time.fixedDeltaTime);
    }
}
