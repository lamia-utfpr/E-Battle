using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class tabela : MonoBehaviour
{

    private BancoDeDados bancoDeDados = new BancoDeDados();
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
    //


    //campo da alternativa 2:
        Image fundo_alternativa2;
        Text texto_alternativa2;
        Toggle toogle2;
        Image toggleImage2;
        Text toggleText2;
    //
 
    //campo da alternativa 3:
        Image fundo_alternativa3;
        Text texto_alternativa3;
        Toggle toogle3;
        Image toggleImage3;
        Text toggleText3;
    //

    //campo da alternativa 4:
        Image fundo_alternativa4;
        Text texto_alternativa4;
        Toggle toogle4;
        Image toggleImage4;
        Text toggleText4;
    //

    //campo da alternativa 5:
        Image fundo_alternativa5;
        Text texto_alternativa5;
        Toggle toogle5;
        Image toggleImage5;
        Text toggleText5;
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
    private int paginaTabela = 1;
    private int qtd_maxima_paginas;
    Dictionary<int, string> temas;
    private int inicio = 0;
    private int toggle_selecionado = -1;
    private string[] tema_nome;
    private int[] cod_tema; 


    public void set_PaginaTabela(int pag){
        paginaTabela = pag;
    }

    public int get_PaginaTabela(){
        return paginaTabela;
    }

    public void set_qtd_max_paginas(int qtd){
        qtd_maxima_paginas = qtd;
    }

    public int get_qtd_maxima_paginas(){
        return qtd_maxima_paginas;
    }

    public void set_inicio(int ini){
        inicio = ini;
    }

    public int get_inicio(){
        return inicio;
    }

    public void inicializarTabela(){
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
        
        
        
        paginaAtual = this.transform.Find("texto_pagina").GetComponent<Text>();
        paginaAtual.text = "";

        alterarAlt1(0, null, 0);
        alterarAlt2(0, null, 0);
        alterarAlt3(0, null, 0);
        alterarAlt4(0, null, 0);
        alterarAlt5(0, null, 0);
        temas = null;
    }

    void Start(){

        inicializarTabela();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void confirmar_tema(){

        if (toggle_selecionado == 1){
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela*5 - 5];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela*5 - 5]);
        }
        else if (toggle_selecionado == 2){
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela*5 - 4];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela*5 - 4]);
        }
        else if (toggle_selecionado == 3){
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela*5 - 3];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela*5 - 3]);
        }
        else if (toggle_selecionado == 4){
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela*5 - 2];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela*5 - 2]);
        }
        else if (toggle_selecionado == 5){
            GameObject.Find("tema_selecionado/nome_tema").GetComponent<Text>().text = tema_nome[paginaTabela*5 - 1];
            GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().set_tema(cod_tema[paginaTabela*5 - 1]);
        }

        GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().tirarPainelPesquisa();
    }


    public void preencherTemas(string tema){
        alterarBotaoConfirmarEscolha(1);

        if (inicio == 0){
            temas = bancoDeDados.pesquisarTemas(tema);
            inicio = 1;
        }


        Text semRetorno = this.transform.Find("sem_retorno_banco").GetComponent<Text>();
        semRetorno.text = "";
        RectTransform tamanhoTexto = semRetorno.GetComponent<RectTransform>();
        tamanhoTexto.sizeDelta = new Vector2(50, 81);



        fundo_tabela.color = new Color(147, 147, 147, 100);
        
        int qtd_temas = temas.Count;
        qtd_maxima_paginas = (int) Math.Ceiling(Decimal.Divide(qtd_temas, 5));

        paginaAtual.text = "Página: " + paginaTabela + "/" + Math.Ceiling(Decimal.Divide(qtd_temas, 5));

        if (qtd_maxima_paginas <= 1){
            alterarBotaoProxPagina(0);
            alterarBotaoPaginaAnterior(0);
        }else {
            alterarBotaoProxPagina(1);
            alterarBotaoPaginaAnterior(1);
        }

        paginaAtual.color = new Color(0, 0, 0, 1);
        int i = 0;

        //o trecho abaixo separa o dicionário contendo os temas em 2 vetores, um com o ID e o outro com o Nome
            tema_nome = new string[qtd_temas];
            cod_tema = new int[qtd_temas]; 

            foreach (KeyValuePair<int, string> item in temas){
                tema_nome[i] = item.Value;
                cod_tema[i] = item.Key;
                i++;
            }
        //
        
        for (i = paginaTabela*5 - 5; i < (paginaTabela*5); i++){
           
            if (i >= cod_tema.Length){
                break;
            }else{
                if (i == (paginaTabela*5 - 5) ){
                    alterarAlt1(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela*5 - 4) ){
                    alterarAlt2(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela*5 - 3) ){
                    alterarAlt3(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela*5 - 2) ){
                    alterarAlt4(1, tema_nome[i], cod_tema[i]);
                }
                else if (i == (paginaTabela*5 - 1) ){
                    alterarAlt5(1, tema_nome[i], cod_tema[i]);
                }
            }
        }

        if (i == (paginaTabela*5 - 4)){
            alterarAlt2(0, null, 0);
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }else if( i == (paginaTabela*5 - 3)){
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }else if (i == (paginaTabela*5 - 2)){
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
        }else if (i == (paginaTabela*5 - 1)){
            alterarAlt5(0, null, 0);
        }else if (i == (paginaTabela*5 - 5)){
            alterarBotaoConfirmarEscolha(0);
            alterarAlt1(0, null, 0);
            alterarAlt2(0, null, 0);
            alterarAlt3(0, null, 0);
            alterarAlt4(0, null, 0);
            alterarAlt5(0, null, 0);
            semRetorno.text = "Não foi encontrado nenhum resultado para a pesquisa";
            semRetorno.color = new Color(0, 0, 0, 1); 

            tamanhoTexto = semRetorno.GetComponent<RectTransform>();
            tamanhoTexto.sizeDelta = new Vector2(900, 81);

            paginaAtual.text = "";
            fundo_tabela.color = new Color(147, 147, 147, 0);
        }


    }

    private void alterarAlt1(int op, string nome_tema, int cod_tema){

        fundo_alternativa1 = this.transform.Find("alt_1").GetComponent<Image>();
        texto_alternativa1 = this.transform.Find("alt_1/Text").GetComponent<Text>();
        toogle1 = this.transform.Find("alt_1/Toggle").GetComponent<Toggle>();
        toggleText1 = this.transform.Find("alt_1/Toggle/Label").GetComponent<Text>();
        toggleImage1 = this.transform.Find("alt_1/Toggle/Background").GetComponent<Image>();

        if (op == 0){
    
            fundo_alternativa1.color = new Color(255, 255, 255, 0);
            texto_alternativa1.text = "";
            toogle1.isOn = false;
            toggleImage1.color = new Color(255, 255, 255, 0); 
            toggleText1.text = "";

        }
        
        else if (op == 1){
            
            
            fundo_alternativa1.color = new Color(255, 255, 255, 1);
            texto_alternativa1.text = nome_tema;
            toogle1.isOn = false;
            toggleImage1.color = new Color(255, 255, 255, 1);
            toggleText1.text = "Selecionar";

        }
        
    }

    private void alterarAlt2(int op, string nome_tema, int cod_tema){
        fundo_alternativa2 = this.transform.Find("alt_2").GetComponent<Image>();
        texto_alternativa2 = this.transform.Find("alt_2/Text").GetComponent<Text>();
        toogle2 = this.transform.Find("alt_2/Toggle").GetComponent<Toggle>();
        toggleImage2 = this.transform.Find("alt_2/Toggle/Background").GetComponent<Image>();
        toggleText2 = this.transform.Find("alt_2/Toggle/Label").GetComponent<Text>();


        if (op == 0){
            fundo_alternativa2.color = new Color(255, 255, 255, 0);
            texto_alternativa2.text = "";
            toogle2.isOn = false;
            toggleImage2.color = new Color(255, 255, 255, 0);
            toggleText2.text = "";
        }
        else if (op == 1){
            int codigo = cod_tema;

            fundo_alternativa2.color = new Color(255, 255, 255, 1);
            texto_alternativa2.text = nome_tema;
            toogle2.isOn = false;
            toggleImage2.color = new Color(255, 255, 255, 1);
            toggleText2.text = "Selecionar";

        }

    }

    private void alterarAlt3(int op, string nome_tema, int cod_tema){
        fundo_alternativa3 = this.transform.Find("alt_3").GetComponent<Image>();
        texto_alternativa3 = this.transform.Find("alt_3/Text").GetComponent<Text>();
        toogle3 = this.transform.Find("alt_3/Toggle").GetComponent<Toggle>();
        toggleImage3 = this.transform.Find("alt_3/Toggle/Background").GetComponent<Image>();
        toggleText3 = this.transform.Find("alt_3/Toggle/Label").GetComponent<Text>();
        
        if (op == 0){
            fundo_alternativa3.color = new Color(255, 255, 255, 0);
            texto_alternativa3.text = "";
            toogle3.isOn = false;
            toggleImage3.color = new Color(255, 255, 255, 0);
            toggleText3.text = "";
        }
        else if(op == 1){
            int codigo = cod_tema;

            fundo_alternativa3.color = new Color(255, 255, 255, 1);
            texto_alternativa3.text = nome_tema;
            toogle3.isOn = false;
            toggleImage3.color = new Color(255, 255, 255, 1);
            toggleText3.text = "Selecionar";
        }

        
    }

    private void alterarAlt4(int op, string nome_tema, int cod_tema){
        fundo_alternativa4 = this.transform.Find("alt_4").GetComponent<Image>();
        texto_alternativa4 = this.transform.Find("alt_4/Text").GetComponent<Text>();
        toogle4 = this.transform.Find("alt_4/Toggle").GetComponent<Toggle>();
        toggleImage4 = this.transform.Find("alt_4/Toggle/Background").GetComponent<Image>();
        toggleText4 = this.transform.Find("alt_4/Toggle/Label").GetComponent<Text>();
        
        if(op == 0){
            fundo_alternativa4.color = new Color(255, 255, 255, 0);
            texto_alternativa4.text = "";
            toogle4.isOn = false;
            toggleImage4.color = new Color(255, 255, 255, 0);
            toggleText4.text = "";
        }
        else if(op == 1){
            int codigo = cod_tema;

            fundo_alternativa4.color = new Color(255, 255, 255, 1);
            texto_alternativa4.text = nome_tema;
            toogle4.isOn = false;
            toggleImage4.color = new Color(255, 255, 255, 1);
            toggleText4.text = "Selecionar";
        }
            
    }

    private void alterarAlt5(int op, string nome_tema, int cod_tema){
        fundo_alternativa5 = this.transform.Find("alt_5").GetComponent<Image>();
        texto_alternativa5 = this.transform.Find("alt_5/Text").GetComponent<Text>();
        toogle5 = this.transform.Find("alt_5/Toggle").GetComponent<Toggle>();
        toggleImage5 = this.transform.Find("alt_5/Toggle/Background").GetComponent<Image>();
        toggleText5 = this.transform.Find("alt_5/Toggle/Label").GetComponent<Text>();
        

        if (op == 0){
            fundo_alternativa5.color = new Color(255, 255, 255, 0);
            texto_alternativa5.text = "";
            toogle5.isOn = false;
            toggleImage5.color = new Color(255, 255, 255, 0);
            toggleText5.text = "";
        }
        else if (op == 1){
            int codigo = cod_tema;

            fundo_alternativa5.color = new Color(255, 255, 255, 1);
            texto_alternativa5.text = nome_tema;
            toogle5.isOn = false;
            toggleImage5.color = new Color(255, 255, 255, 1);
            toggleText5.text = "Selecionar";
        }
    }


    private void alterarBotaoProxPagina(int op){
        proximaPagina = this.transform.Find("proxima_pagina/Text").GetComponent<Text>();    
        fundoProxPagina = this.transform.Find("proxima_pagina").GetComponent<Image>();
        
        if (op == 0){
            proximaPagina.text = "";
            fundoProxPagina.color = new Color(255, 255, 255, 0);
        }
        else if (op == 1){
            proximaPagina.text = "Próxima página";
            fundoProxPagina.color = new Color(255, 255, 255, 1);
        }
    }

    private void alterarBotaoPaginaAnterior(int op){
        paginaAnterior = this.transform.Find("pagina_anterior/Text").GetComponent<Text>();
        fundoPagAnterior = this.transform.Find("pagina_anterior").GetComponent<Image>();
        
        if (op == 0){
            paginaAnterior.text = "";
            fundoPagAnterior.color = new Color(255, 255, 255, 0);
        }else if (op == 1){
            paginaAnterior.text = "Página anterior";
            fundoPagAnterior.color = new Color(255, 255, 255, 1);
        }
        
    }

    private void alterarBotaoConfirmarEscolha(int op){
        confirmarEscolha = this.transform.Find("confirmar_selecao_tema/Text").GetComponent<Text>();
        fundoConfEscolha = this.transform.Find("confirmar_selecao_tema").GetComponent<Image>();

        if (op == 0){
            confirmarEscolha.text = "";
            fundoConfEscolha.color = new Color(255, 255, 255, 0);
        }else if(op == 1){
            confirmarEscolha.text = "Confirmar";
            fundoConfEscolha.color = new Color(255, 255, 255, 1);
        }
        
    }

    public void statusToggle1(int op){
        if (op == 1){
            toggle_selecionado = 1;
            statusToggle2(0);
            statusToggle3(0);
            statusToggle4(0);
            statusToggle5(0);
        }else if (op == 0){
            this.transform.Find("alt_1/Toggle").GetComponent<Toggle>().isOn = false;
        }  
    }

    public void statusToggle2(int op){
        if (op == 1){
            toggle_selecionado = 2;
            statusToggle1(0);
            statusToggle3(0);
            statusToggle4(0);
            statusToggle5(0);
        }else if (op == 0){
            this.transform.Find("alt_2/Toggle").GetComponent<Toggle>().isOn = false;
        }
    }

    public void statusToggle3(int op){
        if (op == 1){
            toggle_selecionado = 3;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle4(0);
            statusToggle5(0);
        }else if (op == 0){
            this.transform.Find("alt_3/Toggle").GetComponent<Toggle>().isOn = false;
        }  
    }

    public void statusToggle4(int op){
        if (op == 1){
            toggle_selecionado = 4;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle3(0);
            statusToggle5(0);
        }else if (op == 0){
            this.transform.Find("alt_4/Toggle").GetComponent<Toggle>().isOn = false;
        }  
    }

    public void statusToggle5(int op){
        if (op == 1){
            toggle_selecionado = 5;
            statusToggle1(0);
            statusToggle2(0);
            statusToggle3(0);
            statusToggle4(0);
        }else if (op == 0){
            this.transform.Find("alt_5/Toggle").GetComponent<Toggle>().isOn = false;
        }  
    }

}
