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


    [SerializeField]
    private GameObject[] vetPlayer;

    [SerializeField]
    private GameObject[] playerfundo;

    private static List<string> groupNames;

    public static int jogadorAtual;
    public Camera camera;

    [SerializeField]
    private GameObject controleTurno;

    [SerializeField]
    private GameObject spawnPowerUp;

    [SerializeField]
    private GameObject rodadaAtualInfo;

    [SerializeField]
    private GameObject Hud;

    [SerializeField]
    private GameObject jogAtualInfo;


    private bool dadoMaior = false;

    public static bool moverCamera;
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
        moverCamera = false;
        // mover depois pro script que estiver atrelado ao tabuleiro
        spawnPowerUp.GetComponent<controlarSpawnPowerUps>().preencherCasas();
        //
        controleTurno.SetActive(true);
        jogadorAtual = 0;


        casaAtual = new int[quantiaPlayers];

        rodadaAtualInfo.GetComponent<Text>().text = "Rodada atual: " + turnoAtual;

        if (quantiaPlayers == 2)
        {
            vetPlayer[2].GetComponent<Player>().setX(3000);
            vetPlayer[2].GetComponent<Player>().setY(3000);

            vetPlayer[3].GetComponent<Player>().setX(3000);
            vetPlayer[3].GetComponent<Player>().setY(3000);

            playerfundo[2].transform.position = new Vector3(0, 10000, 0);
            playerfundo[3].transform.position = new Vector3(0, 10000, 0);

        }
        else if (quantiaPlayers == 3)
        {
            vetPlayer[3].GetComponent<Player>().setX(3000);
            vetPlayer[3].GetComponent<Player>().setY(3000);

            playerfundo[3].transform.position = new Vector3(0, 10000, 0);
        }


        //alteração dos nomes dos personagens
        for (int i = 0; i < quantiaPlayers; i++)
        {
            vetPlayer[i].GetComponent<Player>().set_nomePlayer(groupNames[i]);
            vetPlayer[i].name = groupNames[i];
            players[i] = GameObject.Find(groupNames[i]);
            playerRanking[i] = players[i];
        }


        //preenchimento inicial do scoreboard

        for (int i = 0; i < quantiaPlayers; i++)
        {
            playerfundo[i].GetComponentInChildren<Text>().text = players[i].GetComponent<Player>().get_nomePlayer() + "    "
            + "(" + (players[i].GetComponent<Player>().get_casaAtual() - players[0].GetComponent<Player>().get_casaAtual()) + ")";
            playerfundo[i].GetComponent<Image>().color = players[i].GetComponent<SpriteRenderer>().color;
        }
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
        jogAtualInfo.GetComponent<Text>().text = "Grupo atual: " + players[jogadorAtual].name;

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

        controleTurno.SetActive(true);
        Hud.GetComponent<HUD>().jogadorAtual(players[jogadorAtual].name);

        if (players[jogadorAtual].GetComponent<Player>().perderTurno)
        {
            Hud.GetComponent<HUD>().jogadorPerdeuTurno();
        }
    }


    public void fimTurno()
    {
        jogadorAtual = 0;
        turnoAtual++;
<<<<<<< Updated upstream
        GameObject.Find("rodada_atual_info").GetComponent<Text>().text = "Rodada atual: " + turnoAtual;
        verificarPowerUp();
=======
        rodadaAtualInfo.GetComponent<Text>().text = "Rodada atual: " + turnoAtual;
>>>>>>> Stashed changes
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
            playerfundo[i].GetComponentInChildren<Text>().text = playerRanking[i].GetComponent<Player>().get_nomePlayer() + "    "
            + "(" + (playerRanking[i].GetComponent<Player>().get_casaAtual() - playerRanking[0].GetComponent<Player>().get_casaAtual()) + ")";
            playerfundo[i].GetComponent<Image>().color = playerRanking[i].GetComponent<SpriteRenderer>().color;
        }
    }

    private void verificarPowerUp()
    {
        for (int i = 0; i < quantiaPlayers; i++)
        {
            //verificando se o player está 10 casas ou mais atrás do primeiro. se estiver, armazenamos o seu indice (posiçao na leaderboard) e chamamos a função pra pegar o power up
            if (playerRanking[i].GetComponent<Player>().get_casaAtual() - playerRanking[0].GetComponent<Player>().get_casaAtual() <= -10)
            {
                playerRanking[i].GetComponent<Player>().indicePlayerLeaderboard = i;
                playerRanking[i].GetComponent<Player>().pegarPowerUpAtras();
            }
        }
    }
}