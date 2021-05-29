﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MvP1 : MonoBehaviour
{
    public int[] casaAtual;
    public int num;
    float novoX;
    float novoY;
    public static GameObject[] players;

    private static List<string> groupNames;

    public static int jogadorAtual = 0;
    public Camera camera;
    public GameObject hud;
    private bool dadoMaior = false;

    private int turnoAtual = 1;
    private string jog_atual;

    private static int quantiaPlayers;


    public static void set_quantiaPlayers(int qtd)
    {
        quantiaPlayers = qtd;
        players = new GameObject[quantiaPlayers];


        for (int i = 0; i < quantiaPlayers; i++)
        {
            players[i] = GameObject.Find("Player" + (i + 1));
        }



    }


    public static void set_groupNames(List<string> names)
    {

        groupNames = names;




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
        PlayerPrefs.SetInt("jogadoratual", 0);
        PlayerPrefs.SetInt("Valor do Dado", 5);


        casaAtual = new int[quantiaPlayers];

        GameObject.Find("rodada_atual_info").GetComponent<Text>().text = "Rodada atual: " + turnoAtual;

        if (quantiaPlayers == 2)
        {

            GameObject.Find("Player3").GetComponent<Player>().setX(3000);
            GameObject.Find("Player3").GetComponent<Player>().setY(3000);

            GameObject.Find("Player4").GetComponent<Player>().setX(3000);
            GameObject.Find("Player4").GetComponent<Player>().setY(3000);
        }
        else if (quantiaPlayers == 3)
        {
            GameObject.Find("Player4").GetComponent<Player>().setX(3000);
            GameObject.Find("Player4").GetComponent<Player>().setY(3000);
        }

        for (int i = 0; i < quantiaPlayers; i++)
            GameObject.Find("Player" + (i + 1)).name = groupNames[i];


    }

    //Aqui, criamos um vetor de casas que ira nos guiar pelo tabuleiro
    //Um vetor de players para sabermos qual jogador tera sua vez
    //E um vetor de casas atuais, que possui o mesmo tamanho do vetor de players
    //que serve para descobrirmos a posição individual de cada jogador no tabuleiro




    public void aumentarJogadorAtual()
    {
        jogadorAtual++;
        if (jogadorAtual >= quantiaPlayers)
        {
            jogadorAtual = 0;
            fimTurno();
        }
    }

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
        GameObject.Find("jogador_atual_info").GetComponent<Text>().text = "Jogador atual: " + players[jogadorAtual].name;

        if (dadoMaior == true)
            dadoMaior = false;

        num = valorDado;


        //player se move no eixo X
        players[jogadorAtual].GetComponent<Player>().setX(num * 40);


        //aumenta a variável que o player possui para controlar a casa atual
        players[jogadorAtual].GetComponent<Player>().set_casaAtual(players[jogadorAtual].GetComponent<Player>().get_casaAtual() + num);


        //coloca a câmera no proximo player
        camera = GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>();
        camera.transform.position = new Vector3(players[jogadorAtual].transform.position.x, players[jogadorAtual].transform.position.y, -10);


        //condição de vitória pra ver se o player que se moveu venceu
        if (players[jogadorAtual].GetComponent<Player>().get_casaAtual() >= Tabuleiro.get_quantiaCasas())
        {
            Debug.Log("Player " + jogadorAtual + " venceu!");
        }

        players[jogadorAtual].GetComponent<Player>().verificarObtencaoDePowerUp(players[jogadorAtual].GetComponent<Player>().get_casaAtual());


        jogadorAtual++;

        if (jogadorAtual >= quantiaPlayers)
        {
            jogadorAtual = 0;

            Debug.Log("AA");
            fimTurno();
        }

        passarVez();

    }

    public GameObject getJogAtual()
    {
        return players[jogadorAtual];
    }

    public static GameObject getJogAtualStatic()
    {
        return players[jogadorAtual];
    }

    public void atualizarHudPlayerAtual()
    {
        if (jogadorAtual >= quantiaPlayers)
        {
            GameObject.Find("jogador_atual_info").GetComponent<jogadorAtualHUDTabuleiro>().jogadorAtual(players[0].name);
        }
        else
            GameObject.Find("jogador_atual_info").GetComponent<jogadorAtualHUDTabuleiro>().jogadorAtual(getJogAtual().name);
    }

    public void passarVez()
    {
        PlayerPrefs.SetInt("jogadoratual", jogadorAtual);
        Debug.Log(PlayerPrefs.GetInt("jogadoratual"));

        bool aux = false;

        if (popUp_powerUp.get_naTela())
        {
            popUp_powerUp.removerTela();
            aux = true;
        }



        hud.SetActive(true);
        GameObject.Find("HUD").GetComponent<HUD>().jogadorAtual(getJogAtual().name + 1);
    }

    public void moverCamera()
    {
        camera = GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>();
        camera.transform.position = new Vector3(players[jogadorAtual].transform.position.x, players[jogadorAtual].transform.position.y, -10);
    }


    public void fimTurno()
    {
        jogadorAtual = 0;
        turnoAtual++;
        GameObject.Find("rodada_atual_info").GetComponent<Text>().text = "Rodada atual: " + turnoAtual;
    }

    /*
    public int ultimoJogador()
    {
        int ultimo = casaAtual[0];
        int last = 0;
        for (int i = 0; i < casaAtual.Length; i++)
        {
            if(casaAtual[i] < ultimo)
            {
                last = i;
            }
        }


        return last;
    }
    */
}