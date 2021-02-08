using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per determinar si l'objecte treu vida al player o als NPC
///         S'assigna a míssils, NPC i tot allò que pugui destruir altres objectes
/// AUTOR:  Paula Moreta
/// DATA:   08/02/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. 
/// ----------------------------------------------------------------------------------
/// </summary>
public class ScrDamage : MonoBehaviour
{
    public float damageNPC = 0f; //quan el mal ho fa un NPC
    public float damagePlayer = 0f; //quan el mal ho fa el player
}
