using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int swings;
    Text text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        swings = 0;
            text = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0)) {
			score++;
			text.text = "SCORE: "+score;
		}
	}
}