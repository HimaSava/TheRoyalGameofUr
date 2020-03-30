using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] DiceRolls;
    public Sprite[] DiceOne;
    public Sprite[] DiceZero;
    public DataStore theStateManager;

    void Start()
    {
        DiceRolls = new int[4];
        theStateManager = GameObject.FindObjectOfType<DataStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dice_Roller()
    {
        if(theStateManager.DiceRollDone == true)
        {
            return;
        }
        
        theStateManager.DiceRollDone = false;
        theStateManager.DiceFinal = 0;
        for (int i = 0; i < DiceRolls.Length; i++)
        {
            DiceRolls[i] = Random.Range(0, 2);
            theStateManager.DiceFinal += DiceRolls[i];

            if(DiceRolls[i] == 0)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite =
                    DiceZero[Random.Range(0, DiceZero.Length)];
            }
            else 
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite =
                    DiceOne[Random.Range(0, DiceOne.Length)];
            }
            
        }
        theStateManager.DiceRollDone = true;
        Debug.Log("Value: " + theStateManager.DiceFinal);
    }

    
}
