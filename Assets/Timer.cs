using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int contador = 10;
    public Text texto;
    public Button zerado;

    void Start()
    {
        StartCoroutine(Temporizador());
        contador = 10;
    }

    IEnumerator Temporizador()
    {
        while (contador > 0)
        {
            texto.text = contador.ToString();

            yield return new WaitForSeconds(1f);

            contador--;

        }

        zerado.GetComponent<OnClick>().ErroDePergunta();

    }

    public void adicionarTempo()
    {
        texto.GetComponent<Timer>().contador += 10;
    }
   
}
