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

    [SerializeField]
    private GameObject Hud;

    [SerializeField]
    private GameObject jogAtualInfo;

    [SerializeField]
    private GameObject controleTurno;

    [SerializeField]
    private GameObject painelPergunta;

    [SerializeField]
    private GameObject powerups;

    [SerializeField]
    private GameObject players;

    [SerializeField]
    private GameObject botaoTurno;

    void Start()
    {
        Hud.GetComponent<Text>().text = "Turno do grupo " + texto;
        jogAtualInfo.GetComponent<Text>().text = "Grupo atual: " + texto;
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrarMsgTurnoPerdido)
        {
            botaoTurno.GetComponent<Button>().interactable = false;
            botaoTurno.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            botaoTurno.GetComponent<Text>().text = "";
            mostrar();
        }
        else
        {
            botaoTurno.GetComponent<Button>().interactable = true;
            botaoTurno.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            botaoTurno.GetComponent<Text>().text = "Ok";
        }

    }

    public static void setPlayer(string name)
    {
        texto = name;
    }


    public void jogadorAtual(string jogador)
    {
        nomeJogAtual = jogador;
        Hud.GetComponent<Text>().text = "Turno do grupo " + jogador;
        jogAtualInfo.GetComponent<Text>().text = "Grupo atual: " + jogador;
    }

    public void perdeuTurno()
    {
        jogadorAtualPerdeuTurno = false;
        Hud.GetComponent<Text>().text = "Que pena, você perdeu seu turno!";
        mostrarMsgTurnoPerdido = true;
    }

    public void powerup(string powerup, int jogador)
    {
        Hud.GetComponent<Text>().text = "O jogador " + jogador + " Recebeu o powerup de: " + powerup;
    }

    public void jogadorPerdeuTurno()
    {
        jogadorAtualPerdeuTurno = true;
    }

    public void ok()
    {
<<<<<<< Updated upstream
        if (!jogadorAtualPerdeuTurno)
        {
            GameObject.Find("ControleTurno").SetActive(false);
=======
        players.GetComponent<MvP1>().setDadoMaior(false);
        if (!jogadorAtualPerdeuTurno)
        {
            painelPergunta.GetComponent<apresentarPergunta>().mostrarPergunta();
            powerups.GetComponent<gerenciarPowerUps>().verificarPowerUpsDisponiveis(GameObject.Find("Players").GetComponent<MvP1>().getJogAtual());
            controleTurno.SetActive(false);
>>>>>>> Stashed changes
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
            controleTurno.SetActive(false);
            mostrarMsgTurnoPerdido = false;
            timeTela = 4f;
            players.GetComponent<MvP1>().getJogAtual().GetComponent<Player>().perderTurno = false;
            players.GetComponent<MvP1>().passarVez();
        }

    }
}
