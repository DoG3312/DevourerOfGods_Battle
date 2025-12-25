using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    private Rigidbody2D rb;

    public KeyCode deshKay = KeyCode.Space;

    public bool isDeshing;
    public float deshingPower;
    public float deshingTime;
    private float timer;
    public float reloadingTheDesh;


    public float speed = 5f;
    public Vector2 MovVector;
    private Vector2 normalizedMoveVector;
    public Animator animator;

    private float xAnim = 0;
    private float yAnim = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveUpdate()
    {
        MovVector.x = Input.GetAxisRaw("Horizontal");
        MovVector.y = Input.GetAxisRaw("Vertical");

        if (MovVector.magnitude != 0)
        {
            xAnim = MovVector.x;
            yAnim = MovVector.y;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            if (Input.GetKeyDown(deshKay))
            {
                StartCoroutine(Desh());
                timer = reloadingTheDesh;
            }
        }


        animator.SetFloat(("x2"), xAnim);
        animator.SetFloat(("y2"), yAnim);
        animator.SetFloat(("x"), MovVector.x);
        animator.SetFloat(("y"), MovVector.y);
        animator.SetFloat("Speed", MovVector.magnitude);
    }

    public void MoveFixedUpdate()
    {
        if (!isDeshing)
        {
            normalizedMoveVector = MovVector.normalized;
            rb.MovePosition(rb.position + normalizedMoveVector * speed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator Desh()
    {
        isDeshing = true;
        Vector2 normalizedMoveVectorDesh = new Vector2 (xAnim, yAnim).normalized;
        rb.velocity = new Vector2(normalizedMoveVectorDesh.x * deshingPower, normalizedMoveVectorDesh.y * deshingPower);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(deshingTime);
        rb.velocity = new Vector2(0f, 0f);
        trailRenderer.emitting = false;
        isDeshing = false;
    }

    public void Repulsion(float forse,Transform target)
    {
        Vector2 VectorForse = transform.position - target.position;
        VectorForse = VectorForse.normalized;
        //rb.velocity = new Vector2(-(VectorForse.x * forse), -(VectorForse.y * forse));
        rb.AddForce(VectorForse * forse, ForceMode2D.Impulse);
    }
}
