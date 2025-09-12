using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyVision : MonoBehaviour
{
    public Slider detectionBar;             // A barra de detec��o (UI)
    private float detectionTime = 0f;       // Tempo atual de detec��o
    public float maxDetectionTime = 3f;     // Tempo m�ximo at� Game Over
    private bool countingDown = false;      // Controla se est� contando

    void Start()
    {
        if (detectionBar != null)
        {
            detectionBar.maxValue = maxDetectionTime;
            detectionBar.gameObject.SetActive(false); // come�a escondida
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
                // Ativa o slider quando o player est� vis�vel
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
            // Se o player sair da �rea de vis�o, reseta
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