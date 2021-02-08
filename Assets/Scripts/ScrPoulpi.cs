using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el pop npc
/// AUTOR:  Paula Moreta
/// DATA:   01/02/2021
/// VERSIÓ: 2.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Moviment del personatge i creació de Random.Range
///         2.0: segona versió.  Destrucció del personatge
/// ----------------------------------------------------------------------------------
/// </summary>
public class ScrPoulpi : MonoBehaviour
{
    [SerializeField] float velX = -5f;
    [SerializeField] GameObject explosio; //Per la destrucció
    Vector2 moviment = new Vector2();
    float velY;
    float desfase;
    [SerializeField]float elast;
    Rigidbody2D rb;

    [SerializeField] int tipusMoviment = 1;
    GameObject player;
    const int QUANTS_MOVIMENTS = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velY = Random.Range(2f, -2f);
        desfase = Random.Range(0f, 360f);

        player = GameObject.FindGameObjectWithTag("Player"); //apunta a la nau
        if (tipusMoviment == 0) tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1); //el +1 es porque el random range si es con ints, pilla hasta el ultimo del rango - 1   
    }
    void CalculaMoviment(int tipus)
    {
        switch (tipus)
        {
            case 1: //moviment a velocitat X
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2:
                moviment.x = velX / 2;
                moviment.y = 0f;
                break;
            case 3:
                moviment.x = velX;
                moviment.y = velY;
                break;
            case 4:
                float amplitud = 4, frequencia = 3;
                moviment.x = velX;
                moviment.y = Mathf.Sin(Time.time * frequencia + desfase) * amplitud; 
                break;
            case 5:
                moviment.x = -3f;
                if (player) moviment.y = (player.transform.position.y - transform.position.y) / elast;
                else moviment.y = 0;
                break;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moviment;
    }
    private void Update()
    {
        CalculaMoviment(tipusMoviment);
    }
    void Destruccio() //Indica com es destrueix
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
