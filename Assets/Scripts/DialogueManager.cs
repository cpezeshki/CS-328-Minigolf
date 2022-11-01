using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private GameObject player;
    public bool animationFinished = false;
    public bool coroutineRun;
    public int val = 0;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
    
        if(!coroutineRun)
        {
            coroutineRun = true;
            StartCoroutine(wait());
        }
        
        sentences.Clear();

        nameText.text = dialogue.name;


        foreach (string sentence in dialogue.sentences)
        {
        sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        Debug.Log("This is triggering");
        val++;
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
            yield return null;
        }
        
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public IEnumerator wait()
    {
        float elapsed = 0;
         while (elapsed < 1.0f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        animationFinished = true;
        coroutineRun = false;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

}
