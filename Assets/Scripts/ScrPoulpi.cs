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
///         3.0: tercera versió. Afegir bales
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

    // **************GESTIÓ SHOOTING**************
    [SerializeField] Transform cano;
    [SerializeField] GameObject projectil;
    [SerializeField] float cadenciaMin = 1, cadenciaMax = 3; //temps entre dispars
    float crono;

    Renderer r; //no apunta a res, hem de fer que apunti a quelcom desde el start
    Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velY = Random.Range(2f, -2f);
        desfase = Random.Range(0f, 360f);
        r = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();
        col.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player"); //apunta a la nau
        if (tipusMoviment == 0) tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1); //el +1 es porque el random range si es con ints, pilla hasta el ultimo del rango - 1   

        crono = Random.Range(cadenciaMin, cadenciaMax); //preparem el primer tret
    }
    private void Update()
    {
        //if (r.isVisible)
        if(ScrControlGame.EsVisibleDesde(r, Camera.main))
        {
            crono -= Time.deltaTime;
            if (crono <= 0) Dispara();
            col.enabled = true;
        }
    }
    void Dispara()
    {
        GameObject p = Instantiate(projectil, cano.position, cano.rotation);
        p.transform.Rotate(0, 0, Random.Range(-10f, 10f));
        crono = Random.Range(cadenciaMin, cadenciaMax); //següent tret
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
        CalculaMoviment(tipusMoviment);
        rb.velocity = moviment;
    }
    
    void Destruccio() //Indica com es destrueix
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
