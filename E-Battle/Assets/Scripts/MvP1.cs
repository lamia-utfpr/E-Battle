using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;


public class MvP1 : MonoBehaviour
{
    public int[] casaAtual;
    public int num;
    float novoX;
    float novoY;
    public static GameObject[] players;
    public static GameObject[] playerRanking;

    private static List<string> groupNames;

    public static int jogadorAtual;
    public Camera camera;
    public GameObject hud;
    private bool dadoMaior = true;

    public static bool moverCamera = false;
    private int turnoAtual = 1;
    private string jog_atual;

    private static int quantiaPlayers;


    public static void set_quantiaPlayers(int qtd)
    {
        quantiaPlayers = qtd;
        players = new GameObject[quantiaPlayers];
        playerRanking = new GameObject[quantiaPlayers];
    }


    public static void set_groupNames(List<string> names)
    {
        groupNames = names;
    }

    public GameObject[] get_players()
    {
        return players;
    }

    // Start is called before the first frame update
    void Start()
    {
        // mover depois pro script que estiver atrelado ao tabuleiro
        GameObject.Find("controlar_spawn_powerups").GetComponent<controlarSpawnPowerUps>().preencherCasas();
        //
        hud = GameObject.Find("ControleTurno");
        hud.SetActive(true);
        jogadorAtual = 0;


        casaAtual = new int[quantiaPlayers];

        GameObject.Find("rodada_atual_info").GetComponent<Text>().text = "Rodada atual: " + turnoAtual;

        if (quantiaPlayers == 2)
        {
            GameObject.Find("Player3").GetComponent<Player>().setX(3000);
            GameObject.Find("Player3").GetComponent<Player>().setY(3000);

            GameObject.Find("Player4").GetComponent<Player>().setX(3000);
            GameObject.Find("Player4").GetComponent<Player>().setY(3000);

            GameObject.Find("pos3_fundo").transform.position = new Vector3(0, 10000, 0);
            GameObject.Find("pos4_fundo").transform.position = new Vector3(0, 10000, 0);

        }
        else if (quantiaPlayers == 3)
        {
            GameObject.Find("Player4").GetComponent<Player>().setX(3000);
            GameObject.Find("Player4").GetComponent<Player>().setY(3000);

            GameObject.Find("pos4_fundo").transform.position = new Vector3(0, 10000, 0);
        }


        //alteração dos nomes dos personagens
        for (int i = 0; i < quantiaPlayers; i++)
        {
            GameObject.Find("Player" + (i + 1)).GetComponent<Player>().set_nomePlayer(groupNames[i]);
            GameObject.Find("Player" + (i + 1)).name = groupNames[i];
            players[i] = GameObject.Find(groupNames[i]);
            playerRanking[i] = players[i];
        }


        //preenchimento inicial do scoreboard

        for (int i = 0; i < quantiaPlayers; i++)
        {
            GameObject.Find("pos" + (i + 1) + "_fundo/pos" + (i + 1)).GetComponent<Text>().text = players[i].GetComponent<Player>().get_nomePlayer() + "    "
            + "(" + (players[i].GetComponent<Player>().get_casaAtual() - players[0].GetComponent<Player>().get_casaAtual()) + ")";
            GameObject.Find("pos" + (i + 1) + "_fundo").GetComponent<Image>().color = players[i].GetComponent<SpriteRenderer>().color;
        }

        /* Remoção da cor de fundo do scoreboard
        for (int i = quantiaPlayers; i < 4; i++){
            GameObject.Find("pos" + (i + 1)).GetComponent<Text>().text = "";
            GameObject.Find("pos" + (i + 1)).GetComponent<Text>().text
        }*/
    }

    //Aqui, criamos um vetor de casas que ira nos guiar pelo tabuleiro
    //Um vetor de players para sabermos qual jogador tera sua vez
    //E um vetor de casas atuais, que possui o mesmo tamanho do vetor de players
    //que serve para descobrirmos a posição individual de cada jogador no tabuleiro

    // Update is called once per frame
    void Update()
    {

    }


    public void setDadoMaior(bool x)
    {
        dadoMaior = x;
    }

    public bool getDadoMaior()
    {
        return dadoMaior;
    }


    //Comentar com o thiago sobre este possivel CRIME de vetores
    //sempre que nos referirmos a casas[casaAtual[jogadorAtual]] estamos nos referindo a posição atual do jogador da vez
    //dentro do tabuleiro, e usando este valor.

    public void moverNovo(int valorDado)
    {
        GameObject.Find("HUD_principal/jogador_atual_info").GetComponent<Text>().text = "Grupo atual: " + players[jogadorAtual].name;

        if (dadoMaior == true)
            dadoMaior = false;

        num = valorDado;

        //chama a função responsável por mover o player atual
        players[jogadorAtual].GetComponent<Player>().set_canMove(true, num);
    }

    public GameObject getJogAtual()
    {
        return players[jogadorAtual];
    }

    public static GameObject getJogAtualStatic()
    {
        return players[jogadorAtual];
    }

    public void passarVez()
    {
        jogadorAtual++;
        atualizarScoreboard();
        if (jogadorAtual >= quantiaPlayers)
        {
            fimTurno();
        }

        hud.SetActive(true);
        GameObject.Find("HUD").GetComponent<HUD>().jogadorAtual(players[jogadorAtual].name);

        if (players[jogadorAtual].GetComponent<Player>().perderTurno)
        {
            GameObject.Find("HUD").GetComponent<HUD>().jogadorPerdeuTurno();
        }
    }


    public void fimTurno()
    {
        jogadorAtual = 0;
        turnoAtual++;
        GameObject.Find("rodada_atual_info").GetComponent<Text>().text = "Rodada atual: " + turnoAtual;
    }


    public static Color[] returnScoreboard()
    {
        Color[] cores = new Color[playerRanking.Length];

        for (int i = 0; i < cores.Length; i++)
            cores[i] = playerRanking[i].GetComponent<SpriteRenderer>().color;

        return cores;
    }

    public static string[] returnScoreboardNames()
    {
        string[] names = new string[playerRanking.Length];

        for (int i = 0; i < names.Length; i++)
            names[i] = playerRanking[i].name;

        return names;
    }

    public void atualizarScoreboard()
    {

        //ordena em ordem decrescente
        for (int i = 0; i < quantiaPlayers; i++)
        {
            for (int j = 0; j < quantiaPlayers - 1; j++)
            {

                if (playerRanking[j] != null && playerRanking[j + 1] != null &&
                playerRanking[j].GetComponent<Player>().get_casaAtual() <= playerRanking[j + 1].GetComponent<Player>().get_casaAtual())
                {
                    GameObject temp = playerRanking[j + 1];
                    playerRanking[j + 1] = playerRanking[j];
                    playerRanking[j] = temp;
                }
            }
        }


        for (int i = 0; i < quantiaPlayers; i++)
        {
            GameObject.Find("pos" + (i + 1) + "_fundo/pos" + (i + 1)).GetComponent<Text>().text = playerRanking[i].GetComponent<Player>().get_nomePlayer() + "    "
            + "(" + (playerRanking[i].GetComponent<Player>().get_casaAtual() - playerRanking[0].GetComponent<Player>().get_casaAtual()) + ")";
            GameObject.Find("pos" + (i + 1) + "_fundo").GetComponent<Image>().color = playerRanking[i].GetComponent<SpriteRenderer>().color;
        }

    }
}