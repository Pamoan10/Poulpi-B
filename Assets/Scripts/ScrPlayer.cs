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
///         2.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Moviment de la nau amb tecles i físiques
///         2.0: segona versió.  Implementació de joystick
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrPlayer : MonoBehaviour
{
    [SerializeField] float velocitat = 10f;
    Vector2 movi = new Vector2();   // per calcular moviment
    Rigidbody2D rb;                 // per accedir al component rigidbody

    //************************************Gestió shot**********************************
    [SerializeField] GameObject missil; //element a instanciar, arrosseguem prefab
    [SerializeField] Transform cano; //d'on surt el tret

    //*************************************cool down********************************
    [SerializeField] float cadencia = 0.5f; //dispararà cada 5 dècimes de segon
    float crono = 0f; //per comptar el temps de cadència

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //donem valor al rb
    }

    // Update is called once per frame
    void Update()
    {
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;

        if (ETCInput.GetButton("Shoot") && crono > cadencia) Dispara();
        crono += Time.deltaTime;

        if (ETCInput.GetButtonUp("Shoot")) crono = cadencia; //permet disparar ràpid amb múltiples clices
    }
    private void FixedUpdate()
    {
        rb.velocity = movi; //Apliquem velocitat amb fisiques
    }
    void Dispara()
    {
        Instantiate(missil, cano.position, cano.rotation);
        Instantiate(missil, cano.position, Quaternion.Euler (new Vector3(0, 0, 33)));
        Instantiate(missil, cano.position, Quaternion.Euler (new Vector3(0, 0, -33)));
        crono = 0;
    }
}
