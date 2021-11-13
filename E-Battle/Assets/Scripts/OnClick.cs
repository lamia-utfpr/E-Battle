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
    public MvP1 move1;
    private InputField tema;
    public VideoPlayer video;
    public VideoClip[] videos;
    private int videoIndex;
    private AudioSource som;
    public AudioClip sombotao;

    [SerializeField]
    private GameObject tabela;

    [SerializeField]
    private GameObject nomeTema;

    [SerializeField]
    private GameObject bancoDados;

    [SerializeField]
    private GameObject popUpVazio;



    // Start is called before the first frame update
    void Start()
    {

        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }


    //Este bloco de códigos contém todos os códigos responsáveis por mudança de cenas.


    public void telaInicial()   // transição entre a tela inicial e a tela do tabuleiro do jogo
    {
        //        som.clip = sombotao;
        //        som.Play();
        //       Invoke("telaInicial2", 0.65f);
        telaInicial2();
    }

    public void telaInicial2()
    {
        SceneManager.LoadScene("Começar Jogo", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)

    }

    public void telaTema()
    {
        /*        som.clip = sombotao;
                som.Play();
                Invoke("telaTema2", 0.65f);*/
        telaTema2();

    }

    public void telaTema2()
    {
        SceneManager.LoadScene("Criação de temas", LoadSceneMode.Single);
    }




    public void CriarPerguntas()  //  transição entre a tela inicial e a tela onde será criado o tema do txt.
    {
        /*        som.clip = sombotao;
                som.Play();
                Invoke("CriarPerguntas2", 0.65f);
          */

        if (BancoDeDados.contarTemas() == 0)
            telaTema2();
        else
            CriarPerguntas2();
    }

    public void CriarPerguntas2()
    {
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }

    public void tabuleiro()     //  transição de tela para sair do HUD Pessoal e voltar para o tabuleiro
    {
        som.clip = sombotao;
        som.Play();
        Invoke("tabuleiro2", 0.65f);

    }

    public void tabuleiro2()
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }

    public void inserirTema()
    {
        if (String.IsNullOrWhiteSpace(nomeTema.GetComponent<InputField>().text))
        {
            popUpVazio.GetComponent<popUp_temaVazio>().mostrarPopUp();
        }
        else
        {
            //            som.clip = sombotao;
            //           som.Play();
<<<<<<< Updated upstream
            tema = GameObject.Find("NomeDoTema").GetComponent<InputField>();
            BancoDeDados.inserirTema(tema);
=======
            tema = nomeTema.GetComponent<InputField>();
            bancoDados.GetComponent<BancoDeDados>().inserirTema(tema);
            tabela.GetComponent<tabelaDosTemas>().set_inicio(0);
            int pag = (int) Math.Ceiling(Decimal.Divide(tabela.GetComponent<tabelaDosTemas>().get_qtd_temas() + 1, 5));
            tabela.GetComponent<tabelaDosTemas>().set_PaginaTabela(pag);
            tabela.GetComponent<tabelaDosTemas>().preencherTemas("");
>>>>>>> Stashed changes
        }


    }

    public void Sair()
    {
        Application.Quit();
    }

    /*public void somBotao() { 
        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        som.clip = clip;
        som.Play();
    }*/


    // Update is called once per frame
    void Update()
    {

    }




}
