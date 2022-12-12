using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    public string firstLevel;
    public string secondLevel;
    public static bool enableLevel2 = false;
    public static bool enableLevel3 = false;
    public static bool enableLevel4 = false;
    public static bool enableLevel5 = false;
    public static bool enableLevel6 = false;
    public string thirdLevel;
    public string fourthLevel;
    public string fifthLevel;
    public string sixthLevel;
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
        if(enableLevel2)
        {
        SceneManager.LoadScene(secondLevel);
        }
    }

    public void StartLevel3()
    {
        if(enableLevel3)
        {
        SceneManager.LoadScene(thirdLevel);
        }
    }

    public void StartLevel4()
    {
        if(enableLevel4)
        {
        SceneManager.LoadScene(fourthLevel);
        }
    }
    public void StartLevel5()
    {
        if(enableLevel5)
        {
        SceneManager.LoadScene(fifthLevel);
        }
    }
    public void StartLevel6()
    {
        if(enableLevel6)
        {
        SceneManager.LoadScene(sixthLevel);
        }
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
