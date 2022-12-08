using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    public string firstLevel;
    public string secondLevel;
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
        SceneManager.LoadScene(secondLevel);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(thirdLevel);
    }

     public void StartLevel4()
    {
        SceneManager.LoadScene(fourthLevel);
    }

     public void StartLevel5()
    {
        SceneManager.LoadScene(fifthLevel);
    }
    public void StartLevel6()
    {
        SceneManager.LoadScene(sixthLevel);
    }
}
