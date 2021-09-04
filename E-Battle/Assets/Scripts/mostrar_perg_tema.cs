using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrar_perg_tema : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exibir()
    {
        GameObject.Find("fundo_tabela_perguntas").transform.position = GameObject.Find("Main Camera").transform.position + new Vector3(0, 0, 1);
        tabelaDosTemas.perguntasNaTela = true;

        int numBotao = int.Parse(this.name.Substring(this.name.Length - 1));
        int pagina = GameObject.Find("tabela").GetComponent<tabelaDosTemas>().get_PaginaTabela();

        int indice = pagina * 5 - (5 - numBotao);

        GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().preencherPerguntas(tabelaDosTemas.return_cod_tema(indice - 1), tabelaDosTemas.return_tema_nome(indice-1));
    }

    public void tirar()
    {
        GameObject.Find("fundo_tabela_perguntas").transform.position = new Vector3(4000, 0, 0);
        tabelaDosTemas.inicioPerguntas = 0;
        GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().set_PaginaTabelaPerguntas(1);
        tabelaDosTemas.perguntasNaTela = false;
    }
}
