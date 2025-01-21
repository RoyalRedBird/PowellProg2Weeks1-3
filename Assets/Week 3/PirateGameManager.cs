using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateGameManager : MonoBehaviour
{

    public GameObject[] Barrels = new GameObject[5];
    public bool[] barrelChecker = new bool[5];

    bool youWin = false;
    float resetTimer = 3;

    bool resetGame = false;

    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Barrels.Length; i++) {

            if (Barrels[i].GetComponent<PirateScript>().RiggedToBlow) { 
            
                barrelChecker[i] = true;
            
            }
            else if((Barrels[i].GetComponent<PirateScript>().RiggedToBlow == false) && Barrels[i].GetComponent<PirateScript>().Activated)
            {

                barrelChecker[i] = true;

            }                   
        
        }

        youWin = true;

        for(int i = 0; i < barrelChecker.Length; i++)
        {

            if (!barrelChecker[i])
            {

                youWin = false;

            }

        }

        if (youWin) {

            Yay();
        
        }

        if (resetGame) {

            resetTimer -= Time.deltaTime;

            if(resetTimer <= 0)
            {

                Debug.Log("Restarting in " + resetTimer);

                ResetGame();
                resetGame = false;
                resetTimer = 3;

            }        
        
        }
        
    }

    public void Yay()
    {

        Debug.Log("Huzzah!");
        resetGame = true;

    }

    public void Whoops() {

        Debug.Log("Sad Face.");
        resetGame = true;
    
    }

    public void ResetGame() {

        for (int i = 0; i < Barrels.Length; i++) {

            Barrels[i].GetComponent<PirateScript>().ResetBarrel();
            barrelChecker[i] = false;

        }

        youWin = false;
    
    }

}
