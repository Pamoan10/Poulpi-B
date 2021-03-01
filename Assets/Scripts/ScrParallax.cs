using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrParallax : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0f;

    
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
    }
}
