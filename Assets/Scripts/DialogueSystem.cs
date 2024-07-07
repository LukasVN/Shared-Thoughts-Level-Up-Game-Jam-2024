using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class DialogNode {
    public string text;
}

[System.Serializable]
public class DialogSequence{
    public DialogNode[] dialogue;
}


public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    protected GameObject player;
    public DialogSequence[] dialogSequence; // Set this in the Inspector to define the sequence of dialogues
    protected DialogNode currentNode;
    public int currentDialogIndex = 0;
    public int dialogSequenceIndex = 0;
    public bool onDialogue;
    private bool isTyping = false;
    private bool isTextFullyRevealed = false;
    
    protected virtual void Start()
    {
        onDialogue = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update(){
        if(isTyping){
            if (Input.GetKeyDown(KeyCode.F))
            {
                isTextFullyRevealed = true;
            }
            return;
        }
        else{
            if (onDialogue && Input.GetKeyDown(KeyCode.F))
            {
                DisplayNextDialog();
            }
        }
    }

    public void StartDialog(){
        dialogBox.SetActive(true);
        onDialogue = true;
        if (!GameManager.Instance.playersFrozen)
        {
            GameManager.Instance.FreezeAllPlayers();
        }
    }

    public void DisplayNextDialog(){
        if (currentDialogIndex < dialogSequence[dialogSequenceIndex].dialogue.Length)
        {
            currentNode = dialogSequence[dialogSequenceIndex].dialogue[currentDialogIndex];
            StartCoroutine(TypeText(currentNode.text));
            currentDialogIndex++;
            onDialogue = true;
            if(!GameManager.Instance.playersFrozen){
                GameManager.Instance.FreezeAllPlayers();
            }
        }
        else
        {
            onDialogue = false;
            if (GameManager.Instance.playersFrozen)
            {
                GameManager.Instance.UnFreezeAllPlayers();
            }
            EndDialog();
        }
    }

    public void EndDialog(){
        currentDialogIndex = 0;
        dialogSequenceIndex = 0;
        dialogBox.SetActive(false);
        onDialogue = false;
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        isTextFullyRevealed = false;
        dialogText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            if (isTextFullyRevealed)
            {
                dialogText.text = text;
                break;
            }
            dialogText.text += letter;
            yield return new WaitForSeconds(0.025f); // Adjust the delay as needed
        }
        isTyping = false;
    }
    
}

