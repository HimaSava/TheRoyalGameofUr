using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int playerNo;
    DataStore theStateManager;




    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<DataStore>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNo == 1)
        {
            GetComponent<Text>().text = "Score " + (theStateManager.p1Score);
        }
        else if (playerNo == 2)
        {
            GetComponent<Text>().text = "Score " + (theStateManager.p2Score);
        }
    }
}
