using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MvP1 : MonoBehaviour
{
    public int[] casaAtual;
    public GameObject[] casas;
    public int num;
    float novoX;
    float novoY;
    public float Speed = 40f;
    public GameObject[] players;
    public int jogadorAtual;
    public Camera camera;
    public GameObject hud;
    private Vector3 velocity = Vector3.zero;
    private List<string> powerups;
    private bool dadoMaior = false;


    private int quantiaPlayers = 4;
    private int quantiaCasas = 20;
    private int[] powerUpsTabuleiro;



    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("ControleTurno");
        hud.SetActive(true);
        jogadorAtual = 0;
        PlayerPrefs.SetInt("jogadoratual",0);
        PlayerPrefs.SetInt("Valor do Dado", 5);
        casas = GameObject.FindGameObjectsWithTag("Casas");
        players = GameObject.FindGameObjectsWithTag("Player");
        casaAtual = new int[players.Length];


        powerUpsTabuleiro = new int[20];
        

    }

    //Aqui, criamos um vetor de casas que ira nos guiar pelo tabuleiro
    //Um vetor de players para sabermos qual jogador tera sua vez
    //E um vetor de casas atuais, que possui o mesmo tamanho do vetor de players
    //que serve para descobrirmos a posição individual de cada jogador no tabuleiro

    public void setPowerUpsTabuleiro(int[] inicializacao){
        powerUpsTabuleiro = inicializacao;
    }

    public int[] get_powerUpsTabuleiro(){
        return powerUpsTabuleiro;
    }

    public int get_quantiaCasas(){
        return quantiaCasas;
    }


    public void aumentarJogadorAtual(){
        jogadorAtual++;
        if (jogadorAtual >= 4){
            jogadorAtual = 0;
            fimTurno();
        }
    }

    // Update is called once per frame
    void Update()
    {
        num = PlayerPrefs.GetInt("Valor do Dado");
        if(casas == null)
        {
            casas = GameObject.FindGameObjectsWithTag("Casas");
        }
    }


    public void setDadoMaior(bool x){
        dadoMaior = x;
    }

    public bool getDadoMaior(){
        return dadoMaior;
    }


    //Comentar com o thiago sobre este possivel CRIME de vetores
    //sempre que nos referirmos a casas[casaAtual[jogadorAtual]] estamos nos referindo a posição atual do jogador da vez
    //dentro do tabuleiro, e usando este valor.

    public void moverNovo(int valorDado){
        if (dadoMaior == true)
            dadoMaior = false;
        
        num = valorDado;

        
        //player se move no eixo X
        players[jogadorAtual].GetComponent<Player>().setX(num*40);

        
        //aumenta a variável que o player possui para controlar a casa atual
        players[jogadorAtual].GetComponent<Player>().set_casaAtual(players[jogadorAtual].GetComponent<Player>().get_casaAtual() + num);


        //coloca a câmera no proximo player
        camera = GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>();
        camera.transform.position = new Vector3(players[jogadorAtual].transform.position.x, players[jogadorAtual].transform.position.y, -10);


        //condição de vitória pra ver se o player que se moveu venceu
        if (players[jogadorAtual].GetComponent<Player>().get_casaAtual() >= quantiaCasas){
            Debug.Log("Player " + jogadorAtual + " venceu!");
        }

        players[jogadorAtual].GetComponent<Player>().verificarObtencaoDePowerUp(players[jogadorAtual].GetComponent<Player>().get_casaAtual());


        jogadorAtual++;
        
        if (jogadorAtual >= quantiaPlayers)
        {
            jogadorAtual = 0;
            fimTurno();
        }

        passarVez();

    }


    public void Mover(int valorDado)
    {
        if (dadoMaior == true)
            dadoMaior = false;
        
        num = valorDado;
        
        casaAtual[jogadorAtual] += num;
        if ((casaAtual[jogadorAtual]) >= 19)
        {
            casaAtual[jogadorAtual] = 19;
            SceneManager.LoadScene("Cena De vitoria", LoadSceneMode.Single);
        }
        novoX = casas[casaAtual[jogadorAtual]].transform.position.x;
        novoY = casas[casaAtual[jogadorAtual]].transform.position.y;
        
        players[jogadorAtual].transform.position = new Vector3(novoX, novoY, 0);
        camera = GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>();
        camera.transform.position = new Vector3(players[jogadorAtual].transform.position.x, players[jogadorAtual].transform.position.y, -10);

        //players[jogadorAtual].GetComponent<Player>().verificarObtencaoDePowerUp(casaAtual[jogadorAtual]);

        jogadorAtual++;
        
        if (jogadorAtual >= 4)
        {
            jogadorAtual = 0;
            fimTurno();
        }

        passarVez();

    }

    public GameObject getJogAtual(){
        return players[jogadorAtual];
    }

    public void passarVez()
    {
        PlayerPrefs.SetInt("jogadoratual", jogadorAtual);
        Debug.Log(PlayerPrefs.GetInt("jogadoratual"));
        hud.SetActive(true);
        GameObject.Find("HUD").GetComponent<HUD>().jogadorAtual(jogadorAtual + 1);
    }

    public void moverCamera()
    {
        camera = GameObject.Find("Camera_Tabuleiro").GetComponent<Camera>();
        camera.transform.position = new Vector3(players[jogadorAtual].transform.position.x, players[jogadorAtual].transform.position.y, -10);
    }


    public void fimTurno() {
        jogadorAtual = 0;

        int ultimocolocado = ultimoJogador();
        Debug.Log(ultimocolocado);
        int power = Random.Range(1, 3);



    }

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
}