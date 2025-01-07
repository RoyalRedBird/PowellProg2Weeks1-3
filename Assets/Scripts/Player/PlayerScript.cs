using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Transform PlayerPosition;
    [SerializeField]float Speed = 0.001f;
    Camera cam;

    bool cubeGoingRight;

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

        if (FollowMouse)
        {

            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            PlayerPosition.position = mousePos;

        }else{

            pos.y = 0;

            if (cubeGoingRight)
            {

                pos.x += Speed;

            }else{

                pos.x -= Speed;

            }

            if (pos.x + Speed >= 8.4) {

                cubeGoingRight = false;
            
            }

            if (pos.x + Speed <= -8.4)
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
