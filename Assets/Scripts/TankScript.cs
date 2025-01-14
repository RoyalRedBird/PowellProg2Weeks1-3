using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{

    [SerializeField] public Transform GunBarrel;
    [SerializeField] float MoveSpeed = 1.0f;

    bool tankFacingRight = true;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {

        GunBarrel = GameObject.Find("GunBarrelAssembly").transform;
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Test Right
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenWorldSize = new Vector2();

        screenWorldSize = cam.ScreenToWorldPoint(screenSize);

        //Test Left
        Vector2 screenWorldZero = cam.ScreenToWorldPoint(Vector2.zero);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 gunDirection = mousePos - GunBarrel.transform.position;

        Vector2 pos = transform.position;

        float movementSpeed = Input.GetAxis("Horizontal") * MoveSpeed;

        if (pos.x + movementSpeed > screenWorldSize.x || pos.x + movementSpeed < screenWorldZero.x) { 
        
            movementSpeed = 0;
        
        }

        pos.x += movementSpeed;
        
        transform.position = pos;

        Vector3 tankTransform = transform.localScale;

        Debug.Log("Right is " + Input.GetKey("d"));
        Debug.Log("Left is " + Input.GetKey("a"));

        if (Input.GetKey("d"))
        {

            if (!tankFacingRight) {

                tankTransform.x *= -1;

            }

            tankFacingRight = true;

        }
        else if(Input.GetKey("a")) {

            if (tankFacingRight) {

                tankTransform.x *= -1;

            }

            tankFacingRight = false;           

        }

        transform.localScale = tankTransform;

        if (tankFacingRight)
        {

            GunBarrel.transform.right = gunDirection * -1;

        }
        else {

            GunBarrel.transform.right = gunDirection * 1;

        }
        
        
    }
}
