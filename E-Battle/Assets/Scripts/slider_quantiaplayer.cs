using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slider_quantiaplayer : MonoBehaviour
{
    // Start is called before the first frame update

    private int valorSlider = 2;


    public int getValorSlider(){
        return valorSlider;
    }

    public int getValorSliderCasas(){
        return (int) GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void mudarQuantia(){
        int quantia = (int) GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value;
        Text texto = GameObject.Find("quantia_jogadores_slider/quantia_jogadores_texto").GetComponent<Text>();
        texto.text = "Quantidade de jogadores: " + quantia;
        valorSlider = quantia;
    }

    public void mudarQuantiaCasas(){
        int value = (int) GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value;
        int stepSize = 10;
        value = (value - value % stepSize);
        GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value = value;

        Text texto = GameObject.Find("tamanho_mapa_slider/tamanho_mapa_texto").GetComponent<Text>();
        texto.text = "Quantidade de casas: " + value;
    }

}
