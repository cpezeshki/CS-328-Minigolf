using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    public int swings = 0;
    public GameObject textObject;
    
    TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TextMeshPro>();
        swings = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        text.text = swings.ToString();
    }

    // public void increment()
    // {
    //     swings += 1;
    //     text.text = "Total Strokes: " + swings.ToString();
    // }
}

