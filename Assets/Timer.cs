using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int contador;
    public Text texto;

    void Start()
    {
        StartCoroutine(Temporizador());
    }

    IEnumerator Temporizador()
    {
        while (contador > 0)
        {
            texto.text = contador.ToString();

            yield return new WaitForSeconds(1f);

            contador--;
        }
    }

    public void adicionarTempo()
    {
        texto.GetComponent<Timer>().contador += 10;
    }
   
}
