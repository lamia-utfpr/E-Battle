using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class popUp_pergunta : MonoBehaviour
{
    // Start is called before the first frame update
    private static int op;
    private static bool moving = false;

    private static bool mostrarTexto = false;

    private static float tempoTela = 4f;

    private static int popUpSpeed;
    public static bool tempoAcabou = false;

    public AudioClip audioCerto;
    public AudioClip audioErrado;

    [SerializeField]
    private AudioSource som;

    public Animator anim;

    [SerializeField]
    private GameObject painel;

    [SerializeField]
    private GameObject fundoFeedback;

    [SerializeField]
    private GameObject botaoFeedback;

    [SerializeField]
    private GameObject textoFeedback;

    [SerializeField]
    private GameObject cameraTab;

    [SerializeField]
    private GameObject rolarDado;

    [SerializeField]
    private GameObject controlador;

    public static void set_op(int opcao)
    {
        op = opcao;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuaisSize() >= 2)
        {
            if (Vector3.Distance(GameObject.Find("fundo_feedback_da_resposta").transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(700, -350, 1)) < 1000f)
            {
                popUpSpeed = 400;
=======
        if (painel != null)
            if (painel.GetComponent<apresentarPergunta>().getAlternativasAtuaisSize() >= 2)
            {
                if (Vector3.Distance(fundoFeedback.transform.position, cameraTab.transform.position + new Vector3(700, -350, 1)) < 1000f)
                {
                    popUpSpeed = 400;
                }
                else
                    popUpSpeed = 2000;
>>>>>>> Stashed changes
            }
            else
                popUpSpeed = 2000;
        }
        else
            popUpSpeed = 700;

        if (moving)
        {
            anim.SetBool("default", true);
            anim.SetBool("acerto", false);
            anim.SetBool("erro", false);
            botaoFeedback.GetComponent<Button>().interactable = false;
            botaoFeedback.GetComponentInChildren<Text>().text = " ";
            fundoFeedback.transform.position = Vector3.MoveTowards(fundoFeedback.transform.position, cameraTab.transform.position + new Vector3(700, -350, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(fundoFeedback.transform.position, cameraTab.transform.position + new Vector3(700, -350, 1)) < 0.001f)
            {
                moving = false;

                if (painel.GetComponent<apresentarPergunta>().getAlternativasAtuaisSize() >= 2)
                    mostrarTexto = true;
                else
                    mostrarTextoPerguntaAberta();

            }
        }

        if (mostrarTexto)
            mostrarTextoDoFeedback();

    }

    private void mostrarTextoDoFeedback()
    {
        anim.SetBool("default", true);
        anim.SetBool("acerto", false);
        anim.SetBool("erro", false);
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;
        }
        else
        {
            mostrarTexto = false;
            tempoTela = 4f;
            botaoFeedback.GetComponent<Button>().interactable = true;
            botaoFeedback.GetComponentInChildren<Text>().text = "Continuar";
            if (op == 1)
            {
                textoFeedback.GetComponent<Text>().text = "Parabéns, você acertou!";
                anim.SetBool("erro", false);
                anim.SetBool("acerto", true);
                //  som.clip = audioCerto;
                //     som.Play();

            }
            else if (op == 0)
            {
                textoFeedback.GetComponent<Text>().text = "Que pena, a resposta está incorreta!";
                anim.SetBool("acerto", false);
                anim.SetBool("erro", true);
                //  som.clip = audioErrado;
                //  som.Play();

                if (tempoAcabou)
                {
                    textoFeedback.GetComponent<Text>().text = "Que pena, seu tempo acabou!";
                    anim.SetBool("acerto", false);
                    anim.SetBool("erro", true);
                    //     som.clip = audioErrado;
                    //     som.Play();
                }
            }
        }
    }

    private void mostrarTextoPerguntaAberta()
    {
        if (op == 1)
        {
            textoFeedback.GetComponent<Text>().text = "Parabéns, você acertou!";
            anim.SetBool("erro", false);
            anim.SetBool("acerto", true);
            //  som.clip = audioCerto;
            //  som.Play();
        }
        else if (op == 0)
        {
            textoFeedback.GetComponent<Text>().text = "Que pena, a resposta está incorreta!";
            anim.SetBool("acerto", false);
            anim.SetBool("erro", true);
            //  som.clip = audioErrado;
            //   som.Play();
            if (tempoAcabou)
            {
                textoFeedback.GetComponent<Text>().text = "Que pena, seu tempo acabou!";
                anim.SetBool("acerto", false);
                anim.SetBool("erro", true);
                //som.clip = audioErrado;
                // som.Play();
            }
        }
        botaoFeedback.GetComponent<Button>().interactable = true;
        botaoFeedback.GetComponentInChildren<Text>().text = "Continuar";
    }

    public void mostrarPopUp()
    {
        moving = true;
        textoFeedback.GetComponent<Text>().text = "";
        painel.GetComponent<apresentarPergunta>().desabilitarAlternativas();
    }

    public void continuar()
    {
        if (op == 1)
        {
            rolarDado.GetComponent<mostrarDado>().mover(1);
        }
        else if (op == 0)
        {
            controlador.GetComponent<MvP1>().passarVez();
        }

        tempoAcabou = false;
        painel.transform.position = cameraTab.transform.position + new Vector3(0, 2000, 0);
        painel.GetComponent<apresentarPergunta>().set_pergAtual(painel.GetComponent<apresentarPergunta>().get_pergAtual() + 1);
        painel.GetComponent<apresentarPergunta>().reiniciarComponentes();

        if (apresentarPergunta.get_texto_pergunta().Count == painel.GetComponent<apresentarPergunta>().get_pergAtual())
            apresentarPergunta.aleatorizarPorFora();

        GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().mostrarPergunta();
    }

}
