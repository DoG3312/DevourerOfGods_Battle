using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repiter : MonoBehaviour
{
    public float atakTime = 1f;
    private float timer;
    public GameObject bulet;
    public Transform shutingPoint;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Shuting();
            timer = atakTime;
        }
    }
    private void Shuting()
    {
        Instantiate(bulet,shutingPoint.position,transform.rotation);
    }
}
