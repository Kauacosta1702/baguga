using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(2, 5)]
    public string text;
}

public class DialogoMendigo : MonoBehaviour
{
    public DialogueLine[] dialogueLines;
    public TextMeshProUGUI dialogueText; // Texto do diálogo
    public TextMeshProUGUI characterNameText; // Texto do nome do personagem
    public GameObject dialoguePanel;
    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private bool playerInRange = false;
    private bool isTyping = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTyping)
            {
                if (currentLine < dialogueLines.Length)
                {
                    StartCoroutine(TypeLine(dialogueLines[currentLine]));
                    currentLine++;
                }
                else
                {
                    EndDialogue();
                }
            }
            else
            {
                // Pular typewriter
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine - 1].text;
                characterNameText.text = dialogueLines[currentLine - 1].characterName;
                isTyping = false;
            }
        }
    }

    IEnumerator TypeLine(DialogueLine line)
    {
        isTyping = true;
        dialoguePanel.SetActive(true);
        characterNameText.text = line.characterName;
        dialogueText.text = "";

        foreach (char c in line.text.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        characterNameText.text = "";
        dialoguePanel.SetActive(false);
        currentLine = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            EndDialogue();
        }
    }
}