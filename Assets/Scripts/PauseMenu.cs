using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mulligen;
    public static bool isPaused;
    public string levelSelect;
    public string exit;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        if(mulligen != null)
        {
            mulligen.SetActive(false);
        }
        Time.timeScale =0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        if(mulligen != null && DialogueManager.mulligen == true && MulligenScript.used == false)
        {
            mulligen.SetActive(true);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LevelSelect()
    {
        ResumeGame();
        SceneManager.LoadScene(levelSelect);
    }

     public void Exit()
    {
        ResumeGame();
        SceneManager.LoadScene(exit);
    }

}
