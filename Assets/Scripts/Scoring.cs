using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int swings;
    Text text;
    int score = 0;
=======
using TMPro;

public class Scoring : MonoBehaviour
{
    public int swings = 0;
    public TextMeshProUGUI text;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        swings = 0;
            text = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
<<<<<<< Updated upstream
    { 
        if (Input.GetMouseButtonDown(0)) {
			score++;
			text.text = "SCORE: "+score;
		}
	}
}
=======
    {
        text.text = "Total Strokes: " + swings.ToString();
    }

    // public void increment()
    // {
    //     swings += 1;
    //     text.text = "Total Strokes: " + swings.ToString();
    // }
}
>>>>>>> Stashed changes
