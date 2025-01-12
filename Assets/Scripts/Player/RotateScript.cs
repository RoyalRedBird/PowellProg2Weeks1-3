using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    [SerializeField] PlayerScript pScript;
    [SerializeField] float speenSpeed = 0.1f;

    [SerializeField] bool pointAtMouse = false;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        pScript = GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 playerRotation = pScript.PlayerPosition.eulerAngles;        
        Vector3 direction = mousePos - transform.position;


        if (!pointAtMouse)
        {

            transform.up = new Vector3(0, 0, 0);

            if (pScript.cubeGoingRight)
            {

                playerRotation.z -= 0.1f;

            }
            else
            {

                playerRotation.z += 0.1f;

            }

            pScript.PlayerPosition.eulerAngles = playerRotation;

        }
        else{

            transform.up = direction;

        }
        

        

    }
}
