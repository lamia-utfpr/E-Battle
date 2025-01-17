﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class confirmar_tema : MonoBehaviour
{
    public AudioSource audioConfirmTema;
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
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().confirmar_tema();
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


                    for (int i = 0; i < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; i++)
                    {
                        group_names.Add(GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().text);
                    }

                    tabelaDosTemas.confirmar_temaPartida();
                    MvP1.set_quantiaPlayers(GameObject.Find("quantia_jogadores_slider").GetComponent<slider_quantiaplayer>().getValorSlider());
                    MvP1.set_groupNames(group_names);
                    apresentarPergunta.setTempoMaximo(GameObject.Find("config_jogo/quantia_tempo_slider").GetComponent<Slider>().value + 1);
                    HUD.setPlayer(group_names[0]);
                    apresentarPergunta.aleatorizarPerguntas = aleatorizar_Toggle.estadoAtual;
                    musica_fundo.tocarMusica = tirar_musica_tabuleiro.estadoAtual;
                    //       audioConfirmTema = GameObject.Find("confirmar_selecao_tema").GetComponent<AudioSource>();
                    //        audioConfirmTema.Play();


                    SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
                }
                else
                {
                    popUp_preencherNomesGrupos.mostrarPopUp(1);
                }
            }
            else
            {
                popUp_preencherNomesGrupos.mostrarPopUp(2);
            }
        }
        else
        {
            popUp_preencherNomesGrupos.mostrarPopUp(0);
        }


    }


    private bool verificarNomesPreenchidos()
    {

        for (int i = 0; i < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; i++)
        {
            if (GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().interactable &&
             String.IsNullOrWhiteSpace(GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().text))
                return false;
        }

        return true;

    }

    private bool verificarNomesRepetidos()
    {
        for (int i = 0; i < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; i++)
        {
            for (int j = i + 1; j < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; j++)
            {
                if (GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().interactable && GameObject.Find("PlayerName" + (j + 1)).GetComponent<InputField>().interactable)
                    if (String.Equals(GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().text, GameObject.Find("PlayerName" + (j + 1)).GetComponent<InputField>().text))
                        return true;
            }
        }

        return false;
    }

    private bool verificarTemaEscolhido()
    {
        return (
            GameObject.Find("alt_1/Toggle").GetComponent<toggleRet1>().getStatus() ||
            GameObject.Find("alt_2/Toggle").GetComponent<toggleRet2>().getStatus() ||
            GameObject.Find("alt_3/Toggle").GetComponent<toggleRet3>().getStatus() ||
            GameObject.Find("alt_4/Toggle").GetComponent<toggleRet4>().getStatus() ||
            GameObject.Find("alt_5/Toggle").GetComponent<toggleRet5>().getStatus()
        );
    }

}
