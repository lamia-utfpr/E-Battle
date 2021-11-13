using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrar_perg_tema : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject fundo_tabela;

    [SerializeField]
    private GameObject tabela;

    [SerializeField]
    private GameObject cameraMain;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exibir()
    {
        fundo_tabela.transform.position = cameraMain.transform.position + new Vector3(0, 0, 1);
        tabelaDosTemas.perguntasNaTela = true;

        int numBotao = int.Parse(this.name.Substring(this.name.Length - 1));
        int pagina = tabela.GetComponent<tabelaDosTemas>().get_PaginaTabela();

        int indice = pagina * 5 - (5 - numBotao);

<<<<<<< Updated upstream
        GameObject.Find("fundo_tabela_perguntas/tabela").GetComponent<tabelaDosTemas>().preencherPerguntas(tabelaDosTemas.return_cod_tema(indice - 1), tabelaDosTemas.return_tema_nome(indice-1));
=======
        tabela.GetComponent<tabelaDosTemas>().preencherPerguntas(tabelaDosTemas.return_cod_tema(indice - 1, numBotao), tabelaDosTemas.return_tema_nome(indice-1));
>>>>>>> Stashed changes
    }

    public void tirar()
    {
        fundo_tabela.transform.position = new Vector3(4000, 0, 0);
        tabelaDosTemas.inicioPerguntas = 0;
        tabela.GetComponent<tabelaDosTemas>().set_PaginaTabelaPerguntas(1);
        tabelaDosTemas.perguntasNaTela = false;
    }
}
