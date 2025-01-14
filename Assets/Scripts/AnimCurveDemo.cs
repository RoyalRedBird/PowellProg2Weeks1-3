using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCurveDemo : MonoBehaviour
{

    public AnimationCurve curve;

    [Range(0f, 1f)]
    [SerializeField] float t;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;

        if(t >= 1)
        {

            t = 0;

        }

        transform.localScale = Vector3.one * curve.Evaluate(t);
        
    }
}
