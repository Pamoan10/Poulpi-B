using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player
/// AUTOR:  Paula Moreta
/// DATA:   18/01/2021
/// VERSIÓ: 4.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Moviment de la nau amb tecles i físiques
///         2.0: segona versió.  Implementació de joystick
///         3.0: tercera versió. Implementació de powerUp
///         4.0: quarta versió.  Destrucció del personatge
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrPlayer : MonoBehaviour
{
    [SerializeField] float velocitat = 10f;
    Vector2 movi = new Vector2();   // per calcular moviment
    Rigidbody2D rb;                 // per accedir al component rigidbody
    AudioSource so;

    //************************************Gestió shot**********************************
    [SerializeField] GameObject missil; //element a instanciar, arrosseguem prefab
    [SerializeField] Transform[] canons; //d'on surten els trets

    //*************************************cool down********************************
    [SerializeField] float cadencia = 0.5f; //dispararà cada 5 dècimes de segon
    float crono = 0f; //per comptar el temps de cadència
    float cronoPowerUp = 0f;

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

        if (Input.GetKeyDown(KeyCode.T)) //prototipus triple shoot
        {
            SetTripleShot(true);
            cronoPowerUp = 5f;
        }
        if (cronoPowerUp > 0) cronoPowerUp -= Time.deltaTime; else SetTripleShot(false); //Si és més gran a 0, descompta fins que desactiva els canons

        rb = GetComponent<Rigidbody2D>();
        so = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        rb.velocity = movi; //Apliquem velocitat amb fisiques
    }
    void Dispara()
    {
        foreach(Transform cano in canons )
        if(cano.gameObject.activeSelf) Instantiate(missil, cano.position, cano.rotation); //si es visible, dispara, sino ho ignora, cosa que no fa de forma predeterminada
        crono = 0;

        so.Play();
    }
    void SetTripleShot(bool estat)
    {
        canons[0].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);
    }

    void Destruccio() //Indica com es destrueix
    {
        Destroy(gameObject);
    }
}
