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
  public Button resp_correta1;

  public InputField input2;
  public Text placeholder2;
  public Text texto_usuario2;
  public Button resp_correta2;

  public InputField input3;
  public Text placeholder3;
  public Text texto_usuario3;
  public Button resp_correta3;

  public InputField input4;
  public Text placeholder4;
  public Text texto_usuario4;
  public Button resp_correta4;

  private Color color = Color.black;

  void Start (){
    resp_correta1.onClick.AddListener(verificaBotao);
    resp_correta2.onClick.AddListener(verificaBotao);
    resp_correta3.onClick.AddListener(verificaBotao);
    resp_correta4.onClick.AddListener(verificaBotao);




    Valor_slider = GetComponent<Text>();
    Valor_slider.text = "Quantidade de alternativas: 0";
    color.a = 0;

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


  public void inserirPergunta(){

    bancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4);
  
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
      }

      //input ativo
      if (op == 1){ 
        placeholder1.text = "Alternativa 1";
        input1.interactable = true;
        texto_usuario1.color = Color.black;
        resp_correta1.interactable = true;
        resp_correta1.GetComponentInChildren<Text>().color = Color.black; 
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
      }

      //input ativo

      if (op == 1){
        placeholder2.text = "Alternativa 2";
        input2.interactable = true;
        texto_usuario2.color = Color.black;
        resp_correta2.interactable = true;
        resp_correta2.GetComponentInChildren<Text>().color = Color.black;
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
      }

      //input ativo

      if (op == 1){
        placeholder3.text = "Alternativa 3";
        input3.interactable = true;
        texto_usuario3.color = Color.black;
        resp_correta3.interactable = true;
        resp_correta3.GetComponentInChildren<Text>().color = Color.black;
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
      }

      //input ativo

      if (op == 1){
        placeholder4.text = "Alternativa 4";
        input4.interactable = true;
        texto_usuario4.color = Color.black;
        resp_correta4.interactable = true;
        resp_correta4.GetComponentInChildren<Text>().color = Color.black;
      }
  }


  public void verificaBotao(){
    
  }



}