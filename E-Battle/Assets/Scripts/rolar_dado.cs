using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rolar_dado : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    private int numLados;
    private bool dadoAnimando = false;
    private bool numeroMostrado = false;
    private float tempoAnimando;
    private float tempoTela = 3f;

    private int numeroTirado;

    [SerializeField]
    private AudioSource som;

    public AudioClip rolar;

    [SerializeField]
    private GameObject valorDado;

    [SerializeField]
    private GameObject telaDado;

    [SerializeField]
    private GameObject RolaDado;

    [SerializeField]
    private GameObject players;

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
            anim.SetBool("isStop", false);
            anim.SetBool("isRool", true);
            removerTela();
        }
        else
        {
            //parar a animação
            anim.SetBool("isRool", false);
        }

        if (numeroMostrado)
            removerTelaNumero();
            //anim.SetBool("isStop", true);

    }

    public void jogar()
    {
        //som.clip = rolar;
        som.loop = true;
        som.Play();

        if (!dadoAnimando)
        {
            valorDado.transform.position = telaDado.transform.position;
            dadoAnimando = true;
            tempoAnimando = 5;
            //tempoAnimando = UnityEngine.Random.Range(3, 6);
            this.GetComponent<Button>().interactable = false;
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
            valorDado.GetComponent<Text>().text = "" + numeroTirado;
            numeroMostrado = true;
            som.loop = false;
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
            RolaDado.GetComponent<mostrarDado>().retirarDado();
            players.GetComponent<MvP1>().moverNovo(numeroTirado);
            valorDado.GetComponent<Text>().text = "";
            valorDado.transform.position = new Vector3(3000, 0, 0);
            this.GetComponent<Button>().interactable = true;
            tempoTela = 3f;
            numeroMostrado = false;
            anim.SetBool("isStop", true);
        }
    }


}
