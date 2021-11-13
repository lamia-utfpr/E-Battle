using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prox_pagina : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioProxPagina;

    [SerializeField]
    private GameObject tabela;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mudarPagina()
    {

        if (tabela.GetComponent<tabelaDosTemas>().get_PaginaTabela() + 1 <= tabela.GetComponent<tabelaDosTemas>().get_qtd_maxima_paginas())
        {
            tabela.GetComponent<tabelaDosTemas>().set_PaginaTabela(tabela.GetComponent<tabelaDosTemas>().get_PaginaTabela() + 1);
            tabela.GetComponent<tabelaDosTemas>().preencherTemas(null);
            //audioProxPagina = GameObject.Find("proxima_pagina").GetComponent<AudioSource>();
            //audioProxPagina.Play();
        }
    }


    public void mudarPaginaPerguntas()
    {
        if (tabela.GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() + 1 <= tabela.GetComponent<tabelaDosTemas>().get_qtd_maxima_paginas_perguntas())
        {
            tabela.GetComponent<tabelaDosTemas>().set_PaginaTabelaPerguntas(tabela.GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() + 1);
            GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().preencherPerguntas(-99, null);
            //audioProxPagina = GameObject.Find("proxima_pagina").GetComponent<AudioSource>();
            //audioProxPagina.Play();
        }
    }

}
