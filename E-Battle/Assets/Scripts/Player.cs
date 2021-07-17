using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private List<string> powerups;

    private int casaAtual = 0;

    private string nomePlayer;

    private bool canMove = false;


    private Transform[] Positions;
    [SerializeField] private float ObjectSpeed;

    Transform NextPos;

    public void set_nomePlayer(string nome)
    {
        nomePlayer = nome;
    }

    public string get_nomePlayer()
    {
        return nomePlayer;
    }

    public void set_casaAtual(int novaCasa)
    {
        casaAtual = novaCasa;
    }

    public int get_casaAtual()
    {
        return casaAtual;
    }


    public void setX(int novoX)
    {
        Vector3 temp = new Vector3(novoX, 0, 0);
        this.transform.position += temp;
    }

    public void setY(int novoY)
    {
        Vector3 temp = new Vector3(0, novoY, 0);
        this.transform.position += temp;
    }

    void Start()
    {

        powerups = new List<string>();
        Positions = new Transform[40];

        if (!this.name.Contains("Player"))
            for (int i = 0; i < 39; i++)
                Positions[i] = GameObject.Find("Pos" + (i + 1)).transform;
        NextPos = Positions[0];

    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
            move();
    }

    public void set_canMove(bool c)
    {
        canMove = c;
    }

    public void set_canMove(bool c, int dado)
    {
        canMove = c;
        casaAtual += dado;
    }

    public void move()
    {
        Debug.Log("Entrou");
        Debug.Log("Posicao atual: " + transform.position + " || NextPos: " + NextPos.position);
        NextPos = Positions[casaAtual];

        if (casaAtual >= 39)
        {
            //jogo acabou
        }
        else if (transform.position == NextPos.position * (-2F) || transform.position == NextPos.position * 2F)
        {
            Debug.Log("Parou");
            canMove = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        }

    }


    public List<string> getListaPowerUps()
    {
        return powerups;
    }

    public void atualizarListaPowerUps(List<string> listaNova)
    {
        powerups = listaNova;
    }

    public void addPowerUp(string nome)
    {
        powerups.Add(nome);
    }

    public void verificarObtencaoDePowerUp(int casa)
    {

        int[] mapeamentoPowerUps = Tabuleiro.get_powerUpsTabuleiro();

        Debug.Log(casa);
        Debug.Log(mapeamentoPowerUps.Length);


        if (mapeamentoPowerUps[casa] == 1)
        {

            addPowerUp(gerarPowerUp());



            int[] novoVetor = mapeamentoPowerUps;
            novoVetor[casa] = 0;

            Tabuleiro.setPowerUpsTabuleiro(novoVetor);
            popUp_powerUp.mostrarPopUp(this.name, powerups[powerups.Count - 1]);

        }

        /*
        if (GameObject.Find("casa " + casa)){
            if (GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().getTemPowerUp() ){

                addPowerUp(GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().get_nomePowerUp());
                GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().tirarPowerUp();
                
                Debug.Log(this.name + " pegou um power up! Ele caiu na casa " + casa);


            }
        }
        */



    }

    private string gerarPowerUp()
    {
        string[] aux = GameObject.Find("controlar_spawn_powerups").GetComponent<controlarSpawnPowerUps>().powerUpsPossiveis();

        int indice = UnityEngine.Random.Range(0, aux.Length);

        return aux[indice];

    }


}