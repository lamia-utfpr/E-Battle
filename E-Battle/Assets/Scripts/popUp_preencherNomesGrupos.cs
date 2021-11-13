using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_preencherNomesGrupos : MonoBehaviour
{
    private static Text texto;
    private static bool naTela = false;
    private static float tempoTela = 3.0f;
    private static AudioSource audioTemaInserido;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject fundoMenu;


    void Start()
    {

    }

    // Update is called once per frame


    public static bool get_naTela()
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

            naTela = false;
            tempoTela = 3.0f;
            alerta.transform.position = fundoMenu.transform.position + new Vector3(-2000, 0, 1);
        }
    }

    public void mostrarPopUp(int op)
    {
        if (!naTela)
        {
            if (op == 0)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Preencha todos os nomes dos grupos!";
                alerta.GetComponentInChildren<Text>().text = "Preencha todos os nomes dos grupos!";
                alerta.transform.position = fundoMenu.transform.position + new Vector3(0, 0, 1);
            }
            else if (op == 1)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Selecione um tema!";
                alerta.GetComponentInChildren<Text>().text = "Selecione um tema!";
                alerta.transform.position = fundoMenu.transform.position + new Vector3(0, 0, 1);
            }
            else if (op == 2)
            {
                //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Não é possível começar a partida com nomes repetidos!";
                alerta.GetComponentInChildren<Text>().text = "Não é possível começar a partida com nomes repetidos!";
                alerta.transform.position = fundoMenu.transform.position + new Vector3(0, 0, 1);

            }
            //GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().color = Color.red;
            naTela = true;
        }

    }
}
