using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float tempo = 3f; // segundos at� voltar pro menu

    void Start()
    {
        Invoke("VoltarMenu", tempo);
    }

    void VoltarMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}