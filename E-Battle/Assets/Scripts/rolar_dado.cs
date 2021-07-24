using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rolar_dado : MonoBehaviour
{
    // Start is called before the first frame update

    private int numLados;
    private bool dadoAnimando = false;
    private bool numeroMostrado = false;
    private float tempoAnimando;
    private float tempoTela = 3f;

    private int numeroTirado;

    void Start()
    {
        if (this.name == "DadoD6")
            numLados = 6;
        else if (this.name == "DadoD8")
            numLados = 8;



    }

    // Update is called once per frame
    void Update()
    {
        if (dadoAnimando)
        {
            //rodar a animação
            removerTela();
        }
        else
        {
            //parar a animação
        }

        if (numeroMostrado)
            removerTelaNumero();

    }

    public void jogar()
    {
        if (!dadoAnimando)
        {

            dadoAnimando = true;
            tempoAnimando = UnityEngine.Random.Range(3, 6);
            this.GetComponent<Button>().interactable = false;
            Debug.Log("RODANDO");
        }
    }

    public void removerTela()
    {
        if (tempoAnimando > 1)
        {
            tempoAnimando -= Time.deltaTime;
        }
        else
        {
            tempoAnimando = Random.Range(3, 6);
            dadoAnimando = false;
            numeroTirado = Random.Range(1, numLados + 1);
            GameObject.Find("valor_dado").GetComponent<Text>().text = "" + numeroTirado;
            numeroMostrado = true;
        }
    }

    public void removerTelaNumero()
    {
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("rolarDado").GetComponent<mostrarDado>().retirarDado();
            GameObject.Find("Players").GetComponent<MvP1>().moverNovo(numeroTirado);
            GameObject.Find("valor_dado").GetComponent<Text>().text = "";
            this.GetComponent<Button>().interactable = true;
            tempoTela = 3f;
            numeroMostrado = false;
        }
    }


}
