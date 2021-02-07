using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;



public class apresentarPergunta : MonoBehaviour
{

    private BancoDeDados bancoDeDados = new BancoDeDados();
    private List<int> id_pergunta;
    private List<int> id_tema;
    private List<string> texto_pergunta;
    private List<string> alternativas;
    private int pergAtual = 0;


    public void set_id_pergunta(List<int> id_perg){

        id_pergunta = id_perg;
    }

    public void set_id_tema(List<int> id_tem){
        
        id_tema = id_tem;
    }

    public void set_texto_pergunta(List<string> text_pergunta){

        texto_pergunta = text_pergunta;
    }

    public void set_alternativas(List<string> alternatvs){
        
        alternativas = alternatvs;
    }


    Text textoPergunta;
    Text textoAlt1;
    Text textoAlt2;
    Text textoAlt3;
    Text textoAlt4;

    Image fundoAlt1; 
    Image fundoAlt2;   
    Image fundoAlt3;  
    Image fundoAlt4;


    string[] alternativasAtuais;

    // Start is called before the first frame update
    void Start()
    {

        textoPergunta = this.transform.Find("texto_pergunta").GetComponent<Text>();
        textoAlt1 = this.transform.Find("alt1/Text").GetComponent<Text>();
        textoAlt2 = this.transform.Find("alt2/Text").GetComponent<Text>();
        textoAlt3 = this.transform.Find("alt3/Text").GetComponent<Text>();
        textoAlt4 = this.transform.Find("alt4/Text").GetComponent<Text>();

        textoAlt1.text = "";
        textoAlt2.text = "";
        textoAlt3.text = "";
        textoAlt4.text = "";
    
        fundoAlt1 = this.transform.Find("alt1").GetComponent<Image>();
        fundoAlt2 = this.transform.Find("alt2").GetComponent<Image>();
        fundoAlt3 = this.transform.Find("alt3").GetComponent<Image>();
        fundoAlt4 = this.transform.Find("alt4").GetComponent<Image>();

        fundoAlt1.color = new Color(255, 255, 255, 0);
        fundoAlt2.color = new Color(255, 255, 255, 0);       
        fundoAlt3.color = new Color(255, 255, 255, 0);
        fundoAlt4.color = new Color(255, 255, 255, 0);


        bancoDeDados.retornarPerguntasDeUmTema(19);
        mostrarPergunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void mostrarPergunta(){
        textoPergunta.text = texto_pergunta[pergAtual];

        Debug.Log(alternativas[pergAtual]);

        separarAlternativas(alternativas[pergAtual]);

        if (alternativasAtuais.Length == 0 || alternativasAtuais.Length == 1){
            textoAlt1.text = "";
            textoAlt2.text = "";
            textoAlt3.text = "";
            textoAlt4.text = "";
            
            fundoAlt1.color = new Color(255, 255, 255, 0);           
            fundoAlt2.color = new Color(255, 255, 255, 0);                      
            fundoAlt3.color = new Color(255, 255, 255, 0);           
            fundoAlt4.color = new Color(255, 255, 255, 0);
        }
        else if (alternativasAtuais.Length == 2){
            
            //testando pra mostrar as alternativas!!
                textoAlt1.text = alternativasAtuais[0];
                textoAlt2.text = alternativasAtuais[1];

                fundoAlt1.color = new Color(255, 255, 255, 1);           
                fundoAlt2.color = new Color(255, 255, 255, 1);   

            //

            textoAlt3.text = "";
            textoAlt4.text = "";
            fundoAlt3.color = new Color(255, 255, 255, 0);           
            fundoAlt4.color = new Color(255, 255, 255, 0);
        }
        else if (alternativasAtuais.Length == 3){
            //testando pra mostrar as alternativas!!
                textoAlt1.text = alternativasAtuais[0];
                textoAlt2.text = alternativasAtuais[1];
                textoAlt3.text = alternativasAtuais[2];


                fundoAlt1.color = new Color(255, 255, 255, 1);           
                fundoAlt2.color = new Color(255, 255, 255, 1);   
                fundoAlt3.color = new Color(255, 255, 255, 1);
            //

            
            textoAlt4.text = "";
            fundoAlt4.color = new Color(255, 255, 255, 0);
        }
        else if (alternativasAtuais.Length == 4){
            //testando pra mostrar as alternativas!!
                textoAlt1.text = alternativasAtuais[0];
                textoAlt2.text = alternativasAtuais[1];
                textoAlt3.text = alternativasAtuais[2];
                textoAlt4.text = alternativasAtuais[3];


                fundoAlt1.color = new Color(255, 255, 255, 1);           
                fundoAlt2.color = new Color(255, 255, 255, 1);   
                fundoAlt3.color = new Color(255, 255, 255, 1);
                fundoAlt4.color = new Color(255, 255, 255, 1);
            //
        }

    }

    public void separarAlternativas(string alternativs){

       
        string[] aux = alternativs.Split(new [] { "/--/" }, StringSplitOptions.None);


        alternativasAtuais = new string[aux.Length];
        for (int i = 0; i < aux.Length; i++){
            Debug.Log(aux[i]);
            alternativasAtuais[i] = aux[i];
        }
        


    }



}
