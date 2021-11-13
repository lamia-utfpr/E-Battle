using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class pesquisar_tema : MonoBehaviour
{
    public Text tema;
    tabelaDosTemas t;

    [SerializeField]
    private AudioSource som;

    [SerializeField]
    private AudioClip sons;

    [SerializeField]
    private GameObject tabela;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pesquisarTema(){
        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        som.clip = sons;
        som.Play();
<<<<<<< Updated upstream
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().set_inicio(0);
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().set_PaginaTabela(1);
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().preencherTemas(tema.text);
=======

        tabela.GetComponent<tabelaDosTemas>().set_inicio(0);
        tabela.GetComponent<tabelaDosTemas>().set_PaginaTabela(1);
        tabela.GetComponent<tabelaDosTemas>().preencherTemas(tema.text);
>>>>>>> Stashed changes
    }


}
