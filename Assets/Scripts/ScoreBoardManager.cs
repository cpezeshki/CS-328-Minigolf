using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    
    void Update()
    {
        scoreText.fontSize = 25;
    }
}
