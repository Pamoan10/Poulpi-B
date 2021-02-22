using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar les col·lisions
/// AUTOR:  Paula Moreta
/// DATA:   08/02/2021
/// VERSIÓ: 2.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. 
///         2.0: segona versió. Afegir audio
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrCollision : MonoBehaviour
{
    [SerializeField] float vitality = 2f;
    [SerializeField] AudioClip tocat, enfonsat; //Inicialitzem en cada prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool impacte = false;
        
        ScrDamage scrD = collision.GetComponent<ScrDamage>(); //intentem llegir script scrDamage

        if (scrD) //si en té, és un objecte que treu vida. Calculem
        {
            if (tag == "Player" && scrD.damagePlayer > 0)
            {
                vitality -= scrD.damagePlayer; //sóc el player i l'objecte em treu vida
                impacte = true;
            } 
            else if (tag != "Player" && scrD.damageNPC > 0)
            {
                vitality -= scrD.damageNPC; //sóc un NPC i l'objecte em treu vida
                impacte = true;
            }

            if (impacte)
            {
                if (vitality <= 0 && enfonsat) AudioSource.PlayClipAtPoint(enfonsat, Camera.main.transform.position); //si la vitalitat és 0 i té l'audioclip enfonsat associat a ell
                if (vitality > 0 && tocat) AudioSource.PlayClipAtPoint(tocat, Camera.main.transform.position); //si la vitalitat és major a 0 i té l'audioclip tocat associat a ell
            }

            // si la col·lisió és amb un projectil, el destruim
            if (collision.tag == "shot" && impacte) collision.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);

            //si no em quda vida, m'autodestrueixo
            if (vitality <= 0) SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
        }
    }
}
