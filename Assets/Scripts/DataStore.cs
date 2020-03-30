using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataStore : MonoBehaviour
{
    // Start is called before the first frame update
    

    public int NumberOfPlayers = 2;
    public int CurrentPlayerId = 0;

    public int DiceFinal;

    public bool DiceRollDone = false;
    public bool ClickingDone = false;
    public bool AnimatingDone = false;
    public bool TileCheckDone = false;

    public int p1Score;
    public int p2Score;

    public string gameOver1;
    public string gameOver2;


    void Start()
    {
        p1Score = 0;
        p2Score = 0;
    }

    public void NewTurn()
    {
        DiceRollDone = false;
        ClickingDone = false;
        AnimatingDone = false;
        TileCheckDone = false;
        

        CurrentPlayerId = (CurrentPlayerId + 1) % NumberOfPlayers;
    }



    void Update()
    {
        if(DiceRollDone && ClickingDone && AnimatingDone && TileCheckDone)
        {
            Debug.Log("Done");
            NewTurn();
        }
        if(p1Score == 6)
        {

            SceneManager.LoadScene(gameOver1);
        }
        else if(p2Score == 6)
        {
            SceneManager.LoadScene(gameOver2);
        }
    }
}
