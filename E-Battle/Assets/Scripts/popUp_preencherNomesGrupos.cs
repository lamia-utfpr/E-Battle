﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_preencherNomesGrupos : MonoBehaviour
{
    private static Text texto;
    private static bool naTela = false;
    private static float tempoTela = 3.0f;
    private static AudioSource audioTemaInserido;


    void Start()
    {

    }

    // Update is called once per frame


    public static bool get_naTela()
    {
        return naTela;
    }

    // Update is called once per frame
    void Update()
    {

        if (naTela)
        {
            removerTela();
        }

    }

    public static void removerTela()
    {
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;

        }
        else
        {
            //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "";
            naTela = false;
            tempoTela = 3.0f;
            GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(-2000, 0, 1);
        }
    }

    public static void mostrarPopUp(int op)
    {
        if (!naTela)
        {
            if (op == 0)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Preencha todos os nomes dos grupos!";
                GameObject.Find("alerta/Text").GetComponent<Text>().text = "Preencha todos os nomes dos grupos!";
                GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);
            }
            else if (op == 1)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Selecione um tema!";
                GameObject.Find("alerta/Text").GetComponent<Text>().text = "Selecione um tema!";
                GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);
            }
            else if (op == 2)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Não é possível começar a partida com nomes repetidos!";
                GameObject.Find("alerta/Text").GetComponent<Text>().text = "Não é possível começar a partida com nomes repetidos!";
                GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);

            }
            //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().color = Color.red;
            naTela = true;
        }

    }
}
