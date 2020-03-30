using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceValueDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<DataStore>();
    }

     public DataStore theStateManager;

    // Update is called once per frame
    void Update()
    {
        if(theStateManager.DiceRollDone == false)
        {
            GetComponent<Text>().text = "= ?";
        }
        else
        {
            GetComponent<Text>().text = "= " + theStateManager.DiceFinal;
        }
        
    }
}
