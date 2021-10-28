using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour
{
    private static string texto;
    public static bool jogadorAtualPerdeuTurno = false;

    private string nomeJogAtual = null;

    private float timeTela = 4f;
    private bool mostrarMsgTurnoPerdido = false;

    void Start()
    {
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "Turno do grupo " + texto;
        GameObject.Find("jogador_atual_info").GetComponent<Text>().text = "Grupo atual: " + texto;
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrarMsgTurnoPerdido)
        {
            GameObject.Find("ControleTurno/Button").GetComponent<Button>().interactable = false;
            GameObject.Find("ControleTurno/Button").GetComponent<Image>().color = new Color(255, 255, 255, 0);
            GameObject.Find("ControleTurno/Button/Text").GetComponent<Text>().text = "";
            mostrar();
        }
        else
        {
            GameObject.Find("ControleTurno/Button").GetComponent<Button>().interactable = true;
            GameObject.Find("ControleTurno/Button").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GameObject.Find("ControleTurno/Button/Text").GetComponent<Text>().text = "Ok";
        }

    }

    public static void setPlayer(string name)
    {
        texto = name;
    }


    public void jogadorAtual(string jogador)
    {
        nomeJogAtual = jogador;
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "Turno do grupo " + jogador;
        GameObject.Find("jogador_atual_info").GetComponent<Text>().text = "Grupo atual: " + jogador;
    }

    public void perdeuTurno()
    {
        jogadorAtualPerdeuTurno = false;
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "Que pena, você perdeu seu turno!";
        mostrarMsgTurnoPerdido = true;
    }

    public void powerup(string powerup, int jogador)
    {
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "O jogador " + jogador + " Recebeu o powerup de: " + powerup;
    }

    public void jogadorPerdeuTurno()
    {
        jogadorAtualPerdeuTurno = true;
    }

    public void ok()
    {
        if (!jogadorAtualPerdeuTurno)
        {
            GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().mostrarPergunta();
            GameObject.Find("powerups").GetComponent<gerenciarPowerUps>().verificarPowerUpsDisponiveis(GameObject.Find("Players").GetComponent<MvP1>().getJogAtual());
            GameObject.Find("ControleTurno").SetActive(false);
            botao_mostrar_pergunta.mostrarPergunta = true;
            MvP1.moverCamera = true;
            Player.playerMovTravada = false;
        }
        else
        {
            perdeuTurno();
        }
    }

    private void mostrar()
    {
        if (timeTela > 1)
        {
            timeTela -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("ControleTurno").SetActive(false);
            mostrarMsgTurnoPerdido = false;
            timeTela = 4f;
            GameObject.Find("Players").GetComponent<MvP1>().getJogAtual().GetComponent<Player>().perderTurno = false;
            GameObject.Find("Players").GetComponent<MvP1>().passarVez();
        }

    }
}
