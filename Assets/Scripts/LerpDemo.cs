using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    [Range(0f, 1f)]
    [SerializeField] float t;

    public AnimationCurve coolCurve;

    public Transform start;
    public Transform end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.Lerp(start.position, end.position, coolCurve.Evaluate(t));
        
    }
}
