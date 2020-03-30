using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    DataStore theStateManager;
    public string mainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<DataStore>();
        if (theStateManager.p1Score == 6)
        {
            GetComponent<Text>().text = "PLAYER 1 IS THE WINNER";
        }
        if (theStateManager.p2Score == 6)
        {
            GetComponent<Text>().text = "PLAYER 2 IS THE WINNER";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retmenu()
    {
        
        SceneManager.LoadScene(mainMenu);
    }
}
