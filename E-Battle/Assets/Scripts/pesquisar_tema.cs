using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class pesquisar_tema : MonoBehaviour
{
    // Start is called before the first frame update
    private BancoDeDados bancoDeDados = new BancoDeDados();

    public Text tema;
    tabela t;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pesquisarTema(){
      GameObject.Find("tabela").GetComponent<tabela>().set_inicio(0);
      GameObject.Find("tabela").GetComponent<tabela>().set_PaginaTabela(1);
      GameObject.Find("tabela").GetComponent<tabela>().preencherTemas(tema.text);
    }


}
