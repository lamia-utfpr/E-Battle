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

  
  public Text sem_alternativacorreta;
  public Button sem_alternativacorretaNAO;
  public Button sem_alternativacorretaSIM; 
  

  private Color color = Color.black;
  private Color cor_checkbox = Color.white;

  private int qtd_alternativas = 0;

  public  Toggle getResp_Correta1(){
    return resp_correta1;
  }

  public Toggle getResp_Correta2(){
    return resp_correta2;
  }

  public Toggle getResp_Correta3(){
    return resp_correta3;
  }

  public Toggle getResp_Correta4(){
    return resp_correta4;
  }

  void Start (){
    Valor_slider = GetComponent<Text>();
    Valor_slider.text = "Quantidade de alternativas: 0";
    color.a = 0;


    sem_alternativacorreta.color = Color.black;
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);


    statusInput1(0);
    statusInput2(0);
    statusInput3(0);
    statusInput4(0);
    
  }

  public void ShowSliderValue () {
    string sliderMessage = "Quantidade de alternativas: "+ sliderUI.value;
    Valor_slider.text = sliderMessage;
    setActive(sliderUI.value);
    
    
  }

  void update(){
    ShowSliderValue();
    
  }


  public void inserirPerguntasemAlternativaCorreta(){
    int[] respostas = new int[4];
    respostas = verificaBotao();
    bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas);

    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);
  }


  public void naoInserirPerguntaSemAlternativaCorreta(){
    sem_alternativacorreta.text = "";
    sem_alternativacorretaSIM.gameObject.SetActive(false);
    sem_alternativacorretaNAO.gameObject.SetActive(false);
  }

  public void inserirPergunta(){
    int[] respostas = new int[4];
    respostas = verificaBotao();
    qtd_alternativas = (int) sliderUI.value;

    if(
      (qtd_alternativas == 1 && respostas[0] == 0) || 
      (qtd_alternativas == 2 && respostas[0] == 0 && respostas[1] == 0) ||
      (qtd_alternativas == 3 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0) ||
      (qtd_alternativas == 4 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0 && respostas[3] == 0)
    ){
  
      sem_alternativacorreta.text = "Tem certeza que deseja adicionar uma pergunta sem alternativa correta?";
      sem_alternativacorretaSIM.gameObject.SetActive(true);
      sem_alternativacorretaNAO.gameObject.SetActive(true);
  
    }else{
      bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas);  
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

    int[] respostas = new int[4];

    if (resp_correta1.isOn){
      respostas[0] = 1; 
    }else
    {
      respostas[0] = 0;
    }

    if (resp_correta2.isOn){
      respostas[1] = 1; 
    }else
    {
      respostas[1] = 0;
    }

    if (resp_correta3.isOn){
      respostas[2] = 1; 
    }else
    {
      respostas[2] = 0;
    }

    if (resp_correta4.isOn){
      respostas[3] = 1; 
    }else
    {
      respostas[3] = 0;
    }


    return respostas;
  }



}