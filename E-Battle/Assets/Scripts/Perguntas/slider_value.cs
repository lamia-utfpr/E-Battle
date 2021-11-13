using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class slider_value : MonoBehaviour
{

    [SerializeField]
    private GameObject confirma;

    [SerializeField]
    private Slider sliderUI;

    [SerializeField]
    private Text Valor_slider;

    [SerializeField]
    private InputField pergunta;


    //Bloco de variaveis da 1 caixa
    [SerializeField]
    private InputField input1;

    [SerializeField]
    private Text placeholder1;

    [SerializeField]
    private Text texto_usuario1;

    [SerializeField]
    private Toggle resp_correta1;




    //Bloco de variaveis da 2 caixa
    [SerializeField]
    private InputField input2;

    [SerializeField]
    private Text placeholder2;

    [SerializeField]
    private Text texto_usuario2;

    [SerializeField]
    private Toggle resp_correta2;




    //Bloco de variaveis da 3 caixa
    [SerializeField]
    private InputField input3;

    [SerializeField]
    private Text placeholder3;

    [SerializeField]
    private Text texto_usuario3;

    [SerializeField]
    private Toggle resp_correta3;




    //Bloco de variaveis da 4 caixa
    [SerializeField]
    private InputField input4;

    [SerializeField]
    private Text placeholder4;

    [SerializeField]
    private Text texto_usuario4;

    [SerializeField]
    private Toggle resp_correta4;




    //parte sobre não ter alternativa correta
    [SerializeField]
    private Text sem_alternativacorreta;

    [SerializeField]
    private Button sem_alternativacorretaNAO;

    [SerializeField]
    private Button sem_alternativacorretaSIM;


    //parte sobre todas serem corretas
    [SerializeField]
    private Text todas_alternativassaocorretas;

    [SerializeField]
    private Button todas_alternativassaocorretasNAO;

    [SerializeField]
    private Button todas_alternativassaocorretasSIM;


    //texto que aparece caso a pergunta esteja vazia
    [SerializeField]
    private Text perguntaVazia;

    //nome do tema selecionado
    [SerializeField]
    private Text nomeTemaSelecionado;

    [SerializeField]
    private Color color = Color.black;

    [SerializeField]
    private Color cor_checkbox = Color.white;

    [SerializeField]
    private int qtd_alternativas = 0;

    [SerializeField]
    private int qtd_certas;

    [SerializeField]
    private Text tema_vazio;

    [SerializeField]
    private GameObject codTema;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject menu;

    void Start()
    {
        Valor_slider = GetComponent<Text>();
        Valor_slider.text = "Quantidade de alternativas: 0";
        color.a = 0;


        sem_alternativacorreta.color = Color.black;
        sem_alternativacorreta.text = "";
        sem_alternativacorretaSIM.gameObject.SetActive(false);
        sem_alternativacorretaNAO.gameObject.SetActive(false);

        todas_alternativassaocorretas.color = Color.black;
        todas_alternativassaocorretas.text = "";
        todas_alternativassaocorretasSIM.gameObject.SetActive(false);
        todas_alternativassaocorretasNAO.gameObject.SetActive(false);

        tema_vazio.GetComponent<Text>().text = "";

        perguntaVazia.color = Color.black;
        perguntaVazia.text = "";

        //perguntaInserida.text = "";

        statusInput1(0);
        statusInput2(0);
        statusInput3(0);
        statusInput4(0);

    }

    public void ShowSliderValue()
    {
        string sliderMessage = "Quantidade de alternativas: " + sliderUI.value;
        Valor_slider.text = sliderMessage;
        setActive(sliderUI.value);
        todas_alternativassaocorretas.text = "";
        todas_alternativassaocorretasSIM.gameObject.SetActive(false);
        todas_alternativassaocorretasNAO.gameObject.SetActive(false);

        sem_alternativacorreta.text = "";
        sem_alternativacorretaSIM.gameObject.SetActive(false);
        sem_alternativacorretaNAO.gameObject.SetActive(false);


        //perguntaInserida.text = "";
    }

    void update()
    {
        ShowSliderValue();
    }


    public void inserirPerguntaComTodasCorretas()
    {
        int[] respostas = new int[4];
        respostas = verificaBotao();

        int cod_tema = codTema.GetComponent<selecionar_tema>().get_tema();

        if (cod_tema > 0)
        {
            BancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);
        }
        else
        {
            alerta.GetComponentInChildren<Text>().text = "Pergunta vazia, insira algo!";
            alerta.transform.position = menu.transform.position + new Vector3(0, 0, 1);
        }

        todas_alternativassaocorretas.text = "";
        todas_alternativassaocorretasSIM.gameObject.SetActive(false);
        todas_alternativassaocorretasNAO.gameObject.SetActive(false);


        pergunta.text = "";
        input1.text = "";
        input2.text = "";
        input3.text = "";
        input4.text = "";
        resp_correta1.isOn = false;
        resp_correta2.isOn = false;
        resp_correta3.isOn = false;
        resp_correta4.isOn = false;

        confirma.GetComponent<mostrarConfirmacao>().mostrar();
    }


    public void NaoInserirPerguntaComTodasCorretas()
    {
        todas_alternativassaocorretas.text = "";
        todas_alternativassaocorretasSIM.gameObject.SetActive(false);
        todas_alternativassaocorretasNAO.gameObject.SetActive(false);
    }

    public void inserirPerguntaSemAlternativaCorreta()
    {
        int[] respostas = new int[4];
        respostas = verificaBotao();

        int cod_tema = codTema.GetComponent<selecionar_tema>().get_tema();
        BancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);


        sem_alternativacorreta.text = "";
        sem_alternativacorretaSIM.gameObject.SetActive(false);
        sem_alternativacorretaNAO.gameObject.SetActive(false);

        pergunta.text = "";
        input1.text = "";
        input2.text = "";
        input3.text = "";
        input4.text = "";

        resp_correta1.isOn = false;
        resp_correta2.isOn = false;
        resp_correta3.isOn = false;
        resp_correta4.isOn = false;

        confirma.GetComponent<mostrarConfirmacao>().mostrar();

    }


    public void naoInserirPerguntaSemAlternativaCorreta()
    {
        sem_alternativacorreta.text = "";
        sem_alternativacorretaSIM.gameObject.SetActive(false);
        sem_alternativacorretaNAO.gameObject.SetActive(false);
    }

    public void inserirPergunta()
    {
        sem_alternativacorreta.color = Color.black;
        sem_alternativacorreta.text = "";
        sem_alternativacorretaSIM.gameObject.SetActive(false);
        sem_alternativacorretaNAO.gameObject.SetActive(false);

        todas_alternativassaocorretas.color = Color.black;
        todas_alternativassaocorretas.text = "";
        todas_alternativassaocorretasSIM.gameObject.SetActive(false);
        todas_alternativassaocorretasNAO.gameObject.SetActive(false);

        int[] respostas = new int[4];
        respostas = verificaBotao();
        qtd_alternativas = (int)sliderUI.value;

        int cod_tema = codTema.GetComponent<selecionar_tema>().get_tema();

        if (String.IsNullOrWhiteSpace(pergunta.text))
        {    //verifica se a pergunta está vazia
            //perguntaVazia.color = Color.red;
            //perguntaVazia.text = "Pergunta vazia, insira algo!";
            alerta.GetComponentInChildren<Text>().text = "Pergunta vazia, insira algo!";
            alerta.transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);
        }

        else
        {
            perguntaVazia.text = "";

            if (qtd_alternativas == qtd_certas && qtd_certas > 1)
            {
                todas_alternativassaocorretas.text = "Tem certeza que todas as alternativas são corretas?";
                todas_alternativassaocorretasSIM.gameObject.SetActive(true);
                todas_alternativassaocorretasNAO.gameObject.SetActive(true);
            }
            else if (
              (qtd_alternativas == 1 && respostas[0] == 0) ||
              (qtd_alternativas == 2 && respostas[0] == 0 && respostas[1] == 0) ||
              (qtd_alternativas == 3 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0) ||
              (qtd_alternativas == 4 && respostas[0] == 0 && respostas[1] == 0 && respostas[2] == 0 && respostas[3] == 0)
            )
            {

                if (cod_tema < 0)
                {
                    //tema_vazio.text = "Selecione um tema para inserir a pergunta!";
                    //tema_vazio.color = new Color(0, 0, 0, 1);
                    alerta.GetComponentInChildren<Text>().text = "Selecione um tema para inserir a pergunta!";
                    alerta.transform.position = menu.transform.position + new Vector3(0, 0, 1);
                }
                else
                {
                    //tema_vazio.color = new Color(0, 0, 0, 0);
                    alerta.transform.position = menu.transform.position + new Vector3(-2000, 0, 1);
                    sem_alternativacorreta.text = "Tem certeza que deseja adicionar uma pergunta sem alternativa correta?";
                    sem_alternativacorretaSIM.gameObject.SetActive(true);
                    sem_alternativacorretaNAO.gameObject.SetActive(true);

                }


            }
            else
            {


                if (cod_tema > 0)
                {
                    BancoDeDados.inserirPergunta(pergunta, input1, input2, input3, input4, respostas, cod_tema);
                    //perguntaInserida.color = Color.black;
                    perguntaVazia.text = "";

                    //tema_vazio.text = "";
                    alerta.transform.position = menu.transform.position + new Vector3(-2000, 0, 1);

                    pergunta.text = "";
                    input1.text = "";
                    input2.text = "";
                    input3.text = "";
                    input4.text = "";
                    resp_correta1.isOn = false;
                    resp_correta2.isOn = false;
                    resp_correta3.isOn = false;
                    resp_correta4.isOn = false;

                    confirma.GetComponent<mostrarConfirmacao>().mostrar();
                }
                else
                {
                    //tema_vazio.text = "Selecione um tema para inserir a pergunta!";
                    //tema_vazio.color = new Color(0, 0, 0, 1);
                    alerta.GetComponentInChildren<Text>().text = "Selecione um tema para inserir a pergunta!";
                    alerta.transform.position = menu.transform.position + new Vector3(0, 0, 1);
                }


            }

        }


    }

    void setActive(float valor_slider)
    {

        switch ((int)valor_slider)
        {
            case 0:
                statusInput1(0);
                statusInput2(0);
                statusInput3(0);
                statusInput4(0);
                break;

            case 1:
                statusInput1(1);
                statusInput2(0);
                statusInput3(0);
                statusInput4(0);
                break;

            case 2:
                statusInput1(1);
                statusInput2(1);
                statusInput3(0);
                statusInput4(0);
                break;

            case 3:
                statusInput1(1);
                statusInput2(1);
                statusInput3(1);
                statusInput4(0);
                break;

            case 4:

                statusInput1(1);
                statusInput2(1);
                statusInput3(1);
                statusInput4(1);
                break;
        }
    }


    private void statusInput1(int op)
    {

        //input inativo
        if (op == 0)
        {
            placeholder1.text = "";
            input1.interactable = false;
            input1.text = "";
            resp_correta1.interactable = false;
            resp_correta1.GetComponentInChildren<Text>().color = color;
            resp_correta1.GetComponentInChildren<Image>().color = color;
            resp_correta1.isOn = false;

        }

        //input ativo
        if (op == 1)
        {
            placeholder1.text = "Alternativa 1";
            input1.interactable = true;
            texto_usuario1.color = Color.black;
            resp_correta1.interactable = true;
            resp_correta1.GetComponentInChildren<Text>().color = Color.black;
            resp_correta1.GetComponentInChildren<Image>().color = cor_checkbox;
        }
    }

    private void statusInput2(int op)
    {

        //input inativo

        if (op == 0)
        {
            placeholder2.text = "";
            input2.interactable = false;
            input2.text = "";
            resp_correta2.interactable = false;
            resp_correta2.GetComponentInChildren<Text>().color = color;
            resp_correta2.GetComponentInChildren<Image>().color = color;
            resp_correta2.isOn = false;
        }

        //input ativo

        if (op == 1)
        {
            placeholder2.text = "Alternativa 2";
            input2.interactable = true;
            texto_usuario2.color = Color.black;
            resp_correta2.interactable = true;
            resp_correta2.GetComponentInChildren<Text>().color = Color.black;
            resp_correta2.GetComponentInChildren<Image>().color = cor_checkbox;
        }
    }

    private void statusInput3(int op)
    {
        //input inativo

        if (op == 0)
        {
            placeholder3.text = "";
            input3.interactable = false;
            input3.text = "";
            resp_correta3.interactable = false;
            resp_correta3.GetComponentInChildren<Text>().color = color;
            resp_correta3.GetComponentInChildren<Image>().color = color;
            resp_correta3.isOn = false;
        }

        //input ativo

        if (op == 1)
        {
            placeholder3.text = "Alternativa 3";
            input3.interactable = true;
            texto_usuario3.color = Color.black;
            resp_correta3.interactable = true;
            resp_correta3.GetComponentInChildren<Text>().color = Color.black;
            resp_correta3.GetComponentInChildren<Image>().color = cor_checkbox;
        }
    }

    private void statusInput4(int op)
    {
        //input inativo

        if (op == 0)
        {
            placeholder4.text = "";
            input4.interactable = false;
            input4.text = "";
            resp_correta4.interactable = false;
            resp_correta4.GetComponentInChildren<Text>().color = color;
            resp_correta4.GetComponentInChildren<Image>().color = color;
            resp_correta4.isOn = false;
        }

        //input ativo

        if (op == 1)
        {
            placeholder4.text = "Alternativa 4";
            input4.interactable = true;
            texto_usuario4.color = Color.black;
            resp_correta4.interactable = true;
            resp_correta4.GetComponentInChildren<Text>().color = Color.black;
            resp_correta4.GetComponentInChildren<Image>().color = cor_checkbox;
        }
    }


    public int[] verificaBotao()
    {
        qtd_certas = 0;
        int[] respostas = new int[4];

        if (resp_correta1.isOn)
        {
            respostas[0] = 1;
            qtd_certas++;
        }
        else
        {
            respostas[0] = 0;
        }

        if (resp_correta2.isOn)
        {
            respostas[1] = 1;
            qtd_certas++;
        }
        else
        {
            respostas[1] = 0;
        }

        if (resp_correta3.isOn)
        {
            respostas[2] = 1;
            qtd_certas++;
        }
        else
        {
            respostas[2] = 0;
        }

        if (resp_correta4.isOn)
        {
            respostas[3] = 1;
            qtd_certas++;
        }
        else
        {
            respostas[3] = 0;
        }


        return respostas;
    }



}