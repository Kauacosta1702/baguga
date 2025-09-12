using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyVision : MonoBehaviour
{
    public Slider detectionBar;             // A barra de detecção (UI)
    private float detectionTime = 0f;       // Tempo atual de detecção
    public float maxDetectionTime = 3f;     // Tempo máximo até Game Over
    private bool countingDown = false;      // Controla se está contando

    void Start()
    {
        if (detectionBar != null)
        {
            detectionBar.maxValue = maxDetectionTime;
            detectionBar.gameObject.SetActive(false); // começa escondida
        }
    }

    void Update()
    {
        if (countingDown && detectionBar != null)
        {
            detectionBar.value = detectionTime;
        }
        else if (detectionBar != null)
        {
            detectionBar.value = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            esc player = other.GetComponent<esc>();

            if (player != null && !player.IsHidden)
            {
                // Ativa o slider quando o player está visível
                detectionBar.gameObject.SetActive(true);

                countingDown = true;
                detectionTime += Time.deltaTime;

                if (detectionTime >= maxDetectionTime)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            else
            {
                // Se o player se esconder, reseta
                ResetDetection();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o player sair da área de visão, reseta
            ResetDetection();
        }
    }

    private void ResetDetection()
    {
        countingDown = false;
        detectionTime = 0f;

        if (detectionBar != null)
            detectionBar.gameObject.SetActive(false); // desliga a barra
    }
}