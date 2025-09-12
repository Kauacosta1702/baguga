using UnityEngine;

public class esc : MonoBehaviour
{
    public bool IsHidden { get; private set; } = false;

    private bool canHide = false; // controla se o player está numa área de esconderijo
    public KeyCode hideKey = KeyCode.E;

    private SpriteRenderer spriteRenderer;
    private Movimento movement; // troque pelo nome do seu script de movimento

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movimento>();
    }

    void Update()
    {
        if (canHide && Input.GetKeyDown(hideKey))
        {
            if (!IsHidden)
                EnterHide();
            else
                ExitHide();
        }
    }

    void EnterHide()
    {
        IsHidden = true;
        spriteRenderer.enabled = false;       // fica invisível
        movement.enabled = false;             // trava movimento
    }

    void ExitHide()
    {
        IsHidden = false;
        spriteRenderer.enabled = true;        // volta a aparecer
        movement.enabled = true;              // libera movimento
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot")) // seu esconderijo deve ter a tag "HideSpot"
            canHide = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
            canHide = false;
    }
}
