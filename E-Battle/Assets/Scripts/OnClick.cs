using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.IO;
using System;

public class OnClick : MonoBehaviour
{
    private BancoDeDados bancoDeDados = new BancoDeDados();
    public MvP1 move1;
    private InputField tema;
    public VideoPlayer video;
    public VideoClip[] videos;
    private int videoIndex;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    //Este bloco de códigos contém todos os códigos responsáveis por mudança de cenas.

    
    public void telaInicial()   // transição entre a tela inicial e a tela do tabuleiro do jogo
    {
        
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)
        

    }

    public void telaTema(){
        SceneManager.LoadScene("Criação de temas", LoadSceneMode.Single);
    }


    public void TelaDePerguntas()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {

        GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
    }


    public void CriarPerguntas()  //  transição entre a tela inicial e a tela onde será criado o tema do txt.
    {
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
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


    public void inserirTema()
    {   
        if (String.IsNullOrWhiteSpace(GameObject.Find("NomeDoTema").GetComponent<InputField>().text)){
            popUp_temaVazio.mostrarPopUp();
        }else{
            tema = GameObject.Find("NomeDoTema").GetComponent<InputField>();
            bancoDeDados.inserirTema(tema);
        }

        
    }

    public void Sair(){
        Application.Quit();
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

    public void ok()
    {
        GameObject.Find("ControleTurno").SetActive(false);
        move1 = GameObject.FindGameObjectWithTag("Controlador").GetComponent<MvP1>();
        move1.moverCamera();
    }

    public void background() {

        videoIndex++;

        if(videoIndex >= videos.Length)
        {
            videoIndex = videoIndex % videos.Length;
        }
        
        video.clip = videos[videoIndex];
        video.Play();
    }

}
