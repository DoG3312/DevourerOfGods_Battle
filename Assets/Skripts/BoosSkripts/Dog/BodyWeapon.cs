using UnityEngine;

public class BodyWeapon : MonoBehaviour
{
    public float damage = 10;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController.playerOrBoss)
            {
                if (!playerController.playerMovement.isDeshing && !playerController.invulnerability)
                {
                    playerController.TakeDamage(damage);
                }
            }
        }
    }
}
