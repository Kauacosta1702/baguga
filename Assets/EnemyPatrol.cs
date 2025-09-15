using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float speed = 2f;

    private Transform alvo;

    void Start()
    {
        alvo = pontoA; 
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, alvo.position, speed * Time.deltaTime);

        // troca o alvo quando chega perto do destino
        if (Vector2.Distance(transform.position, alvo.position) < 0.1f)
        {
            alvo = (alvo == pontoA) ? pontoB : pontoA;

            
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}