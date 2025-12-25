using UnityEngine;

public class DirectedBulets : Bulet
{
    public float startForse = 10f;
    public float speedBoost;
    public float startingSpeding = 1f;
    private Rigidbody2D rb;
    private Transform target;
    private bool hasRotated = false;
    private float speeed;
    private float DirectedTimer;
    public float DirectedTime = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * startForse;
        if (!isFrendli) target = FindObjectOfType<PlayerMovement>().transform;
        else target = FindObjectOfType<Bos>().transform;
        DirectedTimer = DirectedTime;
    }

    protected override void BaseBulet()
    {
        base.BaseBulet();
        if (startingSpeding <= 0f)
        {
            speedBoost += Time.deltaTime * 24;
            speeed += speedBoost;
            if (!hasRotated)
            {
                Vector2 directionToTarget = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                rb.velocity = directionToTarget * startForse; 
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
                if(DirectedTimer <= 0)
                {
                    hasRotated = true;
                }
                else
                {
                    DirectedTimer -= Time.deltaTime;
                }
            }

            rb.velocity += (rb.velocity.normalized * speeed * Time.deltaTime);
        }
        else
        {
            startingSpeding -= Time.deltaTime;
        }
    }
}
