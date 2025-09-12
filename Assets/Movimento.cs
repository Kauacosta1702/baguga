using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input horizontal (-1 = esquerda, 1 = direita)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Atualiza parâmetro do Animator
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isWalking", Mathf.Abs(moveInput) > 0.01f);

        // Virar personagem para o lado correto
        if (moveInput > 0) sr.flipX = false;
        if (moveInput < 0) sr.flipX = true;
    }

    void FixedUpdate()
    {
        // Movimento físico
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}