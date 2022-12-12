using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public GameObject instruction1, instruction2, instruction3;
    public float waitTime = 0.4f;
    public static bool GameIsPaused = false;
    private bool instruction1Shown = false;
    /*private bool instruction2Shown = false;
    private bool instruction3Shown = false;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(instruction1Shown == false){
            if(waitTime <= 0){
                showInstruction1();
                instruction1Shown = true;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
        
    }

    void showInstruction1()
    {
        instruction1.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void showInstruction2()
    {
        instruction2.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void showInstruction3()
    {
        instruction3.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void resumePlay()
    {
        instruction1.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
