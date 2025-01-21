using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public bool hasBeenFired = false;
    private float lifeTime = 3;
    void Update()
    {

        if (hasBeenFired)
        {

            Movement();

        }
        else {

            PointAtMouse();

        }
        
    }

    void PointAtMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 direction = mouse - transform.position;

        transform.up = direction;
    }

    void Movement()
    {

        transform.position += transform.up * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {

            Destroy(gameObject);

        }

    }
}
