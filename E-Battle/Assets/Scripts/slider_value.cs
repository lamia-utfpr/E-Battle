using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class slider_value : MonoBehaviour {

  public Slider sliderUI;
  private Text Valor_slider;
  public InputField input1;
  public InputField input2;
  public InputField input3;
  public InputField input4;

  void Start (){
    Valor_slider = GetComponent<Text>();
    ShowSliderValue();
  }

  public void ShowSliderValue () {

    string sliderMessage = "Quantidade de alternativas: "+ sliderUI.value;
    Valor_slider.text = sliderMessage;
  }



  void update(){
      setActive();
  }


  void setActive(){
      if (Valor_slider.text == "0"){

      }
      else{
           
        int i = 0;

        for (i = 1; i < 5; i++){
            if (i <= Convert.ToInt32(Valor_slider.text)){
                input1.ActivateInputField();
            }

        }
      }
     
  }
}