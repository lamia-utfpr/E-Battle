using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    private List<string> powerups;

    private int casaAtual = 0;

    private string nomePlayer;

    public bool canMove = false;
    private bool empurrar = false;
    public bool perderTurno = false;

    public static bool playerMovTravada = true;

    private bool verificarTrocaTurno = false;

    private bool venceu = false;
    private float tempoTela = 3f;

    private Transform[] Positions;
    [SerializeField] private float ObjectSpeed;

    Transform NextPos;
    Transform FinalPos;

    public int indicePlayerLeaderboard;

    int NextPosIndex = 0;

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
        ObjectSpeed = 150F;

        if (!this.name.Contains("Player"))
        {
            for (int i = 0; i < 39; i++)
                Positions[i] = GameObject.Find("Pos" + (i + 1)).transform;
        }

        NextPos = Positions[0];
        FinalPos = Positions[casaAtual];

    }
    // Update is called once per frame
    void Update()
    {
        if (venceu)
        {
            jogadorVenceu();
        }
        else
        {

            //a gente tá setando essa booleana no MvP1 com a função set_canMove desse script, pra indicar que o player deve se mover
            if (canMove && empurrar)
            {
                empurrarPlayer();
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            //verificação se o player pode se mover
            if (canMove)
            {
                if (GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>().orthographicSize == 300)
                {
                    move();
                    anim.SetBool("isWalking", true);
                }
            }


            //condição de vitória. aqui vemos se o player chegou no final e trocamos pra tela do pódio.
            if (Positions[38] != null)
            {
                if (Vector3.Distance(transform.position, Positions[38].position) < 0.001f)
                {
                    venceu = true;
                    anim.SetBool("isWalking", false);
                    //botar aqui a musica pra tocar quando vencer

                    set_fim_de_jogo_info.setPlayersColors(MvP1.returnScoreboard());
                    set_fim_de_jogo_info.setPlayersNames(MvP1.returnScoreboardNames());

                }
            }


            if (String.Equals(GameObject.Find("Players").GetComponent<MvP1>().getJogAtual().name, this.name) && MvP1.moverCamera && !playerMovTravada)
            {
                GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>().transform.position = Vector3.MoveTowards(GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>().transform.position, new Vector3(this.transform.position.x, this.transform.position.y, -10), (float)(ObjectSpeed * 2) * Time.deltaTime);
            }

            //trocando o turno só depois da camera afastar
            if (verificarTrocaTurno)
            {
                if (GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>().orthographicSize == 500)
                {
                    GameObject.Find("Players").GetComponent<MvP1>().passarVez();
                    verificarTrocaTurno = false;
                }
            }
        }

    }


    private void jogadorVenceu()
    {
        if (tempoTela > 1)
        {

            tempoTela -= Time.deltaTime;
        }
        else
        {
            tempoTela = 3f;
            SceneManager.LoadScene("Fim de jogo", LoadSceneMode.Single);
        }
    }

    private void move()
    {
        try
        {
            if (Vector3.Distance(transform.position, NextPos.position) < 0.001f)
            {
                NextPosIndex++;
                NextPos = Positions[NextPosIndex];
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);



            //checagem pra ver se o player chegou na casa alvo, e caso tenha chego, ele para de se mover
            if (Vector3.Distance(transform.position, FinalPos.position) < 0.001f)
            {
                playerMovTravada = true;
                canMove = false;
                verificarObtencaoDePowerUp(casaAtual);
                verificarTrocaTurno = true;
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void empurrarPlayer()
    {
        try
        {
            if (Vector3.Distance(transform.position, NextPos.position) < 0.001f)
            {
                NextPosIndex--;
                NextPos = Positions[NextPosIndex];
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);

            //checagem pra ver se o player chegou na casa alvo, e caso tenha chego, ele para de se mover
            if (Vector3.Distance(transform.position, FinalPos.position) < 0.001f)
            {
                canMove = false;
                empurrar = false;
                verificarObtencaoDePowerUp(casaAtual);
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void set_canMove(bool c)
    {
        canMove = c;
    }

    public void set_canMove(bool c, int dado)
    {
        /*seta a booleana de movimentação como true, atualiza a casa atual e registra qual a posição final que o player deve se mover (no caso, a casa atual que ele terá
        após a movimentação)*/
        canMove = c;
        casaAtual += dado;
        FinalPos = Positions[casaAtual - 1];
    }

    public void set_canMoveEmpurrar(bool c)
    {
        FinalPos = Positions[casaAtual - 1];
        canMove = c;
        empurrar = true;
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

        if (mapeamentoPowerUps[casa] == 1)
        {
            addPowerUp(gerarPowerUp());

            int[] novoVetor = mapeamentoPowerUps;
            novoVetor[casa] = 0;

            Tabuleiro.setPowerUpsTabuleiro(novoVetor);
            popUp_powerUp.mostrarPopUp(this.name, powerups[powerups.Count - 1]);

        }
    }

    public void pegarPowerUpAtras()
    {   
        //adiciona o power up aleatorio, sem remover nenhum do tabuleiro, e chama o pop up pra mostrar aos jogadores
        addPowerUp(gerarPowerUp());
        popUp_powerUp.mostrarPopUpAtras(this.name, powerups[powerups.Count - 1], indicePlayerLeaderboard);
    }

    private string gerarPowerUp()
    {
        string[] aux = GameObject.Find("controlar_spawn_powerups").GetComponent<controlarSpawnPowerUps>().powerUpsPossiveis();

        int indice = UnityEngine.Random.Range(0, aux.Length);

        return aux[indice];

    }


}