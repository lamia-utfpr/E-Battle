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

    public Button pesquisar;
    public Text tema;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pesquisarTema(){
        
        Dictionary<int, string> temas = bancoDeDados.pesquisarTemas(tema.text);

        Debug.Log("Temas:");
        
        foreach (KeyValuePair<int, string> item in temas){
            Debug.Log("chave: " + item.Key + " valor: " + item.Value);
        }
    }


}
