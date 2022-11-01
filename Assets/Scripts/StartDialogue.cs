using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialogue : MonoBehaviour
{
    public DialogueTrigger Test;
    // Start is called before the first frame update
    void Start()
    {
        Test.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
