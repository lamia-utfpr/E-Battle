﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class setarTabelaPlayers : MonoBehaviour
{
    // Start is called before the first frame update

    private int acao = 99;
    GameObject[] players;

    void Start()
    {
        players = GameObject.Find("Players").GetComponent<MvP1>().get_players();
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela/Text").GetComponent<Text>().text = "";
            GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela").GetComponent<Image>().color = new Color(255, 255, 255, 0);

        }

        for (int i = 0; i < players.Length; i++)
        {
            GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela").GetComponent<Image>().color = new Color(255, 255, 255, 1);
            GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela/Text").GetComponent<Text>().text = players[i].name;
        }

    }

    // Update is called once per frame
    void Update()
    {
        manusearTabela();
    }

    private void manusearTabela()
    {
        for (int i = 0; i < players.Length; i++)
        {

            if (players[i].name == MvP1.getJogAtualStatic().name)
            {
                GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela").GetComponent<Button>().interactable = false;
            }
            else
                GameObject.Find("tabela_players/player_" + (i + 1) + "_tabela").GetComponent<Button>().interactable = true;

        }
    }

    public void setarAcao(int ac)
    {
        acao = ac;
    }

    public void acaoPowerUp(string player)
    {
        GameObject playerAlvo = null;

        for (int i = 0; i < players.Length; i++)
            if (players[i].name == player)
                playerAlvo = players[i];

        switch (acao)
        {
            case 0:
                empurrar(playerAlvo);
                break;

            case 1:
                prender(playerAlvo);
                break;
        }

        tirarTabela();
        acao = 99;
    }


    public void empurrar(GameObject player)
    {
        if (player.GetComponent<Player>().get_casaAtual() - 3 < 0)
            player.GetComponent<Player>().set_casaAtual(0);
        else
            player.GetComponent<Player>().set_casaAtual(player.GetComponent<Player>().get_casaAtual() - 3);

        player.GetComponent<Player>().set_canMoveEmpurrar(true);

    }

    public void prender(GameObject player){
        player.GetComponent<Player>().perderTurno = true;
    }

    public void tirarTabela()
    {
        GameObject.Find("tabela_players").transform.position = new Vector3(5000, 0, 0);
    }

}
