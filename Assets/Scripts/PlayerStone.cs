using UnityEngine;

public class PlayerStone : MonoBehaviour
{
    DataStore theStateManager;
    public Tile StartingTile;
    public int PlayerNo;
    public Tile GoalTile;
    public Tile currentTile;
    Tile finalTile = null;
    
    public GameObject placeholder;
    public int tilesLeft;
    public int spacesToMove;


    Tile[] moveQueue;
    int moveQueueIndex;

    bool isAnimating = false;

    Vector3 targetPosition;
    Vector3 velocity;
    float smoothTime = 0.25f;
    float smoothDistance = 0.01f;
    int numberOfChecks = 0;
    bool home = false;



    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<DataStore>();
        targetPosition = this.transform.position;
        currentTile = StartingTile;
        tilesLeft = 15;
    }


    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////////////////////
        if (theStateManager.CurrentPlayerId + 1 != PlayerNo)
        {
            if (theStateManager.AnimatingDone)
            {
                if (this.currentTile.numberOfCoinsOn > 1)
                {                   
                    transform.position = placeholder.transform.position;
                    currentTile.numberOfCoinsOn--;
                    finalTile = StartingTile;
                    currentTile = StartingTile;
                    targetPosition = StartingTile.transform.position;
                    tilesLeft = 14;
                    home = true;

                }
                
                numberOfChecks++;
                if (numberOfChecks >= 6)
                {
                    theStateManager.TileCheckDone = true;
                    numberOfChecks = 0;
                }

            }

            return;
        }
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        if (isAnimating == false)
        {
            return;
        }
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        if (Vector2.Distance(this.transform.position, targetPosition) < smoothDistance)
        {
            if (moveQueue != null && moveQueueIndex < moveQueue.Length)
            {
                SetNewTargetPosition(moveQueue[moveQueueIndex].transform.position);
                moveQueueIndex++;
            }
            else
            {
                theStateManager.AnimatingDone = true;
                this.isAnimating = false;
            }
        }
        this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        if (finalTile==GoalTile && theStateManager.AnimatingDone)
        {
            if (PlayerNo == 1)
            {
                theStateManager.p1Score++;
                
            }
            else
            {
                theStateManager.p2Score++;
                
            }
            theStateManager.AnimatingDone = true;
            this.isAnimating = false;
            Destroy(this.gameObject, 1);
            return;
        }
        ////////////////////////////////////////////////////////////////


    }

    void SetNewTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        ////////////////////////////////////////////////////////////////
        if (theStateManager.CurrentPlayerId + 1 != PlayerNo)
        {
            Debug.Log("Wrong Piece");
            return;
        }
        if (theStateManager.DiceRollDone == false)
        {
            return;
        }
        if (theStateManager.ClickingDone == true)
        {
            return;
        }
        ////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////
        spacesToMove = theStateManager.DiceFinal;
        if (home)
        {
            spacesToMove--;
            finalTile = StartingTile;
            currentTile = StartingTile;
            home = false;
        }
        if (spacesToMove == 0)
        {
            theStateManager.ClickingDone = true;
            this.isAnimating = true;
            return;
        }
        if(tilesLeft-spacesToMove < 0)
        {
            Debug.Log("NOT ALLOWED");
            return;
        }
        else
        {
            tilesLeft -= spacesToMove;
        }
        ////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////
        currentTile.numberOfCoinsOn = 0;
        if (PlayerNo == 1)
        {
            currentTile.numberOfP1On = 0;
        }
        else if (PlayerNo == 2)
        {
            currentTile.numberOfP2On = 0;
        }
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        moveQueue = new Tile[spacesToMove];
        for (int i = 0; i < spacesToMove; i++)
        {
            if (finalTile == null)
            {
                finalTile = StartingTile;
            }
            else
            {
                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    return;
                }
                else if (finalTile.NextTiles.Length > 1)
                {
                    if (PlayerNo == 1)
                    {
                        finalTile = finalTile.NextTiles[0];
                    }
                    else
                    {
                        finalTile = finalTile.NextTiles[1];
                    }

                }
                else
                {
                    finalTile = finalTile.NextTiles[0];
                }
                if(i < spacesToMove-1 && finalTile == GoalTile)
                {
                    for (int j = 0; j < i; j++)
                    {
                        moveQueue[j] = currentTile;
                    }
                    return;
                }
            }
            moveQueue[i] = finalTile;
        }
        moveQueueIndex = 0;
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        if (PlayerNo == 1 && finalTile.numberOfP1On <= 0)
        {
            this.isAnimating = true;
            currentTile = finalTile;
            currentTile.numberOfCoinsOn++;
            currentTile.numberOfP1On++;
            theStateManager.ClickingDone = true;
        }
        else if (PlayerNo == 2 && finalTile.numberOfP2On <= 0)
        {
            this.isAnimating = true;
            currentTile = finalTile;
            currentTile.numberOfCoinsOn++;
            currentTile.numberOfP2On++;
            theStateManager.ClickingDone = true;
        }
        ////////////////////////////////////////////////////////////////

    }
}
