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
    private int qtsCorretas = 0;

    private float tempoMaximo;
    

    Text textoPergunta;
    Text textoAlt1;
    Text textoAlt2;
    Text textoAlt3;
    Text textoAlt4;
    Text textoAcertoSemAlternativa;
    Text textoErroSemAlternativa;


    Image fundoAlt1; 
    Image fundoAlt2;   
    Image fundoAlt3;  
    Image fundoAlt4;
    Image fundoAcertoSemAlternativa;
    Image fundoErroSemAlternativa;


    Button AcertoSemAlternativa;
    Button ErroSemAlternativa;


    private string[] alternativasAtuais;
    private int altCorreta1 = -1;
    private int altCorreta2 = -1;
    private int altCorreta3 = -1;
    private int altCorreta4 = -1;


    public void setTempoMaximo(float tempoMaxNovo){
        tempoMaximo = tempoMaxNovo;
    }

    public float getTempoMaximo(){
        return tempoMaximo;
    }

    public int getAltCorreta1(){
        return altCorreta1;
    }

    public int getAltCorreta2(){
        return altCorreta2;
    }
    
    public int getAltCorreta3(){
        return altCorreta3;
    }

    public int getAltCorreta4(){
        return altCorreta4;
    }

    public void remover_textoAlternativas(int[] alternativas){

        for (int i = 0; i < alternativas.Length; i++){
            if (alternativas[i] > 0){
                Text textAux = this.transform.Find("alt" + alternativas[i] + "/Text").GetComponent<Text>();
                textAux.text = "";

                Image imageAux = this.transform.Find("alt" + alternativas[i]).GetComponent<Image>();
                imageAux.color = new Color(255, 255, 255, 0);
            }
            
        }

    }


    public void set_id_pergunta(List<int> id_perg){

        id_pergunta = id_perg;
    }

    public void set_id_tema2(List<int> id){
        id_tema = id;
    }

    public void set_id_tema(int id_tem){
        bancoDeDados.retornarPerguntasDeUmTema(id_tem);
        mostrarPergunta();
    }

    public void set_texto_pergunta(List<string> text_pergunta){

        texto_pergunta = text_pergunta;
    }

    public void set_alternativas(List<string> alternatvs){
        
        alternativas = alternatvs;
    }

    public string[] getAlternativasAtuais(){
        return alternativasAtuais;
    }

    public int get_qtsCorretas(){
        return qtsCorretas;
    }


    // Start is called before the first frame update
    void Start()
    {

        //atribuindo e inicializando os componentes do painel de apresentar as perguntas

        this.transform.Find("tempo").GetComponent<Text>().text = "Tempo restante: " + (int)tempoMaximo;


        textoPergunta = this.transform.Find("texto_pergunta").GetComponent<Text>();
        textoAlt1 = this.transform.Find("alt1/Text").GetComponent<Text>();
        textoAlt2 = this.transform.Find("alt2/Text").GetComponent<Text>();
        textoAlt3 = this.transform.Find("alt3/Text").GetComponent<Text>();
        textoAlt4 = this.transform.Find("alt4/Text").GetComponent<Text>();
        textoAcertoSemAlternativa = this.transform.Find("AcertoSemAlternativa/Text").GetComponent<Text>();
        textoErroSemAlternativa = this.transform.Find("ErroSemAlternativa/Text").GetComponent<Text>();

        textoAlt1.text = "";
        textoAlt2.text = "";
        textoAlt3.text = "";
        textoAlt4.text = "";
        textoAcertoSemAlternativa.text = "";
        textoErroSemAlternativa.text = "";


        fundoAlt1 = this.transform.Find("alt1").GetComponent<Image>();
        fundoAlt2 = this.transform.Find("alt2").GetComponent<Image>();
        fundoAlt3 = this.transform.Find("alt3").GetComponent<Image>();
        fundoAlt4 = this.transform.Find("alt4").GetComponent<Image>();

        fundoAlt1.color = new Color(255, 255, 255, 0);
        fundoAlt2.color = new Color(255, 255, 255, 0);       
        fundoAlt3.color = new Color(255, 255, 255, 0);
        fundoAlt4.color = new Color(255, 255, 255, 0);

        fundoAcertoSemAlternativa = this.transform.Find("AcertoSemAlternativa").GetComponent<Image>();
        fundoErroSemAlternativa = this.transform.Find("ErroSemAlternativa").GetComponent<Image>();

        fundoAcertoSemAlternativa.color = new Color(255, 255, 255, 0);
        fundoErroSemAlternativa.color = new Color(255, 255, 255, 0);

        AcertoSemAlternativa = this.transform.Find("AcertoSemAlternativa").GetComponent<Button>();
        ErroSemAlternativa = this.transform.Find("ErroSemAlternativa").GetComponent<Button>();

        AcertoSemAlternativa.interactable = false;
        ErroSemAlternativa.interactable = false;

        
    }

// Update is called once per frame
    void Update()
    {
        if (this.transform.position == GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1)){
            
            if (tempoMaximo > 1){
                tempoMaximo -= Time.deltaTime;
                
            this.transform.Find("tempo").GetComponent<Text>().text = "Tempo restante: " + (int)tempoMaximo;
            }else{
                usuarioRespondeu(10);
            }
        }
        
    }



    private void reiniciarComponentes(){
        textoAlt1.text = "";
        textoAlt2.text = "";
        textoAlt3.text = "";
        textoAlt4.text = "";
        textoAcertoSemAlternativa.text = "";
        textoErroSemAlternativa.text = "";

        fundoAlt1.color = new Color(255, 255, 255, 0);
        fundoAlt2.color = new Color(255, 255, 255, 0);       
        fundoAlt3.color = new Color(255, 255, 255, 0);
        fundoAlt4.color = new Color(255, 255, 255, 0);

        fundoAcertoSemAlternativa.color = new Color(255, 255, 255, 0);
        fundoErroSemAlternativa.color = new Color(255, 255, 255, 0);

        AcertoSemAlternativa.interactable = false;
        ErroSemAlternativa.interactable = false;
        tempoMaximo = GameObject.Find("config_jogo/quantia_tempo_slider").GetComponent<Slider>().value+1;

        
        qtsCorretas = 0;
        altCorreta1 = -1;
        altCorreta2 = -1;
        altCorreta3 = -1;
        altCorreta4 = -1;
        GameObject.Find("powerups").transform.position = this.transform.position + new Vector3(0, 3000, 0);
        GameObject.Find("powerups").GetComponent<gerenciarPowerUps>().zerarPws();
    }


    


    public void usuarioRespondeu(int altEscolhida){
        if (altEscolhida == altCorreta1 || altEscolhida == altCorreta2 || altEscolhida == altCorreta3 || altEscolhida == altCorreta4){
            popUp_pergunta.mostrarPopUp(1);
            GameObject.Find("rolarDado").GetComponent<mostrarDado>().mover(1);
        }else{
            popUp_pergunta.mostrarPopUp(0);
            pergAtual++;

            GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>().aumentarJogadorAtual();
            GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>().passarVez();
        }

        this.transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 0);

        pergAtual++;

        if (pergAtual == id_pergunta.Count){
            pergAtual = 0;
        }

        GameObject.Find("Players").GetComponent<MvP1>().atualizarHudPlayerAtual();
        reiniciarComponentes();
        mostrarPergunta();
        
    }

    private void zerarAlternativas(){
        textoAlt1.text = "";
        textoAlt2.text = "";
        textoAlt3.text = "";
        textoAlt4.text = "";
        textoAcertoSemAlternativa.text = "";
        textoErroSemAlternativa.text = "";

        fundoAlt1.color = new Color(255, 255, 255, 0);
        fundoAlt2.color = new Color(255, 255, 255, 0);       
        fundoAlt3.color = new Color(255, 255, 255, 0);
        fundoAlt4.color = new Color(255, 255, 255, 0);

        fundoAcertoSemAlternativa.color = new Color(255, 255, 255, 0);
        fundoErroSemAlternativa.color = new Color(255, 255, 255, 0);

        AcertoSemAlternativa.interactable = false;
        ErroSemAlternativa.interactable = false;
        tempoMaximo = GameObject.Find("config_jogo/quantia_tempo_slider").GetComponent<Slider>().value+1;
    }


    public void mostrarPergunta(){
        zerarAlternativas();
        if (texto_pergunta[pergAtual] != null)
            textoPergunta.text = texto_pergunta[pergAtual];
        else{
            textoPergunta.text = texto_pergunta[0];
            pergAtual = 0;
        }
            
        Debug.Log(alternativas[pergAtual]);

        manusearAlternativas(alternativas[pergAtual]);

        if (alternativasAtuais.Length == 0 || alternativasAtuais.Length == 1){
            AcertoSemAlternativa.interactable = true;
            ErroSemAlternativa.interactable = true;

            fundoAcertoSemAlternativa.color = new Color(255, 255, 255, 1);
            fundoErroSemAlternativa.color = new Color(255, 255, 255, 1);


            textoAcertoSemAlternativa.text = "Acertou";
            textoErroSemAlternativa.text = "Errou";

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

    public void manusearAlternativas(string alternativs){
       
        string[] aux = alternativs.Split(new [] { "/--/" }, StringSplitOptions.None);


        alternativasAtuais = new string[aux.Length];
        for (int i = 0; i < aux.Length; i++){
            //Debug.Log(aux[i]);
            alternativasAtuais[i] = aux[i];
        }
        
        string tempGO;

        for (int i = 0; i < alternativasAtuais.Length; i++){
            int rnd = UnityEngine.Random.Range(i, alternativasAtuais.Length);
            tempGO = alternativasAtuais[rnd];
            alternativasAtuais[rnd] = alternativasAtuais[i];
            alternativasAtuais[i] = tempGO;


            //vê qual alternativa é correta e armazena a posição dela pra comparar com a escolha do usuário
            //caso exista mais de 1 correta, as posições das demais também são armazenadas

            if (alternativasAtuais[i].Contains("¢") && qtsCorretas == 0){
                qtsCorretas++;
                alternativasAtuais[i] = alternativasAtuais[i].Remove(alternativasAtuais[i].Length-1);
                altCorreta1 = i+1;
                Debug.Log("A alternativa 1 correta é " + alternativasAtuais[i] +", e o índice é " + altCorreta1);

            }else if (alternativasAtuais[i].Contains("¢") && qtsCorretas == 1){
                qtsCorretas++;
                alternativasAtuais[i] = alternativasAtuais[i].Remove(alternativasAtuais[i].Length-1);
                altCorreta2 = i+1;
                Debug.Log("A alternativa 2 correta é " + alternativasAtuais[i] +", e o índice é " + altCorreta2);
            }else if (alternativasAtuais[i].Contains("¢") && qtsCorretas == 2){
                qtsCorretas++;
                alternativasAtuais[i] = alternativasAtuais[i].Remove(alternativasAtuais[i].Length-1);
                altCorreta3 = i+1;
                Debug.Log("A alternativa 3 correta é " + alternativasAtuais[i] +", e o índice é " + altCorreta3);
            }else if (alternativasAtuais[i].Contains("¢") && qtsCorretas == 3){
                qtsCorretas++;
                alternativasAtuais[i] = alternativasAtuais[i].Remove(alternativasAtuais[i].Length-1);
                altCorreta4 = i+1;
                Debug.Log("A alternativa 4 correta é " + alternativasAtuais[i] +", e o índice é " + altCorreta4);
            }
        }


    }



}
