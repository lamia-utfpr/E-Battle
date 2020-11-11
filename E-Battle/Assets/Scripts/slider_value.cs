using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class slider_value : MonoBehaviour {

  public Slider sliderUI;
  private Text Valor_slider;
  
  public InputField input1;
  public Text placeholder1;
  public Text texto_usuario1;

  public InputField input2;
  public Text placeholder2;
  public Text texto_usuario2;

  public InputField input3;
  public Text placeholder3;
  public Text texto_usuario3;

  public InputField input4;
  public Text placeholder4;
  public Text texto_usuario4;


  void Start (){
     Valor_slider = GetComponent<Text>();

    placeholder1.text = "";
    placeholder2.text = "";
    placeholder3.text = "";
    placeholder4.text = "";

    input1.interactable = false;
    input2.interactable = false;
    input3.interactable = false;
    input4.interactable = false;
  }

  public void ShowSliderValue () {
    string sliderMessage = "Quantidade de alternativas: "+ sliderUI.value;
    Valor_slider.text = sliderMessage;
    setActive(sliderUI.value);
  }



  void update(){
    ShowSliderValue();
  }


  void setActive(float valor_slider){
     
      if ((int)valor_slider == 0){
        placeholder1.text = "";
        placeholder2.text = "";
        placeholder3.text = "";
        placeholder4.text = "";

        texto_usuario1.text = "";
        texto_usuario2.text = "";
        texto_usuario3.text = "";
        texto_usuario4.text = "";

        input1.interactable = false;
        input2.interactable = false;
        input3.interactable = false;
        input4.interactable = false;
      }
      else if ((int) valor_slider == 1){
          placeholder1.text = "Alternativa 1";
          input1.interactable = true;

          input2.interactable = false;
          input3.interactable = false;
          input4.interactable = false;


          texto_usuario2.text = "";
          texto_usuario3.text = "";
          texto_usuario4.text = "";


          placeholder2.text = "";
          placeholder3.text = "";
          placeholder4.text = "";
      }
      else if ((int) valor_slider == 2){
          placeholder1.text = "Alternativa 1";
          input1.interactable = true;

          placeholder2.text = "Alternativa 2";
          input2.interactable = true;

          input3.interactable = false;
          input4.interactable = false;

          texto_usuario3.text = "";
          texto_usuario4.text = "";

          placeholder3.text = "";
          placeholder4.text = "";
      }
      else if ((int) valor_slider == 3){
          placeholder1.text = "Alternativa 1";
          input1.interactable = true;

          placeholder2.text = "Alternativa 2";
          input2.interactable = true;

          input3.interactable = true;
          placeholder3.text = "Alternativa 3";


          input4.interactable = false;

          texto_usuario4.text = "";
          
          placeholder4.text = "";
      }
      else if ((int) valor_slider == 4){
          placeholder1.text = "Alternativa 1";
          input1.interactable = true;

          placeholder2.text = "Alternativa 2";
          input2.interactable = true;

          input3.interactable = true;
          placeholder3.text = "Alternativa 3";

          input4.interactable = true;
          placeholder4.text = "Alternativa 4";
          
      }
  }


}