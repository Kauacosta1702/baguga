using UnityEngine;

public class Nuvem : MonoBehaviour
{
    public float velocidade = 1f;
    public float limiteX = -15f; // ponto onde a nuvem some
    public float resetX = 15f;   // ponto onde ela reaparece (fora da tela)

    private float posicaoInicialY;

    void Start()
    {
        // guarda a posi��o Y original, pra n�o mudar altura
        posicaoInicialY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < limiteX)
        {
            // s� reposiciona quando realmente sair da tela
            transform.position = new Vector2(resetX, posicaoInicialY);
        }
    }
}