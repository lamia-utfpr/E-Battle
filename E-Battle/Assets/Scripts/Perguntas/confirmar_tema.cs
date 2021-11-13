using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class confirmar_tema : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioConfirmTema;

    [SerializeField]
    private GameObject tabela;

    [SerializeField]
    private GameObject sliderJogador;

    [SerializeField]
    private GameObject sliderTempo;

    [SerializeField]
    private GameObject alt1;

    [SerializeField]
    private GameObject alt2;

    [SerializeField]
    private GameObject alt3;

    [SerializeField]
    private GameObject alt4;

    [SerializeField]
    private GameObject alt5;

    [SerializeField]
    private GameObject[] jogadores;

    [SerializeField]
    private GameObject preencherNomes;


    List<string> group_names = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void confirmarTema()
    {
        tabela.GetComponent<tabelaDosTemas>().confirmar_tema();
    }


    public void temaPartida()
    {
        if (verificarNomesPreenchidos())
        {
            if (!verificarNomesRepetidos())
            {
                if (verificarTemaEscolhido())
                {
                    List<string> texto_pergunta = new List<string>();


                    for (int i = 0; i < (int)sliderJogador.GetComponent<Slider>().value; i++)
                    {
                        group_names.Add(jogadores[i].GetComponent<InputField>().text);
                    }

                    tabelaDosTemas.confirmar_temaPartida();
                    MvP1.set_quantiaPlayers(sliderJogador.GetComponent<slider_quantiaplayer>().getValorSlider());
                    MvP1.set_groupNames(group_names);
                    apresentarPergunta.setTempoMaximo(sliderTempo.GetComponent<Slider>().value + 1);
                    HUD.setPlayer(group_names[0]);
                    apresentarPergunta.aleatorizarPerguntas = aleatorizar_Toggle.estadoAtual;
                    musica_fundo.tocarMusica = tirar_musica_tabuleiro.estadoAtual;
                    audioConfirmTema.Play();


                    SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
                }
                else
                {
                    preencherNomes.GetComponent<popUp_preencherNomesGrupos>().mostrarPopUp(1);
                }
            }
            else
            {
                preencherNomes.GetComponent<popUp_preencherNomesGrupos>().mostrarPopUp(2);
            }
        }
        else
        {
            preencherNomes.GetComponent<popUp_preencherNomesGrupos>().mostrarPopUp(0);
        }


    }


    private bool verificarNomesPreenchidos()
    {

        for (int i = 0; i < (int)sliderJogador.GetComponent<Slider>().value; i++)
        {
            if (jogadores[i].GetComponent<InputField>().interactable &&
             String.IsNullOrWhiteSpace(jogadores[i].GetComponent<InputField>().text))
                return false;
        }

        return true;

    }

    private bool verificarNomesRepetidos()
    {
        for (int i = 0; i < (int)sliderJogador.GetComponent<Slider>().value; i++)
        {
            for (int j = i + 1; j < (int)sliderJogador.GetComponent<Slider>().value; j++)
            {
                if (jogadores[i].GetComponent<InputField>().interactable && jogadores[j].GetComponent<InputField>().interactable)
                    if (String.Equals(jogadores[i].GetComponent<InputField>().text, jogadores[j].GetComponent<InputField>().text))
                        return true;
            }
        }

        return false;
    }

    private bool verificarTemaEscolhido()
    {
        return (
            alt1.GetComponent<toggleRet1>().getStatus() ||
            alt2.GetComponent<toggleRet1>().getStatus() ||
            alt3.GetComponent<toggleRet1>().getStatus() ||
            alt4.GetComponent<toggleRet1>().getStatus() ||
            alt5.GetComponent<toggleRet1>().getStatus()
        );
    }

}
