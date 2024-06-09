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

    GameScript gScript;

    public GameObject player;
    GameObject npc;

    bool playerFound = false;
    //public bool isDialogueActive = false;

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

            if(player)
            {
                playerFound = true;
            }
        }

        if(!npc)
        {
            npc = GameObject.FindGameObjectWithTag("NPC");
        }

    }

    public void StartDialogue(Dialogue dialogue)
    {
        gScript.isDialogueActive = true;

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
        gScript.isDialogueActive = false;
        animator.SetBool("IsOpen", false);
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        gScript.isDialogueActive = false;

        if(!gScript.hasPlayerObtainedNPCSword)
        {
            gScript.npcDialogueOneEnded = true;
            gScript.isDialogueActive = false;
        }

        if (!gScript.npcDialogueThreeEnded && gScript.hasKill5CubeQuestFinished)
        {
            gScript.npcDialogueThreeEnded = true;
            gScript.isDialogueActive = false;
        }


        //if(!npc.GetComponent<NPC>().dialogueTwoEnded)
        //{
        //    npc.GetComponent<NPC>().dialogueTwoEnded = true;
        //}
    }

}
