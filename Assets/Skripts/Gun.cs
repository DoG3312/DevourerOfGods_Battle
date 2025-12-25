using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timer;
    public float atakTime = 1f;
    public float rotZ;
    public GameObject bulet;
    public Transform shotPoint;
    public Transform playerTransform;

    public float orbitRadius = 1f;
    public float orbitSpeed = 2f;
    public float orbitFollowSpeed = 5f; 

    private void Update()
    {
        Vector2 mousePosition2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos2D = playerTransform.position;
        Vector2 playerToMouseDir = (mousePosition2D - playerPos2D).normalized;

        Vector2 orbitCenterOffset = playerToMouseDir * orbitRadius;
        Vector3 targetPosition = playerTransform.position + new Vector3(orbitCenterOffset.x, orbitCenterOffset.y, 0f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * orbitFollowSpeed);

        Vector2 direction = mousePosition2D - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle +90f);



        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                timer = atakTime;
                Shuting();
            }
        }
    }

    public void Shuting()
    {
        Instantiate(bulet, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, 180f));
    }
}
