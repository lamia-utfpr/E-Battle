using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class popUp_temaInserido : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioTemaInserido;

    [SerializeField]
    private GameObject fundoMenu;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject temaInserido;

    private Text texto;

    [SerializeField]
    private bool naTela = false;

    [SerializeField]
    private float tempoTela = 3.0f;


    void Start()
    {

    }

    // Update is called once per frame


    public bool get_naTela()
    {
        return naTela;
    }

    // Update is called once per frame
    void Update()
    {

        if (naTela)
        {
            removerTela();
        }

    }

    public void removerTela()
    {
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;

        }
        else
        {
            texto.text = "";
            naTela = false;
            tempoTela = 3.0f;
            alerta.transform.position = fundoMenu.transform.position + new Vector3(-2000, 0, 1);
        }
    }

    public void mostrarPopUp()
    {
        if (!naTela)
        {
            alerta.GetComponentInChildren<Text>().text = "Tema inserido com sucesso";
            alerta.transform.position = fundoMenu.transform.position + new Vector3(0, 0, 1);

            texto = temaInserido.GetComponent<Text>();
            texto.text = "";
            naTela = true;
            audioTemaInserido.Play();
        }

    }

}
