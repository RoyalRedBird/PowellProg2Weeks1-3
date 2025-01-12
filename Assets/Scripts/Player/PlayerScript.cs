using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public Transform PlayerPosition;
    [SerializeField] float Speed = 0.01f;
    Camera cam;

    [SerializeField]TextMeshProUGUI directionText;

    public bool cubeGoingRight;

    [SerializeField]bool FollowMouse = true;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        PlayerPosition = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = PlayerPosition.position;


        //Test Right
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenWorldSize = new Vector2();

        screenWorldSize = cam.ScreenToWorldPoint(screenSize);

        //Test Left
        Vector2 screenWorldZero = cam.ScreenToWorldPoint(Vector2.zero);

        if (FollowMouse)
        {

            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            PlayerPosition.position = mousePos;

        }else{

            pos.y = 0;

            if (cubeGoingRight)
            {

                pos.x += Speed;
                directionText.text = "Going: Right";
                

            }
            else{

                pos.x -= Speed;
                directionText.text = "Going: Left";

            }

            if (pos.x + Speed >= screenWorldSize.x) {

                cubeGoingRight = false;
            
            }

            if (pos.x + Speed <= screenWorldZero.x)
            {

                cubeGoingRight = true;

            }

            PlayerPosition.position = pos;

        }
       
    }

    public void FlipPlayerDirection() {

        cubeGoingRight = !cubeGoingRight;
    
    }

}
