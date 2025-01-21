using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateScript : MonoBehaviour
{

    [SerializeField] GameObject PirateSprite;
    [SerializeField] GameObject KnifeSprite;
    public bool RiggedToBlow;
    public bool Activated;

    PirateGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<PirateGameManager>();

        int rand = Random.Range(1, 6);

        if (rand == 1) {

            RiggedToBlow = true;
        
        }

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        if (Input.GetMouseButtonDown(0)) {

            if (GetComponent<SpriteRenderer>().bounds.Contains(mouse)) {

                if (Activated == false) {

                    KnifeSprite.SetActive(true);

                    if (RiggedToBlow)
                    {

                        PirateSprite.SetActive(true);

                    }

                    Activated = true;

                }               
            
            }
        
        }

        if (RiggedToBlow && Activated) {

            gameManager.Whoops();

        }

    }

    public void ResetBarrel() {

        Activated = false;
        RiggedToBlow = false;

        PirateSprite.SetActive(false);
        KnifeSprite.SetActive(false);

        int rand = Random.Range(1, 6);

        if (rand == 1)
        {

            RiggedToBlow = true;

        }

    }

}
