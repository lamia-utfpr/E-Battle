using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class tabelaDosTemas : MonoBehaviour
{

    public AudioSource audioSemResultado;
    // Start is called before the first frame update

    //componentes da tabela
    Image fundo_tabela;
    Image nome_temaFundo;
    Text nome_temaTexto;
    Image acao_temaFundo;
    Text acao_temaTexto;
    //

    //campo da alternativa 1:
    Text texto_alternativa1;
    Image fundo_alternativa1;
    Toggle toogle1;
    Image toggleImage1;
    Text toggleText1;
    GameObject verPerg1;
    //


    //campo da alternativa 2:
    Image fundo_alternativa2;
    Text texto_alternativa2;
    Toggle toogle2;
    Image toggleImage2;
    Text toggleText2;
    GameObject verPerg2;
    //

    //campo da alternativa 3:
    Image fundo_alternativa3;
    Text texto_alternativa3;
    Toggle toogle3;
    Image toggleImage3;
    Text toggleText3;
    GameObject verPerg3;
    //

    //campo da alternativa 4:
    Image fundo_alternativa4;
    Text texto_alternativa4;
    Toggle toogle4;
    Image toggleImage4;
    Text toggleText4;
    GameObject verPerg4;
    //

    //campo da alternativa 5:
    Image fundo_alternativa5;
    Text texto_alternativa5;
    Toggle toogle5;
    Image toggleImage5;
    Text toggleText5;
    GameObject verPerg5;
    //

    //botões de trocar de página e confirmar seleção
    Text proximaPagina;
    Image fundoProxPagina;

    Text paginaAnterior;
    Image fundoPagAnterior;

    Text confirmarEscolha;
    Image fundoConfEscolha;

    Text paginaAtual;
    //
    private static int paginaTabela = 1;

    private static int paginaTabelaPerguntas = 1;
    private int qtd_maxima_paginas;

    private int qtd_maxima_paginasPerguntas;

    Dictionary<int, string> temas;

    static List<string> perguntasTema;

    public static int inicioPerguntas = 0;
    public static bool perguntasNaTela = false;

    private int inicio = 0;
    private static int toggle_selecionado = -1;
    private static string[] tema_nome;
    private static int[] cod_tema;

    public static string pesquisaAtual = "";


    public void set_PaginaTabela(int pag)
    {
        paginaTabela = pag;
    }

    public void set_PaginaTabelaPerguntas(int pag)
    {
        paginaTabelaPerguntas = pag;
    }

    public static void setPerguntasTema(List<string> perguntas)
    {
        perguntasTema = perguntas;
    }

    public int get_PaginaTabela()
    {
        return paginaTabela;
    }

    public int get_PaginaTabelaPerguntas()
    {
        return paginaTabelaPerguntas;
    }

    public static int return_cod_tema(int indice, int numBotao)
    {
        try
        {
            return cod_tema[indice];
        }
        catch (Exception ex)
        {
            for (int i = numBotao; i < 5; i++)
            {
                GameObject.Find("verPerg" + numBotao).GetComponent<Button>().interactable = false;
                GameObject.Find("verPerg" + numBotao + "/Text").GetComponent<Text>().text = "";
                GameObject.Find("verPerg" + numBotao).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }

            return -1;
        }


    }

    public static string return_tema_nome(int indice)
    {
        return tema_nome[indice];
    }

    public void set_qtd_max_paginas(int qtd)
    {
        qtd_maxima_paginas = qtd;
    }

    public int get_qtd_maxima_paginas()
    {
        return qtd_maxima_paginas;
    }

    public void set_qtd_max_paginas_perguntas(int qtd)
    {
        qtd_maxima_paginasPerguntas = qtd;
    }

    public int get_qtd_maxima_paginas_perguntas()
    {
        return qtd_maxima_paginasPerguntas;
    }

    public void set_inicio(int ini)
    {
        inicio = ini;
    }

    public int get_inicio()
    {
        return inicio;
    }


    public void inicializarTabela()
    {
        //inicializando o fundo da tabela
        fundo_tabela = GetComponent<Image>();
        fundo_tabela.color = new Color(0, 0, 0, 0);

        //inicializando nome do tema
        nome_temaFundo = this.transform.Find("nome_tema").GetComponent<Image>();
        nome_temaFundo.color = new Color(0, 0, 0, 0);

        nome_temaTexto = this.transform.Find("nome_tema/nome_tema").GetComponent<Text>();
        nome_temaTexto.color = new Color(0, 0, 0, 0);

        //inicializando a coluna "acao" da tabela
        acao_temaFundo = this.transform.Find("nome_tema/Imagem").GetComponent<Image>();
        acao_temaFundo.color = new Color(255, 255, 255, 0);

        acao_temaTexto = this.transform.Find("nome_tema/acao_tema").GetComponent<Text>();
        acao_temaTexto.color = new Color(0, 0, 0, 0);

        //inicializando os botões de troca de página e confirmação de seleção
        alterarBotaoProxPagina(0);
        alterarBotaoPaginaAnterior(0);
        alterarBotaoConfirmarEscolha(0);

        InputField texto_pesquisa = GameObject.Find("inserir_tema_pesquisar").GetComponent<InputField>();

        texto_pesquisa.text = "";

        paginaAtual = this.transform.Find("texto_pagina").GetComponent<Text>();
        paginaAtual.text = "";

        alterarAlt1(0, null, 0);
        alterarAlt2(0, null, 0);
        alterarAlt3(0, null, 0);
        alterarAlt4(0, null, 0);
        alterarAlt5(0, null, 0);
        temas = null;
        perguntasTema = null;
    }

    void Start()
    {

        inicializarTabela();
        preencherTemas(pesquisaAtual);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void confirmar_temaPartida()
    {
        int tema_jogo = -1;

        if (toggle_selecionado == 1)
        {
            tema_jogo = cod_tema[paginaTabela * 5 - 5];
        }
        else if (toggle_selecionado == 2)
        {
            tema_jogo = cod_tema[paginaTabela * 5 - 4];
        }
        else if (toggle_selecionado == 3)
        {
            tema_jogo = cod_tema[paginaTabela * 5 - 3];
        }
        else if (toggle_selecionado == 4)
        {
            tema_jogo = cod_tema[paginaTabela * 5 - 2];
        }
        else if (toggle_selecionado == 5)
        {
            tema_jogo = cod_tema[paginaTabela * 5 - 1];
        }

        apresentarPergunta.set_id_tema(tema_jogo);
    }

    public void confirmar_tema()
    {
        if (toggle_selecionado == 1)
        {
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela * 5 - 5];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela * 5 - 5]);
        }
        else if (toggle_selecionado == 2)
        {
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela * 5 - 4];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela * 5 - 4]);
        }
        else if (toggle_selecionado == 3)
        {
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela * 5 - 3];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela * 5 - 3]);
        }
        else if (toggle_selecionado == 4)
        {
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela * 5 - 2];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela * 5 - 2]);
        }
        else if (toggle_selecionado == 5)
        {
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela * 5 - 1];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela * 5 - 1]);
        }

        GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().tirarPainelPesquisa();
    }


    private int qtd_temas;

    public int get_qtd_temas(){
        return qtd_temas;
    }

    public void preencherTemas(string tema)
    {
        pesquisaAtual = tema;
        alterarBotaoConfirmarEscolha(1);

        if (inicio == 0)
        {
            temas = BancoDeDados.pesquisarTemas(tema);
            inicio = 1;
        }


        Text semRetorno = this.transform.Find("sem_retorno_banco").GetComponent<Text>();
        semRetorno.text = "";

        //RectTransform tamanhoTexto = semRetorno.GetComponent<RectTransform>();
        //tamanhoTexto.sizeDelta = new Vector2(50, 81);

        fundo_tabela.color = new Color(147, 147, 147, 100);

        qtd_temas = temas.Count;

        qtd_maxima_paginas = (int)Math.Ceiling(Decimal.Divide(qtd_temas, 5));

        paginaAtual.text = "Página: " + paginaTabela + "/" + Math.Ceiling(Decimal.Divide(qtd_temas, 5));

        if (qtd_maxima_paginas <= 1)
        {
            alterarBotaoProxPagina(0);
            alterarBotaoPaginaAnterior(0);
        }
        else
        {
            alterarBotaoProxPagina(1);
            alterarBotaoPaginaAnterior(1);
        }

        //paginaAtual.color = new Color(0, 0, 0, 1);
        int i = 0;

        //o trecho abaixo separa o dicionário contendo os temas em 2 vetores, um com o ID e o outro com o Nome
        tema_nome = new string[qtd_temas];
        cod_tema = new int[qtd_temas];

        foreach (KeyValuePair<int, string> item in temas)
        {
            tema_nome[i] = item.Value;
            cod_tema[i] = item.Key;
            i++;
        }
        //

        for (i = paginaTabela * 5 - 5; i < (paginaTabela * 5); i++)
        {

            if (i >= cod_tema.Length)
            {
                break;
            }
            else
            {
                if (i == (paginaTabela * 5 - 5))
                {
                    alterarAlt1(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela * 5 - 4))
                {
                    alterarAlt2(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela * 5 - 3))
                {
                    alterarAlt3(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela * 5 - 2))
                {
                    alterarAlt4(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela * 5 - 1))
                {
                    alterarAlt5(1, tema_nome[i], cod_tema[i]);
                }
            }
        }

        if (i == (paginaTabela * 5 - 4))
        {
            alterarAlt2(0, null, 0);
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }
        else if (i == (paginaTabela * 5 - 3))
        {
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }
        else if (i == (paginaTabela * 5 - 2))
        {
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }
        else if (i == (paginaTabela * 5 - 1))
        {
            alterarAlt5(0, null, 0);
        }
        else if (i == (paginaTabela * 5 - 5))
        {
            alterarBotaoConfirmarEscolha(0);
            alterarAlt1(0, null, 0);
            alterarAlt2(0, null, 0);
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
            semRetorno.text = "Não foi encontrado nenhum resultado para a pesquisa";
            //semRetorno.color = new Color(0, 0, 0, 1); 
            audioSemResultado = GameObject.Find("tabela").GetComponent<AudioSource>();
            audioSemResultado.Play();

            //tamanhoTexto = semRetorno.GetComponent<RectTransform>();
            //tamanhoTexto.sizeDelta = new Vector2(900, 81);

            paginaAtual.text = "";
            fundo_tabela.color = new Color(147, 147, 147, 0);
        }
    }

    public void preencherPerguntas(int idTema, string temaNome)
    {

        if (idTema < 0)
        {
            alterarBotaoConfirmarEscolha(0);
            alterarAlt1(0, null, 0);
            alterarAlt2(0, null, 0);
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
            Text semRetorno = this.transform.Find("sem_retorno_banco").GetComponent<Text>();
            semRetorno.text = "Não há nenhuma pergunta cadastrada neste tema.";
            //semRetorno.color = new Color(0, 0, 0, 1); 
            //            audioSemResultado = GameObject.Find("tabela").GetComponent<AudioSource>();
            //            audioSemResultado.Play();

            //tamanhoTexto = semRetorno.GetComponent<RectTransform>();
            //tamanhoTexto.sizeDelta = new Vector2(900, 81);

            paginaAtual.text = "";
            fundo_tabela.color = new Color(147, 147, 147, 0);
        }
        else
        {
            if (inicioPerguntas == 0)
            {
                BancoDeDados.retornarPerguntasDeUmTemaTelaTemas(idTema);
                GameObject.Find("fundo_tabela_perguntas/tabela/titulo").GetComponent<Text>().text = "Perguntas cadastradas no tema " + temaNome;
                inicioPerguntas = 1;
            }

            Text semRetorno = this.transform.Find("sem_retorno_banco").GetComponent<Text>();
            semRetorno.text = "";

            //RectTransform tamanhoTexto = semRetorno.GetComponent<RectTransform>();
            //tamanhoTexto.sizeDelta = new Vector2(50, 81);

            fundo_tabela.color = new Color(147, 147, 147, 100);

            int qtd_perguntas = perguntasTema.Count;

            qtd_maxima_paginasPerguntas = (int)Math.Ceiling(Decimal.Divide(qtd_perguntas, 5));

            paginaAtual.text = "Página: " + paginaTabelaPerguntas + "/" + Math.Ceiling(Decimal.Divide(qtd_perguntas, 5));

            if (qtd_maxima_paginasPerguntas <= 1)
            {
                alterarBotaoProxPagina(0);
                alterarBotaoPaginaAnterior(0);
            }
            else
            {
                alterarBotaoProxPagina(1);
                alterarBotaoPaginaAnterior(1);
            }

            //paginaAtual.color = new Color(0, 0, 0, 1);
            int i = 0;


            for (i = paginaTabelaPerguntas * 5 - 5; i < (paginaTabelaPerguntas * 5); i++)
            {

                if (i >= perguntasTema.Count)
                {
                    break;
                }
                else
                {
                    if (i == (paginaTabelaPerguntas * 5 - 5))
                    {
                        alterarAlt1(1, perguntasTema[i], 0);
                    }
                    else if (i == (paginaTabelaPerguntas * 5 - 4))
                    {
                        alterarAlt2(1, perguntasTema[i], 0);
                    }
                    else if (i == (paginaTabelaPerguntas * 5 - 3))
                    {
                        alterarAlt3(1, perguntasTema[i], 0);
                    }
                    else if (i == (paginaTabelaPerguntas * 5 - 2))
                    {
                        alterarAlt4(1, perguntasTema[i], 0);
                    }
                    else if (i == (paginaTabelaPerguntas * 5 - 1))
                    {
                        alterarAlt5(1, perguntasTema[i], 0);
                    }
                }
            }

            if (i == (paginaTabelaPerguntas * 5 - 4))
            {
                alterarAlt2(0, null, 0);
                alterarAlt3(0, null, 0);
                alterarAlt4(0, null, 0);
                alterarAlt5(0, null, 0);
            }
            else if (i == (paginaTabelaPerguntas * 5 - 3))
            {
                alterarAlt3(0, null, 0);
                alterarAlt4(0, null, 0);
                alterarAlt5(0, null, 0);
            }
            else if (i == (paginaTabelaPerguntas * 5 - 2))
            {
                alterarAlt4(0, null, 0);
                alterarAlt5(0, null, 0);
            }
            else if (i == (paginaTabelaPerguntas * 5 - 1))
            {
                alterarAlt5(0, null, 0);
            }
            else if (i == (paginaTabelaPerguntas * 5 - 5))
            {
                alterarBotaoConfirmarEscolha(0);
                alterarAlt1(0, null, 0);
                alterarAlt2(0, null, 0);
                alterarAlt3(0, null, 0);
                alterarAlt4(0, null, 0);
                alterarAlt5(0, null, 0);
                semRetorno.text = "Não há nenhuma pergunta cadastrada neste tema.";
                //semRetorno.color = new Color(0, 0, 0, 1); 
                //            audioSemResultado = GameObject.Find("tabela").GetComponent<AudioSource>();
                //            audioSemResultado.Play();

                //tamanhoTexto = semRetorno.GetComponent<RectTransform>();
                //tamanhoTexto.sizeDelta = new Vector2(900, 81);

                paginaAtual.text = "";
                fundo_tabela.color = new Color(147, 147, 147, 0);
            }
        }
    }

    private void alterarAlt1(int op, string nome_tema, int cod_tema)
    {

        fundo_alternativa1 = this.transform.Find("alt_1").GetComponent<Image>();
        texto_alternativa1 = this.transform.Find("alt_1/Text").GetComponent<Text>();
        toogle1 = this.transform.Find("alt_1/Toggle").GetComponent<Toggle>();
        toggleText1 = this.transform.Find("alt_1/Toggle/Label").GetComponent<Text>();
        toggleImage1 = this.transform.Find("alt_1/Toggle/Background").GetComponent<Image>();

        if (SceneManager.GetActiveScene().name == "Criação de temas")
            verPerg1 = GameObject.Find("alt_1/perg_alt1");

        if (op == 0)
        {

            fundo_alternativa1.color = new Color(255, 255, 255, 0);
            texto_alternativa1.text = "";
            toogle1.isOn = false;
            toggleImage1.color = new Color(255, 255, 255, 0);
            toggleText1.text = "";
            if (SceneManager.GetActiveScene().name == "Criação de temas" && !perguntasNaTela)
            {
                verPerg1.GetComponent<Button>().interactable = false;
                GameObject.Find(verPerg1.name + "/Text").GetComponent<Text>().text = "";
                verPerg1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }

        else if (op == 1)
        {

            fundo_alternativa1.color = new Color(255, 255, 255, 1);
            texto_alternativa1.text = nome_tema;
            toogle1.isOn = false;
            toggleImage1.color = new Color(255, 255, 255, 1);
            toggleText1.text = "Selecionar";
            if (SceneManager.GetActiveScene().name == "Criação de temas")
            {
                verPerg1.GetComponent<Button>().interactable = true;
                GameObject.Find(verPerg1.name + "/Text").GetComponent<Text>().text = "Ver perguntas";
                verPerg1.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }

        }
    }

    private void alterarAlt2(int op, string nome_tema, int cod_tema)
    {
        fundo_alternativa2 = this.transform.Find("alt_2").GetComponent<Image>();
        texto_alternativa2 = this.transform.Find("alt_2/Text").GetComponent<Text>();
        toogle2 = this.transform.Find("alt_2/Toggle").GetComponent<Toggle>();
        toggleImage2 = this.transform.Find("alt_2/Toggle/Background").GetComponent<Image>();
        toggleText2 = this.transform.Find("alt_2/Toggle/Label").GetComponent<Text>();

        if (SceneManager.GetActiveScene().name == "Criação de temas")
            verPerg2 = GameObject.Find("alt_2/perg_alt2");


        if (op == 0)
        {
            fundo_alternativa2.color = new Color(255, 255, 255, 0);
            texto_alternativa2.text = "";
            toogle2.isOn = false;
            toggleImage2.color = new Color(255, 255, 255, 0);
            toggleText2.text = "";
            if (SceneManager.GetActiveScene().name == "Criação de temas" && !perguntasNaTela)
            {
                verPerg2.GetComponent<Button>().interactable = false;
                GameObject.Find(verPerg2.name + "/Text").GetComponent<Text>().text = "";
                verPerg2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
        else if (op == 1)
        {
            int codigo = cod_tema;

            fundo_alternativa2.color = new Color(255, 255, 255, 1);
            texto_alternativa2.text = nome_tema;
            toogle2.isOn = false;
            toggleImage2.color = new Color(255, 255, 255, 1);
            toggleText2.text = "Selecionar";
            if (SceneManager.GetActiveScene().name == "Criação de temas")
            {
                verPerg2.GetComponent<Button>().interactable = true;
                GameObject.Find(verPerg2.name + "/Text").GetComponent<Text>().text = "Ver perguntas";
                verPerg2.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
        }
    }

    private void alterarAlt3(int op, string nome_tema, int cod_tema)
    {
        fundo_alternativa3 = this.transform.Find("alt_3").GetComponent<Image>();
        texto_alternativa3 = this.transform.Find("alt_3/Text").GetComponent<Text>();
        toogle3 = this.transform.Find("alt_3/Toggle").GetComponent<Toggle>();
        toggleImage3 = this.transform.Find("alt_3/Toggle/Background").GetComponent<Image>();
        toggleText3 = this.transform.Find("alt_3/Toggle/Label").GetComponent<Text>();

        if (SceneManager.GetActiveScene().name == "Criação de temas")
            verPerg3 = GameObject.Find("alt_3/perg_alt3");

        if (op == 0)
        {
            fundo_alternativa3.color = new Color(255, 255, 255, 0);
            texto_alternativa3.text = "";
            toogle3.isOn = false;
            toggleImage3.color = new Color(255, 255, 255, 0);
            toggleText3.text = "";
            if (SceneManager.GetActiveScene().name == "Criação de temas" && !perguntasNaTela)
            {
                verPerg3.GetComponent<Button>().interactable = false;
                GameObject.Find(verPerg3.name + "/Text").GetComponent<Text>().text = "";
                verPerg3.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
        else if (op == 1)
        {
            int codigo = cod_tema;

            fundo_alternativa3.color = new Color(255, 255, 255, 1);
            texto_alternativa3.text = nome_tema;
            toogle3.isOn = false;
            toggleImage3.color = new Color(255, 255, 255, 1);
            toggleText3.text = "Selecionar";
            if (SceneManager.GetActiveScene().name == "Criação de temas")
            {
                verPerg3.GetComponent<Button>().interactable = true;
                GameObject.Find(verPerg3.name + "/Text").GetComponent<Text>().text = "Ver perguntas";
                verPerg3.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
        }


    }

    private void alterarAlt4(int op, string nome_tema, int cod_tema)
    {
        fundo_alternativa4 = this.transform.Find("alt_4").GetComponent<Image>();
        texto_alternativa4 = this.transform.Find("alt_4/Text").GetComponent<Text>();
        toogle4 = this.transform.Find("alt_4/Toggle").GetComponent<Toggle>();
        toggleImage4 = this.transform.Find("alt_4/Toggle/Background").GetComponent<Image>();
        toggleText4 = this.transform.Find("alt_4/Toggle/Label").GetComponent<Text>();

        if (SceneManager.GetActiveScene().name == "Criação de temas")
            verPerg4 = GameObject.Find("alt_4/perg_alt4");

        if (op == 0)
        {
            fundo_alternativa4.color = new Color(255, 255, 255, 0);
            texto_alternativa4.text = "";
            toogle4.isOn = false;
            toggleImage4.color = new Color(255, 255, 255, 0);
            toggleText4.text = "";
            if (SceneManager.GetActiveScene().name == "Criação de temas" && !perguntasNaTela)
            {
                verPerg4.GetComponent<Button>().interactable = false;
                GameObject.Find(verPerg4.name + "/Text").GetComponent<Text>().text = "";
                verPerg4.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
        else if (op == 1)
        {
            int codigo = cod_tema;

            fundo_alternativa4.color = new Color(255, 255, 255, 1);
            texto_alternativa4.text = nome_tema;
            toogle4.isOn = false;
            toggleImage4.color = new Color(255, 255, 255, 1);
            toggleText4.text = "Selecionar";
            if (SceneManager.GetActiveScene().name == "Criação de temas")
            {
                verPerg4.GetComponent<Button>().interactable = true;
                GameObject.Find(verPerg4.name + "/Text").GetComponent<Text>().text = "Ver perguntas";
                verPerg4.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
        }

    }

    private void alterarAlt5(int op, string nome_tema, int cod_tema)
    {
        fundo_alternativa5 = this.transform.Find("alt_5").GetComponent<Image>();
        texto_alternativa5 = this.transform.Find("alt_5/Text").GetComponent<Text>();
        toogle5 = this.transform.Find("alt_5/Toggle").GetComponent<Toggle>();
        toggleImage5 = this.transform.Find("alt_5/Toggle/Background").GetComponent<Image>();
        toggleText5 = this.transform.Find("alt_5/Toggle/Label").GetComponent<Text>();

        if (SceneManager.GetActiveScene().name == "Criação de temas")
            verPerg5 = GameObject.Find("alt_5/perg_alt5");

        if (op == 0)
        {
            fundo_alternativa5.color = new Color(255, 255, 255, 0);
            texto_alternativa5.text = "";
            toogle5.isOn = false;
            toggleImage5.color = new Color(255, 255, 255, 0);
            toggleText5.text = "";
            if (SceneManager.GetActiveScene().name == "Criação de temas" && !perguntasNaTela)
            {
                verPerg5.GetComponent<Button>().interactable = false;
                GameObject.Find(verPerg5.name + "/Text").GetComponent<Text>().text = "";
                verPerg5.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
        else if (op == 1)
        {
            int codigo = cod_tema;

            fundo_alternativa5.color = new Color(255, 255, 255, 1);
            texto_alternativa5.text = nome_tema;
            toogle5.isOn = false;
            toggleImage5.color = new Color(255, 255, 255, 1);
            toggleText5.text = "Selecionar";
            if (SceneManager.GetActiveScene().name == "Criação de temas")
            {
                verPerg5.GetComponent<Button>().interactable = true;
                GameObject.Find(verPerg5.name + "/Text").GetComponent<Text>().text = "Ver perguntas";
                verPerg5.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
        }
    }


    private void alterarBotaoProxPagina(int op)
    {
        proximaPagina = this.transform.Find("proxima_pagina/Text").GetComponent<Text>();
        fundoProxPagina = this.transform.Find("proxima_pagina").GetComponent<Image>();

        if (op == 0)
        {
            proximaPagina.text = "";
            fundoProxPagina.color = new Color(255, 255, 255, 0);
        }
        else if (op == 1)
        {
            proximaPagina.text = "►";
            fundoProxPagina.color = new Color(255, 255, 255, 1);
        }
    }

    private void alterarBotaoPaginaAnterior(int op)
    {
        paginaAnterior = this.transform.Find("pagina_anterior/Text").GetComponent<Text>();
        fundoPagAnterior = this.transform.Find("pagina_anterior").GetComponent<Image>();

        if (op == 0)
        {
            paginaAnterior.text = "";
            fundoPagAnterior.color = new Color(255, 255, 255, 0);
        }
        else if (op == 1)
        {
            paginaAnterior.text = "◄";
            fundoPagAnterior.color = new Color(255, 255, 255, 1);
        }

    }

    private void alterarBotaoConfirmarEscolha(int op)
    {
        confirmarEscolha = this.transform.Find("confirmar_selecao_tema/Text").GetComponent<Text>();
        fundoConfEscolha = this.transform.Find("confirmar_selecao_tema").GetComponent<Image>();

        if (op == 0)
        {
            confirmarEscolha.text = "";
            fundoConfEscolha.color = new Color(255, 255, 255, 0);
        }
        else if (op == 1)
        {
            confirmarEscolha.text = "Confirmar";
            fundoConfEscolha.color = new Color(255, 255, 255, 1);
        }

    }

    public void statusToggle1(int op)
    {
        if (op == 1)
        {
            toggle_selecionado = 1;
            statusToggle2(0);
            statusToggle3(0);
            statusToggle4(0);
            statusToggle5(0);
        }
        else if (op == 0)
        {
            this.transform.Find("alt_1/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

    public void statusToggle2(int op)
    {
        if (op == 1)
        {
            toggle_selecionado = 2;
            statusToggle1(0);
            statusToggle3(0);
            statusToggle4(0);
            statusToggle5(0);
        }
        else if (op == 0)
        {
            this.transform.Find("alt_2/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

    public void statusToggle3(int op)
    {
        if (op == 1)
        {
            toggle_selecionado = 3;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle4(0);
            statusToggle5(0);
        }
        else if (op == 0)
        {
            this.transform.Find("alt_3/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

    public void statusToggle4(int op)
    {
        if (op == 1)
        {
            toggle_selecionado = 4;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle3(0);
            statusToggle5(0);
        }
        else if (op == 0)
        {
            this.transform.Find("alt_4/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

    public void statusToggle5(int op)
    {
        if (op == 1)
        {
            toggle_selecionado = 5;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle3(0);
            statusToggle4(0);
        }
        else if (op == 0)
        {
            this.transform.Find("alt_5/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

}
