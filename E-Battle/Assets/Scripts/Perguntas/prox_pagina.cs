﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prox_pagina : MonoBehaviour
{
    public AudioSource audioProxPagina;
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

        if (GameObject.Find("tabela").GetComponent<tabelaDosTemas>().get_PaginaTabela() + 1 <= GameObject.Find("tabela").GetComponent<tabelaDosTemas>().get_qtd_maxima_paginas())
        {
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().set_PaginaTabela(GameObject.Find("tabela").GetComponent<tabelaDosTemas>().get_PaginaTabela() + 1);
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().preencherTemas(null);
            //audioProxPagina = GameObject.Find("proxima_pagina").GetComponent<AudioSource>();
            //audioProxPagina.Play();
        }
    }


    public void mudarPaginaPerguntas()
    {
        if (GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() + 1 <= GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().get_qtd_maxima_paginas_perguntas())
        {
            GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().set_PaginaTabelaPerguntas(GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() + 1);
            GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().preencherPerguntas(-99, null);
            //audioProxPagina = GameObject.Find("proxima_pagina").GetComponent<AudioSource>();
            //audioProxPagina.Play();
        }
    }

}
