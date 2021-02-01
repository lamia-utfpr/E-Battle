using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prox_pagina : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void mudarPagina(){
        
        if (GameObject.Find("tabela").GetComponent<tabela>().paginaTabela + 1 <= GameObject.Find("tabela").GetComponent<tabela>().qtd_maxima_paginas){
            GameObject.Find("tabela").GetComponent<tabela>().paginaTabela += 1;
            GameObject.Find("tabela").GetComponent<tabela>().preencherTemas(null);
        }
        


    }
}
