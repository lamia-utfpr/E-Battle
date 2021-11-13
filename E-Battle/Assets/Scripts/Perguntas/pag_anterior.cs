using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pag_anterior : MonoBehaviour
{

    [SerializeField]
    private GameObject tabela;

    public AudioSource audioAntPagina;
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
        if (tabela.GetComponent<tabelaDosTemas>().get_PaginaTabela() - 1 >= 1)
        {
            tabela.GetComponent<tabelaDosTemas>().set_PaginaTabela(tabela.GetComponent<tabelaDosTemas>().get_PaginaTabela() - 1);
            tabela.GetComponent<tabelaDosTemas>().preencherTemas(null);
            //           audioAntPagina = GameObject.Find("pagina_anterior").GetComponent<AudioSource>();
            //            audioAntPagina.Play();
        }
    }

    public void mudarPaginaPerguntas()
    {
        if (tabela.GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() - 1 >= 1)
        {
            tabela.GetComponent<tabelaDosTemas>().set_PaginaTabelaPerguntas(tabela.GetComponent<tabelaDosTemas>().get_PaginaTabelaPerguntas() - 1);
            tabela.GetComponent<tabelaDosTemas>().preencherPerguntas(-99, null);
            //           audioAntPagina = GameObject.Find("pagina_anterior").GetComponent<AudioSource>();
            //            audioAntPagina.Play();
        }
    }
}
