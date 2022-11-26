using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulligenScript : MonoBehaviour
{
    public float x,y,z;
    public GameObject player;
    public GameObject button;
    public static bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        if(DialogueManager.mulligen == true)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void SavePlayerPosition()
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
    }
    
    public void LoadPlayerPosition()
    {
        if(used == false){
            x = PlayerPrefs.GetFloat("x");
            y = PlayerPrefs.GetFloat("y");
            z = PlayerPrefs.GetFloat("z");

            Vector3 LoadPosition = new Vector3(x,y,z);
            player.transform.position = LoadPosition;
            used = true;
        }
    }
}
