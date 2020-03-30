using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{

    DataStore theStateManager;

    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<DataStore>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Player " + (theStateManager.CurrentPlayerId+1);
        
    }
}
