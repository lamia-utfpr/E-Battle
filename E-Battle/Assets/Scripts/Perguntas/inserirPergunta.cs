﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inserirPergunta : MonoBehaviour
{
    // Start is called before the first frame update

    private bool altVazia = false;
    private AudioSource som;
    public AudioClip sombotao;


    public void set_altVazia(bool altvazia){
        altVazia = altvazia;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inserirPergunt(){
        GameObject.Find("Alternativa_1").GetComponent<verificarAltVazia>().verificar();
        GameObject.Find("Alternativa_2").GetComponent<verificarAltVazia>().verificar();
        GameObject.Find("Alternativa_3").GetComponent<verificarAltVazia>().verificar();
        GameObject.Find("Alternativa_4").GetComponent<verificarAltVazia>().verificar();

        if (!altVazia)
        GameObject.Find("Valor_slider").GetComponent<slider_value>().inserirPergunta();

        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        som.clip = sombotao;
        som.Play();

    }

}
