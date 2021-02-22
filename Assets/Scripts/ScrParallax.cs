using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrParallax : MonoBehaviour
{
    private float lenght, startpos;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxEffect;


    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
