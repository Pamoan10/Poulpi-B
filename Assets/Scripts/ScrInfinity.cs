using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrInfinity : MonoBehaviour
{
    //la imatge mesura 2048px i hi ha 4
    private void OnBecameInvisible()
    {
        transform.Translate(20.48f * 4, 0f, 0f);
    }
}
