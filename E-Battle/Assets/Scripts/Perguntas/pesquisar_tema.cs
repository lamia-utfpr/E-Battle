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
    private AudioSource som;
    public AudioClip sons;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pesquisarTema(){
/*        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        som.clip = sons;
        som.Play();*/
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().set_inicio(0);
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().set_PaginaTabela(1);
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().preencherTemas(tema.text);
    }


}
