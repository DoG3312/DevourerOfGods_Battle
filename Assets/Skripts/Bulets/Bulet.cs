using UnityEngine;

public class Bulet : MonoBehaviour
{
    public bool isFrendli;

    public float damage = 10f;
    public float speed;
    public float lifeTime = 2.5f;
    public float distace;
    public LayerMask whatIsSoled;

    void Update()
    {
        BaseBulet();
    }

    protected virtual void BaseBulet()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) 
        {
            Destroy(gameObject);
            return;

        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distace, whatIsSoled); 

        if (hit.collider != null) 
        {
            Touching(hit);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime); 
    }

    protected virtual void Touching(RaycastHit2D hit)
    {
        PlayerController playerController = hit.collider.GetComponent<PlayerController>();

        if (playerController == null) 
        {
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
                Destroy(gameObject);
                return;
            }
        }
    }

}
