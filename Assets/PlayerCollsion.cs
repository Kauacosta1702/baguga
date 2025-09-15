using UnityEngine;
using UnityEngine.SceneManagement; // Importante para trocar de cena

public class PlayerCollsion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se encostar no jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Caso use Trigger em vez de colisão normal
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }
}