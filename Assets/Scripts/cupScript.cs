using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cupScript : MonoBehaviour
{
    public string levelSelect;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Golfball")
        {
            if(levelSelect == "Course2-Cutscene")
            {
                LevelMenu.enableLevel2 = true;
                SceneManager.LoadScene(levelSelect);
            }
            if(levelSelect == "Course3-Cutscene")
            {
                LevelMenu.enableLevel3 = true;
                SceneManager.LoadScene(levelSelect);
            }
            if(levelSelect == "Course4-Cutscene")
            {
                LevelMenu.enableLevel4 = true;
                SceneManager.LoadScene(levelSelect);
            }
            if(levelSelect == "Course5-Cutscene")
            {
                LevelMenu.enableLevel5 = true;
                SceneManager.LoadScene(levelSelect);
            }
            if(levelSelect == "Course6-Cutscene")
            {
                LevelMenu.enableLevel6 = true;
                SceneManager.LoadScene(levelSelect);
            }
        }
    }
}
