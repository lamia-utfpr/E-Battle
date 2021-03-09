using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class OnClick : MonoBehaviour
{
    private BancoDeDados bancoDeDados = new BancoDeDados();
    public Button botao;
    public Text nGerado;
    public int numero;
    public MvP1 move1;
    public GameObject[] players;
    public int jog;
    public InputField tema;
    public string temas;
    public InputField pergunta;
    public InputField respostaCerta;
    public InputField alternativaErrada;
    public string path;
    public PowerUps powerup;

    public bool randomizar; 

    string respCorreta;    
    int mostrarCerta = 1;
    int ultimaPergunta = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
        randomizar = true;
        if (SceneManager.GetActiveScene().name == "Apresentar perguntas"){
            mostrarPergunta();
            habilitarpowerups();
        }
    */
        //jog = 0;
        //powerup = GameObject.Find("PowerUp Dado Maior").GetComponent<PowerUps>();
        
    }

    //Este bloco de códigos contém todos os códigos responsáveis por mudança de cenas.

    
    public void telaInicial()   // transição entre a tela inicial e a tela do tabuleiro do jogo
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)
    }


    public void TelaDePerguntas()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {

        GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
    }


    public void CriarPerguntas()  //  transição entre a tela inicial e a tela onde será criado o tema do txt.
    {
        SceneManager.LoadScene("Criação de temas", LoadSceneMode.Single);
    }


    public void AcertoDePergunta()  //  transição após o jogador acertar a pergunta, voltando para o tabuleiro
    {
        if (GameObject.Find("PowerUp DadoMaior").GetComponent<PowerUps>().dadoMaior)
        {
            SceneManager.LoadScene("Rolagem Dado Maior", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Rolagem do Dado", LoadSceneMode.Single);
        }
    }


    public void ErroDePergunta()  //  transição após o jogador errar a pergunta, voltando para o tabuleiro
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }

    public void HudPessoal()
    {

        GameObject.Find("mostrarInfosJogador").GetComponent<apresentarInfoPlayerAtual>().mostrarInformacoes();
        GameObject.Find("mostrarInfosJogador").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(-150, 150, 1);
        
    }

    public void tabuleiro()     //  transição de tela para sair do HUD Pessoal e voltar para o tabuleiro
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }

    /*
    public void movimento()
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
        move1 = GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>();
        move1.Mover();
    }
    */
    
    // Fim do bloco de transição de perguntas



    // Bloco de código que lidam com a customização dos txt


    public void inserirTema()  // Este bloco é responsavel pela criação do txt com o tema criado pelo professor
    {
        bancoDeDados.inserirTema(tema);
    }

    public void Sair(){
        Application.Quit();
    }

    
    public void TaskOnClick() {
        //SceneManager.LoadScene(3, LoadSceneMode.Additive);      //O indice 2 é sobre a cena que faz as perguntas.
        /*numero = Random.Range(1, 5);
        switch (jog)
        {
            case 0:
                move1.Mover();
                break;
            case 1:
                move2.Mover();
                break;
            case 2:
                move3.Mover();
                break;
            case 3:
                move4.Mover();
                break;
        }
        if(jog == 3)
        {
            jog = -1;
        }
        jog++;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Apresentar perguntas")
        {
            //mostrarPergunta();
        }        
    }

    
    /*
    public void teste() {
        move1 = GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>();
        move1.Mover();
    }
    */

    public void eliminarAlternativas()
    {
        int removidas = 0;

        for (int i = 1; i < 5; i++)
        {
            if (removidas == 2)
                break;
            else
                if (GameObject.Find("Alt" + i).GetComponentInChildren<Text>().text != respCorreta)
            {
                GameObject.Find("Alt" + i).GetComponent<Image>().enabled = false;
                GameObject.Find("Alt" + i).GetComponentInChildren<Text>().text = null;
                removidas++;
            }
        }


    }

    public void ok()
    {
        GameObject.Find("ControleTurno").SetActive(false);
        move1 = GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>();
        move1.moverCamera();
    }



}
