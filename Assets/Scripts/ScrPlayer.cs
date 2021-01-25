using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player
/// AUTOR:  Paula Moreta
/// DATA:   18/01/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Moviment de la nau amb tecles i físiques
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrPlayer : MonoBehaviour
{
    [SerializeField] float velocitat = 10f;
    Vector2 movi = new Vector2();   // per calcular moviment
    Rigidbody2D rb;                 // per accedir al component rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //donem valor al rb
    }

    // Update is called once per frame
    void Update()
    {
        movi.x = Input.GetAxis("Horizontal");
        movi.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = movi;
    }
}
