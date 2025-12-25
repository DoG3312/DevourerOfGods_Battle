using System.Collections;
using UnityEngine;

public class Bos : MonoBehaviour
{
    [Header("Статы боса")]
    public float dashPower = 20f;
    public float bossDamage = 20;
    public float grinBuletChanche = 10f;

    [Header("Пули")]
    public GameObject bulet;
    public GameObject directedBulet;
    public GameObject viveBulet;
    public GameObject grinBulet;


    private Transform player;
    private Rigidbody2D rb;

    private Vector2 dashDirection;

    public float timeToVivse = 4f;
    public float timer =4f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        PlayerMovement playerController = FindObjectOfType<PlayerMovement>();
        
        player = playerController.transform;
    }

    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Controller>().TakeDamage(bossDamage);
        }
    }

    public void CerkelBuletAtak(float rMethBulet) 
    {
        float randomChisl;

        for (float i = 0; i < 360f; i +=rMethBulet)
        {
            randomChisl = Random.Range(0, 100);

            if (randomChisl >= grinBuletChanche)
            {
                Instantiate(bulet, transform.position, Quaternion.Euler(0f, 0f, i));
            }
            else
            {
                Instantiate(grinBulet, transform.position, Quaternion.Euler(0f, 0f, i));
            }
        }
    }

    public float PlayerAngl() 
    {
        Vector2 bosToPlayerDir = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(bosToPlayerDir.y, bosToPlayerDir.x) * Mathf.Rad2Deg;
        return angle;
    }

    public void DirectedBuletAtak(int bulets,float maxR,GameObject bulet) 
    {
        float randomChisl = Random.Range(0, 100);
        float angle = PlayerAngl();

        float r;
        r = angle-maxR;
        float angleOfRotation = (maxR * 2) / bulets;

        for (int i = 0;i < bulets; i++)
        {
            randomChisl = Random.Range(0, 100);
            if (randomChisl >= grinBuletChanche)
            {
                Instantiate(bulet, transform.position, Quaternion.Euler(0f, 0f, r - 90));
            }
            else
            {
                Instantiate(grinBulet, transform.position, Quaternion.Euler(0f, 0f, r - 90));
            }
            
            r += angleOfRotation;
        }
    }

    public void Dash() 
    {
        StartCoroutine(PerformDash());
    }

    public void DashInSide(float anglFromPlayer) 
    {
        StartCoroutine(PerformDashInSide(anglFromPlayer));
    }

    private IEnumerator PerformDash() 
    {
        if (player == null)
        {
            yield break;
        }

        
        dashDirection = (player.position - transform.position).normalized;

        rb.velocity = dashDirection * dashPower;

        yield return null;
    }

    private IEnumerator PerformDashInSide(float anglFromPlayer) 
    {
        float angle = PlayerAngl();
        float maxRandom = angle + anglFromPlayer;
        float minRandom = angle - anglFromPlayer;

        float randomAngle;
        do
        {
            randomAngle = Random.Range(0f, 360f);
        }
        while (randomAngle >= minRandom && randomAngle <= maxRandom);

        float angleInRadians = randomAngle * Mathf.Deg2Rad; 
        dashDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        rb.velocity = dashDirection * dashPower;

        yield return null;
    }

    public void SpecialCercelAtak()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 5);
    }

    public void FinelDirectAtak()
    {
        float randomAngel = Random.Range(180, -180);
        GameObject buletAtak =  Instantiate(directedBulet,transform.position,Quaternion.Euler(0,0,randomAngel));
        buletAtak.GetComponent<DirectedBulets>().startForse = 10f;
        if(timer <= 0)
        {
            timer = timeToVivse;
            DirectedBuletAtak(1,15f,viveBulet);
        }
    }
}
