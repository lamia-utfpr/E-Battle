using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class selecionar_tema : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nome_tema;
    public Button pesquisarTemas;
    public GameObject pesquisar;
    private int cod_tema = -1;


    public void set_tema (int cod){
        cod_tema = cod;
    }

    public int get_tema(){
        return cod_tema;
    }

    void Start()
    {
        nome_tema.text ="Nenhum";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarPainelPesquisa(){
        pesquisar.transform.position = new Vector3(400, 120, 0);
        GameObject.Find("mostrar_temas/tabela").GetComponent<tabela>().inicializarTabela();
    }

    public void tirarPainelPesquisa(){
        pesquisar.transform.position = new Vector3(3000, 120, 0);
        GameObject.Find("mostrar_temas/tabela").GetComponent<tabela>().inicializarTabela();
    }
}
