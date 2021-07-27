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

    public static bool mostrarPergunta = false;


    // Start is called before the first frame update
    void Start()
    {


    }

    //Este bloco de códigos contém todos os códigos responsáveis por mudança de cenas.


    public void telaInicial()   // transição entre a tela inicial e a tela do tabuleiro do jogo
    {

        SceneManager.LoadScene("Começar Jogo", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)


    }

    public void telaTema()
    {
        SceneManager.LoadScene("Criação de temas", LoadSceneMode.Single);
    }


    public void TelaDePerguntas()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {
        if (mostrarPergunta)
        {
            GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
            GameObject.Find("powerups").transform.position = GameObject.Find("painel_Pergunta").transform.position + new Vector3(-850, 0, 0);
            mostrarPergunta = false;
        }

    }


    public void CriarPerguntas()  //  transição entre a tela inicial e a tela onde será criado o tema do txt.
    {
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }


    /* Essa função mostra o hud pessoal dos jogadores 
    public void HudPessoal()
    {
        GameObject.Find("mostrarInfosJogador").GetComponent<apresentarInfoPlayerAtual>().mostrarInformacoes();
        GameObject.Find("mostrarInfosJogador").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(-150, 150, 1);

    }
    
    */
    public void tabuleiro()     //  transição de tela para sair do HUD Pessoal e voltar para o tabuleiro
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }

    public void inserirTema()
    {
        if (String.IsNullOrWhiteSpace(GameObject.Find("NomeDoTema").GetComponent<InputField>().text))
        {
            popUp_temaVazio.mostrarPopUp();
        }
        else
        {
            tema = GameObject.Find("NomeDoTema").GetComponent<InputField>();
            bancoDeDados.inserirTema(tema);
        }


    }

    public void Sair()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        if (mostrarPergunta)
            GameObject.Find("HUD_principal/Botao").GetComponent<Button>().interactable = true;
        else
            GameObject.Find("HUD_principal/Botao").GetComponent<Button>().interactable = false;

    }

    public void ok()
    {
        GameObject.Find("ControleTurno").SetActive(false);
        OnClick.mostrarPergunta = true;
    }


}
