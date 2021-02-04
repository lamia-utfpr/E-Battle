using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusearPerguntaSemAlternativaCorreta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void inserirPerguntaComNenhumaAltCorreta(){
        GameObject.Find("Valor_slider").GetComponent<slider_value>().inserirPerguntaSemAlternativaCorreta();
    }

    public void NaoInserirPerguntaComNenhumaAltCorreta(){
        GameObject.Find("Valor_slider").GetComponent<slider_value>().naoInserirPerguntaSemAlternativaCorreta();
    }
}
