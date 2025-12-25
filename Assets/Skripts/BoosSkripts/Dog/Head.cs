using System.Collections;
using UnityEngine;


public class Head : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;

    public float Speed = 8.0f;
    public float headDamage = 30;
    public float rotationSpeed = 90f; 
    public int side = 0;
    public float timer = 4f;
    private bool isDashing = false;
    public BaseStats bossStats;

    public int bodys;
    public GameObject body;
    public GameObject tail;

    private float playerAngel;
    private float headAngel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
        CreateBody();
    }

    void Update()
    {
        side = GetPlayerSide(player);
        FollowingThePlayer();

    }

    public void FollowingThePlayer()
    {
        playerAngel = Math.Instance.PlayerAngl(transform);
        headAngel = transform.eulerAngles.z;

        float angleDifference = Mathf.Abs(playerAngel - headAngel);

        if (angleDifference > 180)
        {
            angleDifference = 360 - angleDifference;
        }

        float directoinFromPlayer = Vector2.Distance(player.position, transform.position);

        timer -= Time.deltaTime;

        if (angleDifference <= 8 && timer <= 0 && !isDashing && directoinFromPlayer <= 10f)
        {
            StartCoroutine(HeadDash());
            timer = bossStats.deashTime; 
        }

        if (!isDashing)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime * side;
            transform.Rotate(0f, 0f, rotationAmount);
        }
        
        if (Vector2.Dot(transform.right, rb.velocity) < 0)
        {
            rb.velocity = -transform.right * Speed;
        }
        else
        {
            rb.velocity = transform.right * Speed; 
        }
    }

    public int GetPlayerSide(Transform positione)
    {
        Vector2 directionToTarget = ((Vector2)player.position - (Vector2)transform.position).normalized;

        // Текущее направление "вперёд" объекта (right в 2D, если спрайт смотрит вправо по умолчанию)
        Vector2 forwardDirection = transform.right; // или transform.up, в зависимости от ориентации спрайта

        // Если ваш спрайт смотрит вверх по умолчанию, используйте:
        // Vector2 forwardDirection = transform.up;

        // Определяем знак векторного произведения (2D cross product)
        float crossProduct = forwardDirection.x * directionToTarget.y - forwardDirection.y * directionToTarget.x;

        // Если crossProduct > 0, цель справа (против часовой стрелки)
        // Если crossProduct < 0, цель слева (по часовой стрелке)
        return crossProduct > 0 ? 1 : -1;
    }
    
    public void CreateBody()
    {
        
        Transform transforme = transform;
        for (int i = 0; i < bodys; i++)
        {
            Vector3 spawnPosition = transforme.position + new Vector3(0, -4, 0);

            GameObject bodi = Instantiate(body,spawnPosition,Quaternion.identity);
            bodi.GetComponent<body>().stats = bossStats;
            bodi.GetComponent<body>().parenNode = transforme;
            //bodi.GetComponent<HealthBar>().hilHealsBar = GameObject.FindGameObjectWithTag("hilHealsBar").GetComponent<Slider>();
            //bodi.GetComponent<HealthBar>().easeHealthBar = GameObject.FindGameObjectWithTag("EaseHealsBar").GetComponent<Slider>();
            //bodi.GetComponent<HealthBar>().HP_Slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
            transforme = bodi.transform;
        }
        Vector3 tailSpawnPosition = transforme.position + new Vector3(0, -1, 0);
        GameObject taile = Instantiate(tail,tailSpawnPosition,Quaternion.identity);
        taile.GetComponent<body>().stats = bossStats;
        //taile.GetComponent<HealthBar>().hilHealsBar = GameObject.FindGameObjectWithTag("hilHealsBar").GetComponent<Slider>();
        //taile.GetComponent<HealthBar>().easeHealthBar = GameObject.FindGameObjectWithTag("EaseHealsBar").GetComponent<Slider>();
        //taile.GetComponent<HealthBar>().HP_Slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        taile.GetComponent<body>().parenNode = transforme;
    }

    public IEnumerator HeadDash()
    {
        isDashing = true;

        Vector2 startPosition = rb.position;
        Vector2 dashDirection = transform.right.normalized;
        Vector2 endPosition = startPosition + dashDirection * bossStats.deashDistans;

        float startTime = Time.time;
        float time = 0f;

        while (time < 1f)
        {
            time = (Time.time - startTime) / bossStats.deashDuration; 

            Vector2 newPosition = Vector2.Lerp(startPosition, endPosition, time);
            rb.MovePosition(newPosition);

            yield return null;
        }

        rb.MovePosition(endPosition);
        isDashing = false;
    }
}