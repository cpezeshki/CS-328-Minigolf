using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public string secondLevel;
    public string thirdLevel;
    public string fourthLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(secondLevel);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(thirdLevel);
    }

    public void StartLevel4()
    {
        SceneManager.LoadScene(thirdLevel);
    }


    public void OpenControls()
    {

    }

    public void CloseControls()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
