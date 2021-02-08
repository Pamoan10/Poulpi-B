using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControlGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if (UNITY_EDITOR)
        AudioListener.pause = true;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) AudioListener.pause = !AudioListener.pause;
        if (Input.GetKeyDown(KeyCode.X)) Debug.Break();
    }
}
