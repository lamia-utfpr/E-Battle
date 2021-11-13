using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slider_quantiaplayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject jogadorQuantia;

    [SerializeField]
    private GameObject jogadorQuantiaTexto;

    [SerializeField]
    private GameObject[] playerName;

    [SerializeField]
    private GameObject tempoQuantia;

    [SerializeField]
    private GameObject tempoQuantiaTexto;

    private int valorSlider = 2;


    public int getValorSlider()
    {
        return valorSlider;
    }

    /*public int getValorSliderCasas()
    {
        return (int)GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value;
    }*/

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mudarQuantia()
    {
        int quantia = (int)jogadorQuantia.GetComponent<Slider>().value;
        Text texto = jogadorQuantiaTexto.GetComponent<Text>();
        texto.text = "Quantidade de grupos: " + quantia;
        valorSlider = quantia;
        showPlayerInputNames(quantia);
    }

    /*public void mudarQuantiaCasas()
    {
        int value = (int)GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value;
        int stepSize = 10;
        value = (value - value % stepSize);
        GameObject.Find("config_jogo/tamanho_mapa_slider").GetComponent<Slider>().value = value;

        Text texto = GameObject.Find("tamanho_mapa_slider/tamanho_mapa_texto").GetComponent<Text>();
        texto.text = "Quantidade de casas: " + value;
    }*/

    public void mudarTempo()
    {
        int value = (int)tempoQuantia.GetComponent<Slider>().value;
        int stepSize = 30;
        value = (value - value % stepSize);
        tempoQuantia.GetComponent<Slider>().value = value;

        Text texto = tempoQuantiaTexto.GetComponent<Text>();
        texto.text = "Tempo para as perguntas: " + value + " segundos";
    }

    private void showPlayerInputNames(int quantia)
    {

        //mostrar a quantia selecionada
        for (int i = 0; i < quantia; i++)
        {
            playerName[i].transform.Find("Placeholder").GetComponent<Text>().text = "Nome do grupo " + (i + 1);
            playerName[i].GetComponent<InputField>().interactable = true;
        }

        //fazer o resto desaparecer
        for (int i = quantia; i < 4; i++)
        {
            playerName[i].transform.Find("Placeholder").GetComponent<Text>().text = "";
            playerName[i].GetComponent<InputField>().text = "";
            playerName[i].GetComponent<InputField>().interactable = false;
        }
    }

}
