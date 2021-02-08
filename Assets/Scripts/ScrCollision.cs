using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar les col·lisions
/// AUTOR:  Paula Moreta
/// DATA:   08/02/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. 
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrCollision : MonoBehaviour
{
    [SerializeField] float vitality = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScrDamage scrD = collision.GetComponent<ScrDamage>(); //intentem llegir script scrDamage

        if (scrD) //si en té, és un objecte que treu vida. Calculem
        {
            if (tag == "Player" && scrD.damagePlayer > 0) vitality -= scrD.damagePlayer; //sóc el player i l'objecte em treu vida
            else if (tag != "Player" && scrD.damageNPC > 0) vitality -= scrD.damageNPC; //sóc un NPC i l'objecte em treu vida

            // si la col·lisió és amb un projectil, el destruim
            if (collision.tag == "shot") collision.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);

            //si no em quda vida, m'autodestrueixo
            if (vitality <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
        }
    }
}
