using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShot : MonoBehaviour
{
    [SerializeField] float vel = 20f;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
    void Destruccio() //Indica com es destrueix
    {
        Destroy(gameObject);
    }
}
