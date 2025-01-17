﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_powerUp : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource som;
    public AudioClip comemora;


    private static Text texto;

    private static string nome;

    private static bool naTela = false;

    private static bool tirarTela = false;

    private static float tempoTela = 4.0f;
    private static string nomePlayer;
    private static string nomePower;
    private static int popUpSpeed = 1500;

    void Start()
    {
        GameObject.Find("popUp_powerUp").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras1").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras2").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras3").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
    }


    public static bool get_naTela()
    {
        return naTela;
    }

    // Update is called once per frame
    void Update()
    {

        if (naTela)
        {
            som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
            som.clip = comemora;
            som.Play();
            GameObject.Find(nome).transform.position = Vector3.MoveTowards(GameObject.Find(nome).transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1), popUpSpeed * Time.deltaTime);

            if (Vector3.Distance(GameObject.Find(nome).transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1)) < 0.001f)
            {
                tirarTela = true;
                naTela = false;
                GameObject.Find(nome + "/Text").GetComponent<Text>().text = "O grupo " + nomePlayer + " pegou o super poder " + nomePower + "!";
            }
        }

        if (tirarTela)
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

            GameObject.Find(nome).transform.position = Vector3.MoveTowards(GameObject.Find(nome).transform.position, new Vector3(0, 2000, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find(nome).transform.position, new Vector3(0, 2000, 1)) < 500f)
            {
                tirarTela = false;
                tempoTela = 6.0f;
                GameObject.Find(nome).transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
            }
        }
    }

    public static void mostrarPopUp(string nomeplayer, string nomepower)
    {
        nome = "";

        switch (nomepower)
        {
            case "Aumentar tempo":
                nome = "pw_tempo";
                break;
            case "Eliminar alternativas":
                nome = "pw_eliminar_alt";
                break;

            case "Dado maior":
                nome = "pw_dado_maior";
                break;

            case "Prender jogador":
                nome = "pw_personagem_dorme";
                break;
        }


        if (!naTela && !string.Equals(nome, ""))
        {
            nomePlayer = nomeplayer;
            nomePower = nomepower;
            naTela = true;
            GameObject.Find(nome + "/Text").GetComponent<Text>().text = "";
        }

    }

    public static void mostrarPopUpAtras(string nomeplayer, string nomepower, int indice)
    {
        switch (indice)
        {
            case 1:
                GameObject.Find("popUp_powerUpAtras1").GetComponent<popUp_powerUpAtras>().setInfo1(nomeplayer, nomepower);
                break;
            case 2:
                GameObject.Find("popUp_powerUpAtras2").GetComponent<popUp_powerUpAtras>().setInfo2(nomeplayer, nomepower);
                break;
            case 3:
                GameObject.Find("popUp_powerUpAtras3").GetComponent<popUp_powerUpAtras>().setInfo3(nomeplayer, nomepower);
                break;
        }
    }

}