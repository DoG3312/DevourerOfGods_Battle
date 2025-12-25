using UnityEngine;

public class GreanBulet : Bulet
{
    public float hil = 10f;

    protected override void Touching(RaycastHit2D hit)
    {
        PlayerController playerController = hit.collider.GetComponent<PlayerController>();
        

        if (playerController == null)
        {
            Destroy(gameObject);
            return;
        }
        if (playerController != null && playerController.playerMovement.isDeshing)
        {
            playerController.ApplyHealing(hil);
            Destroy(gameObject);
            return;
        }

        if (!playerController.playerMovement.isDeshing)
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
