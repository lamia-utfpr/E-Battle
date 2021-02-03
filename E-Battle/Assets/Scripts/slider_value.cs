using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class slider_value : MonoBehaviour {

  private BancoDeDados bancoDeDados = new BancoDeDados();


  public Slider sliderUI;
  private Text Valor_slider;
  
  public InputField pergunta;

  public InputField input1;
  public Text placeholder1;
  public Text texto_usuario1;
  public Toggle resp_correta1;

  public InputField input2;
  public Text placeholder2;
  public Text texto_usuario2;
  public Toggle resp_correta2;

  public InputField input3;
  public Text placeholder3;
  public Text texto_usuario3;
  public Toggle resp_correta3;

  public InputField input4;
  public Text placeholder4;
  public Text texto_usuario4;
  public Toggle resp_correta4;

  //parte sobre não ter alternativa correta
  public Text sem_alternativacorreta;
  public Button sem_alternativacorretaNAO;
  public Button sem_alternativacorretaSIM; 
  

  //parte sobre todas serem corretas
  public Text todas_alternativassaocorretas;
  public Button todas_alternativassaocorretasNAO;
  public Button todas_alternativassaocorretasSIM; 
  

  //texto que aparece caso a pergunta esteja vazia
  public Text perguntaVazia;

  //texto que aparece confirmando a inserção da pergunta
  public Text perguntaInserida;

  //nome do tema selecionado
  Text nomeTemaSelecionado;

  private Color color = Color.black;
  private Color cor_checkbox = Color.white;

  private int qtd_alternativas = 0;
  private int qtd_certas;

  void Start (){
    Valor_slider = GetComponent<Text>();
    Valor_slider.text = "Quantidade de alternativas: 0";
    color.a = 0;


    sem_alternativacorreta.color = Color.black;
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);

    todas_alternativassaocorretas.color = Color.black;
    todas_alternativassaocorretas.text = "";
    todas_alternativassaocorretasSIM.gameObject.SetActive(false);
    todas_alternativassaocorretasNAO.gameObject.SetActive(false);

    Text tema_vazio = GameObject.Find("tema_selecionado/tema_nao_selecionado").GetComponent<Text>();
    tema_vazio.text = "";


//    nomeTemaSelecionado = this.transform.Find("tema_selecionado/nome_tema").GetComponent<Text>();

    perguntaVazia.color = Color.black;
    perguntaVazia.text = "";

    perguntaInserida.text = "";

    statusInput1(0);
    statusInput2(0);
    statusInput3(0);
    statusInput4(0);
    
  }

  public void ShowSliderValue () {
    string sliderMessage = "Quantidade de alternativas: "+ sliderUI.value;
    Valor_slider.text = sliderMessage;
    setActive(sliderUI.value);
    todas_alternativassaocorretas.text = "";
    todas_alternativassaocorretasSIM.gameObject.SetActive(false);
    todas_alternativassaocorretasNAO.gameObject.SetActive(false);
    
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);


    perguntaInserida.text = "";
  }

  void update(){
    ShowSliderValue();
    
  }

  public void inserirPerguntaComTodasCorretas(){
    int[] respostas = new int[4];
    respostas = verificaBotao();
    
    int cod_tema = GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().get_tema();

    if (cod_tema > 0){
          bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);
    }
    else{
        Text tema_vazio = GameObject.Find("tema_selecionado/tema_nao_selecionado").GetComponent<Text>();
        tema_vazio.text = "Selecione um tema para inserir a pergunta!";
        tema_vazio.color = new Color(0, 0, 0, 1);
    }

    todas_alternativassaocorretas.text = "";
    todas_alternativassaocorretasSIM.gameObject.SetActive(false);
    todas_alternativassaocorretasNAO.gameObject.SetActive(false);

    perguntaInserida.text = "Pergunta inserida com sucesso!";
  }


  public void NaoInserirPerguntaComTodasCorretas(){
    todas_alternativassaocorretas.text = "";
    todas_alternativassaocorretasSIM.gameObject.SetActive(false);
    todas_alternativassaocorretasNAO.gameObject.SetActive(false);
  }

  public void inserirPerguntaSemAlternativaCorreta(){
    int[] respostas = new int[4];
    respostas = verificaBotao();
    
    int cod_tema = GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().get_tema();

    if (cod_tema > 0){
          bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);
        }
    else{
          Text tema_vazio = GameObject.Find("tema_selecionado/tema_nao_selecionado").GetComponent<Text>();
          tema_vazio.text = "Selecione um tema para inserir a pergunta!";
          tema_vazio.color = new Color(0, 0, 0, 1);
    }

    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);

    perguntaInserida.text = "Pergunta inserida com sucesso!";

  }


  public void naoInserirPerguntaSemAlternativaCorreta(){
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);
  }

  public void inserirPergunta(){
    sem_alternativacorreta.color = Color.black;
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);

    todas_alternativassaocorretas.color = Color.black;
    todas_alternativassaocorretas.text = "";
    todas_alternativassaocorretasSIM.gameObject.SetActive(false);
    todas_alternativassaocorretasNAO.gameObject.SetActive(false);

    int[] respostas = new int[4];
    respostas = verificaBotao();
    qtd_alternativas = (int) sliderUI.value;

    if (String.IsNullOrWhiteSpace(pergunta.text)){    //verifica se a pergunta está vazia
      perguntaVazia.color = Color.red;
      perguntaVazia.text = "Pergunta vazia, insira algo!";
    }
    
    else{

      perguntaVazia.text = "";

      if (qtd_alternativas == qtd_certas && qtd_certas > 1){
        todas_alternativassaocorretas.text = "Tem certeza que todas as alternativas são corretas?";
        todas_alternativassaocorretasSIM.gameObject.SetActive(true);
        todas_alternativassaocorretasNAO.gameObject.SetActive(true);
      }
      else if(
        (qtd_alternativas == 1 && respostas[0] == 0) || 
        (qtd_alternativas == 2 && respostas[0] == 0 && respostas[1] == 0) ||
        (qtd_alternativas == 3 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0) ||
        (qtd_alternativas == 4 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0 && respostas[3] == 0)
      ){
    
        sem_alternativacorreta.text = "Tem certeza que deseja adicionar uma pergunta sem alternativa correta?";
        sem_alternativacorretaSIM.gameObject.SetActive(true);
        sem_alternativacorretaNAO.gameObject.SetActive(true);
    
      }else{
        int cod_tema = GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().get_tema();
        
        if (cod_tema > 0){
          bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);
          perguntaInserida.color = Color.black;
          perguntaInserida.text = "Pergunta inserida com sucesso!";
        }
        else{
          Text tema_vazio = GameObject.Find("tema_selecionado/tema_nao_selecionado").GetComponent<Text>();
          tema_vazio.text = "Selecione um tema para inserir a pergunta!";
          tema_vazio.color = new Color(0, 0, 0, 1);
        }
        

      }

    }
    
  
  }


  void setActive(float valor_slider){

      switch((int) valor_slider){
        case 0:
          statusInput1(0);
          statusInput2(0);
          statusInput3(0);
          statusInput4(0);
          break;

        case 1:
          statusInput1(1);
          statusInput2(0);
          statusInput3(0);
          statusInput4(0);
          break;

        case 2:
          statusInput1(1);
          statusInput2(1);
          statusInput3(0);
          statusInput4(0);
          break;

        case 3:
          statusInput1(1);
          statusInput2(1);
          statusInput3(1);
          statusInput4(0);
          break;
        
        case 4:
          
          statusInput1(1);
          statusInput2(1);
          statusInput3(1);
          statusInput4(1);
          break;
      }
  }


  private void statusInput1(int op){

      //input inativo
      if (op == 0){
        placeholder1.text = "";
        input1.interactable = false;
        texto_usuario1.color = color;
        resp_correta1.interactable = false;
        resp_correta1.GetComponentInChildren<Text>().color = color; 
        resp_correta1.GetComponentInChildren<Image>().color = color;
        resp_correta1.isOn = false;
      }

      //input ativo
      if (op == 1){ 
        placeholder1.text = "Alternativa 1";
        input1.interactable = true;
        texto_usuario1.color = Color.black;
        resp_correta1.interactable = true;
        resp_correta1.GetComponentInChildren<Text>().color = Color.black; 
        resp_correta1.GetComponentInChildren<Image>().color = cor_checkbox;
      }
  }

  private void statusInput2(int op){

            //input inativo

      if (op == 0){
        placeholder2.text = "";
        input2.interactable = false;
        texto_usuario2.color = color;
        resp_correta2.interactable = false;
        resp_correta2.GetComponentInChildren<Text>().color = color; 
        resp_correta2.GetComponentInChildren<Image>().color = color;
        resp_correta2.isOn = false;
      }

      //input ativo

      if (op == 1){
        placeholder2.text = "Alternativa 2";
        input2.interactable = true;
        texto_usuario2.color = Color.black;
        resp_correta2.interactable = true;
        resp_correta2.GetComponentInChildren<Text>().color = Color.black;
        resp_correta2.GetComponentInChildren<Image>().color = cor_checkbox;
      }
  }

  private void statusInput3(int op){
      //input inativo

      if (op == 0){
        placeholder3.text = "";
        input3.interactable = false;
        texto_usuario3.color = color;
        resp_correta3.interactable = false;
        resp_correta3.GetComponentInChildren<Text>().color = color;
        resp_correta3.GetComponentInChildren<Image>().color = color;
        resp_correta3.isOn = false;
      }

      //input ativo

      if (op == 1){
        placeholder3.text = "Alternativa 3";
        input3.interactable = true;
        texto_usuario3.color = Color.black;
        resp_correta3.interactable = true;
        resp_correta3.GetComponentInChildren<Text>().color = Color.black;         
        resp_correta3.GetComponentInChildren<Image>().color = cor_checkbox;
      }
  }

  private void statusInput4(int op){
      //input inativo

      if (op == 0){
        placeholder4.text = "";
        input4.interactable = false;
        texto_usuario4.color = color;
        resp_correta4.interactable = false;
        resp_correta4.GetComponentInChildren<Text>().color = color;
        resp_correta4.GetComponentInChildren<Image>().color = color;
        resp_correta4.isOn = false;
      }

      //input ativo

      if (op == 1){
        placeholder4.text = "Alternativa 4";
        input4.interactable = true;
        texto_usuario4.color = Color.black;
        resp_correta4.interactable = true;
        resp_correta4.GetComponentInChildren<Text>().color = Color.black; 
        resp_correta4.GetComponentInChildren<Image>().color = cor_checkbox;
      }
  }


  public int [] verificaBotao(){
    qtd_certas = 0;
    int[] respostas = new int[4];

    if (resp_correta1.isOn){
      respostas[0] = 1; 
      qtd_certas++;
    }else
    {
      respostas[0] = 0;
    }

    if (resp_correta2.isOn){
      respostas[1] = 1; 
      qtd_certas++;
    }else
    {
      respostas[1] = 0;
    }

    if (resp_correta3.isOn){
      respostas[2] = 1;
      qtd_certas++; 
    }else
    {
      respostas[2] = 0;
    }

    if (resp_correta4.isOn){
      respostas[3] = 1;
      qtd_certas++; 
    }else
    {
      respostas[3] = 0;
    }


    return respostas;
  }



}