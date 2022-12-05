using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    public int swings = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        swings = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Total Strokes: " + swings.ToString();
    }

    // public void increment()
    // {
    //     swings += 1;
    //     text.text = "Total Strokes: " + swings.ToString();
    // }
}

