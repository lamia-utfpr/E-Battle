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
    int paginaTabela = 1;

    void Start(){

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
        proximaPagina = this.transform.Find("proxima_pagina/Text").GetComponent<Text>();
        proximaPagina.text = "";

        fundoProxPagina = this.transform.Find("proxima_pagina").GetComponent<Image>();
        fundoProxPagina.color = new Color(255, 255, 255, 0);

        paginaAnterior = this.transform.Find("pagina_anterior/Text").GetComponent<Text>();
        paginaAnterior.text = "";

        fundoPagAnterior = this.transform.Find("pagina_anterior").GetComponent<Image>();
        fundoPagAnterior.color = new Color(255, 255, 255, 0);
        
        confirmarEscolha = this.transform.Find("confirmar_selecao_tema/Text").GetComponent<Text>();
        confirmarEscolha.text = "";

        fundoConfEscolha = this.transform.Find("confirmar_selecao_tema").GetComponent<Image>();
        fundoConfEscolha.color = new Color(255, 255, 255, 0);
        
        paginaAtual = this.transform.Find("texto_pagina").GetComponent<Text>();
        paginaAtual.text = "";

        alterarAlt1(0, null, 0);
        alterarAlt2(0, null, 0);
        alterarAlt3(0, null, 0);
        alterarAlt4(0, null, 0);
        alterarAlt5(0, null, 0);
    }

    // Update is called once per frame
    void Update(){
        
    }


    public void preencherTemas(string tema){
        paginaAtual.text = "Página: " + paginaTabela;
        Dictionary<int, string> temas = bancoDeDados.pesquisarTemas(tema);

        Debug.Log(tema);

        int qtd_temas = temas.Count;
        int i = 0;

        //o trecho abaixo separa o dicionário contendo os temas em 2 vetores, um com o ID e o outro com o Nome
            string[] tema_nome = new string[qtd_temas];
            int[] cod_tema = new int[qtd_temas]; 

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
            int codigo = cod_tema;
            
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

}
