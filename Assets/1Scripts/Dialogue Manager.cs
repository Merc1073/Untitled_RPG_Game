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

    GameObject player;
    bool playerFound = false;

    public bool swordActive = false;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(!player && !playerFound)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("player has been found, he is " + player);
            playerFound = true;
        }

    }

    public void StartDialogue(Dialogue dialogue)
    {

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

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if(!swordActive)
        {
            player.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            swordActive = true;
        }
    }

}
