using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SpeedingBulet : Bulet
{
    public float startForse = 10f;
    public float speedBoosrt;
    public float startingSpeding = 1f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * startForse;
    }

    protected override void BaseBulet()
    {
        base.BaseBulet();
        if(startingSpeding <= 0f )
        {
            speedBoosrt += Time.deltaTime * 3;
            speed += speedBoosrt;
        }
        else
        {
            startingSpeding -= Time.deltaTime;
        }
    }
}
