﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class gerenciarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private Button pw1;
    private Button pw2;
    private Button pw3;
    private Button pw4;
    private Button pw5;
    private Button pw6;
    private Button pw7;
    private Button pw8;
    private Button pw9;
    private Button pw10;
    
    
    
    void Start()
    {
        zerarPw1();
        zerarPw2();
        zerarPw3();
        zerarPw4();
        zerarPw5();
        zerarPw6();
        zerarPw7();
        zerarPw8();
        zerarPw9();
        zerarPw10();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void verificarPowerUpsDisponiveis(){
        for (int i = 0; i < 10; i++){
            if (i == 0){
                this.transform.Find("Pw"+(i+1)).GetComponent<Image>().color = new Color(255, 255, 255, 1);
                this.transform.Find("Pw"+(i+1)+"/Text").GetComponent<Text>().text = "Aumentar tempo";
                this.transform.Find("Pw"+(i+1)).GetComponent<Button>().interactable = true;
            }else
            {
                break;
            }
            
        }
    }



    public void zerarPw1(){
        pw1 = this.transform.Find("Pw1").GetComponent<Button>();
        this.transform.Find("Pw1/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw1").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw2(){
        pw2 = this.transform.Find("Pw2").GetComponent<Button>();
        this.transform.Find("Pw2/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw2").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw3(){
        pw3 = this.transform.Find("Pw3").GetComponent<Button>();
        this.transform.Find("Pw3/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw3").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw4(){
        pw4 = this.transform.Find("Pw4").GetComponent<Button>();
        this.transform.Find("Pw4/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw4").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw5(){
        pw5 = this.transform.Find("Pw5").GetComponent<Button>();
        this.transform.Find("Pw5/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw5").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw6(){
        pw6 = this.transform.Find("Pw6").GetComponent<Button>();
        this.transform.Find("Pw6/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw6").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw7(){
        pw7 = this.transform.Find("Pw7").GetComponent<Button>();
        this.transform.Find("Pw7/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw7").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw8(){
        pw8 = this.transform.Find("Pw8").GetComponent<Button>();
        this.transform.Find("Pw8/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw8").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw9(){
        pw9 = this.transform.Find("Pw9").GetComponent<Button>();
        this.transform.Find("Pw9/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw9").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw10(){
        pw10 = this.transform.Find("Pw10").GetComponent<Button>();
        this.transform.Find("Pw10/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw10").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }



}