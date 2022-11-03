using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator rebel;
    public Animator wolfie;
    public string levelName;
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
        rebel.SetBool("IsOpen", true);
        wolfie.SetBool("IsOpen", true);
    
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
            SceneManager.LoadScene(levelName);
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
        rebel.SetBool("IsOpen", false);
        wolfie.SetBool("IsOpen", false);
        Invoke("ResumeGame", 2.0f);
    }

    IEnumerator wait()
    {
       print(Time.time);
       yield return new WaitForSeconds(4);
       print(Time.time);
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

}
