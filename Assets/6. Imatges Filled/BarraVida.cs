using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVida : MonoBehaviour {


	[SerializeField] Image blanca, sakura;
    enum Personajes {Blanca,Sakura};

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) CanviaVida(Personajes.Blanca, 0.1f);
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) CanviaVida(Personajes.Blanca, -0.1f);
        if (Input.GetKeyDown(KeyCode.Alpha1)) CanviaVida(Personajes.Sakura, -0.1f);
        if (Input.GetKeyDown(KeyCode.Alpha2)) CanviaVida(Personajes.Sakura, 0.1f);
    }

    void CanviaVida(Personajes qui, float quant)
	{
        // No s'han de verificar que els valors estiguin entre 0 i 1, se n'encarrega Unity
        if (qui == Personajes.Blanca) blanca.fillAmount += quant;
            else sakura.fillAmount += quant;
	}


}
