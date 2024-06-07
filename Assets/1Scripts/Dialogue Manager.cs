using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueText;

    public Animator animator;

    public GameScript gScript;

    GameObject player;
    GameObject npc;

    bool playerFound = false;
    public bool isDialogueActive = false;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if (!player && !playerFound)
        {
            player = GameObject.FindGameObjectWithTag("MainPlayer");
            playerFound = true;
        }

        if(!npc)
        {
            npc = GameObject.FindGameObjectWithTag("NPC");
        }

    }

    public void StartDialogue(Dialogue dialogue)
    {

        isDialogueActive = true;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public void InterruptDialogue()
    {
        isDialogueActive = false;
        animator.SetBool("IsOpen", false);
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if(!npc.GetComponent<NPC>().dialogueOneEnded)
        {
            if(!player.transform.GetChild(0).GetComponent<MainPlayer>().swordActive)
            {
                player.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                player.transform.GetChild(0).GetComponent<MainPlayer>().swordActive = true;
                gScript.hasPlayerObtainedNPCSword = true;
                npc.GetComponent<NPC>().dialogueOneEnded = true;
                isDialogueActive = false;
            }
        }

        //if(!npc.GetComponent<NPC>().dialogueTwoEnded)
        //{
        //    npc.GetComponent<NPC>().dialogueTwoEnded = true;
        //}
    }

}
