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
    public Animator upgrade;
    public string levelName;
    private GameObject player;
    public bool animationFinished = false;
    public bool coroutineRun;
    public bool needWait = false;
    public int val = 0;
    public static bool mulligen = false;
    public static bool magnetHole = false;
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
        else if(sentences.Count %2 == 0)
        {
          Debug.Log("Even"); 
          wolfie.SetBool("Talk", true);
          rebel.SetBool("Talk", false);   
        }
        else if(sentences.Count %2 == 1)
        {
            Debug.Log("Odd");
            wolfie.SetBool("Talk", false);
            rebel.SetBool("Talk", true);
        }
        if(sentences.Count == 2)
        {
            if(upgrade != null)
            {
                upgrade.SetBool("IsOpen", true);
            }
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
    public void UpgradeChoice()
    {
        upgrade.SetBool("IsOpen", false);
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        rebel.SetBool("IsOpen", false);
        wolfie.SetBool("IsOpen", false);
        StartCoroutine(wait());
    }

    IEnumerator wait() 
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelName);  
    }

    public void MagnetHole()
    {
        magnetHole = true;
    }
    public void Mulligen()
    {
        mulligen = true;
    }

}
