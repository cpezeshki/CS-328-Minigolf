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
            SceneManager.LoadScene(levelSelect);
        }
    }
}
