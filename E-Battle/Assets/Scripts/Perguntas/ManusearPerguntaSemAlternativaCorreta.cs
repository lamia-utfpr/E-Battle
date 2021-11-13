using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusearPerguntaSemAlternativaCorreta : MonoBehaviour
{

    [SerializeField]
    private GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void inserirPerguntaComNenhumaAltCorreta(){
        slider.GetComponent<slider_value>().inserirPerguntaSemAlternativaCorreta();
    }

    public void NaoInserirPerguntaComNenhumaAltCorreta(){
        slider.GetComponent<slider_value>().naoInserirPerguntaSemAlternativaCorreta();
    }
}
