using UnityEngine;

public class VaveBulet : Bulet
{
    public GameObject buletInVave;
    private Rigidbody2D rb;
    public float startForse;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * startForse;
    }

    protected override void Touching(RaycastHit2D hit)
    {
        PlayerController playerController = hit.collider.GetComponent<PlayerController>();

        if (playerController == null) 
        {
            CercelAtac(8f);
            Destroy(gameObject);
            return;
        }
        if (playerController != null && playerController.playerMovement.isDeshing)
        {
            return;
        }

        if (!playerController.invulnerability) 
        {
            if (hit.collider.CompareTag("Enemy") && isFrendli != playerController.playerOrBoss) 
            {
                playerController.TakeDamage(damage);
            }
        }
        rb.velocity = transform.up * startForse;
    }

    protected override void BaseBulet()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            CercelAtac(8f);
            Destroy(gameObject);
            return;

        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distace, whatIsSoled); 

        if (hit.collider != null) 
        {
            Touching(hit);
        }
    }

    private void CercelAtac(float rBulets)
    {
        for (float i = 0; i < 360f; i += rBulets)
        {
            GameObject viveBulet = Instantiate(buletInVave, transform.position, Quaternion.Euler(0f, 0f, i));
        }
    }
}
