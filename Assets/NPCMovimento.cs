using UnityEngine;

public class NPCMovimento : MonoBehaviour
{
    public float speed = 2f;
    public float moveTime = 2f; // tempo andando em uma dire��o
    private float timer;
    private int direction = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        timer = moveTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            direction *= -1; // inverte dire��o
            timer = moveTime;
        }

        // Movimento
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Virar sprite
        sr.flipX = direction < 0;
    }
}