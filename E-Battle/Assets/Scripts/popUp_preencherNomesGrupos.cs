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

    public static void removerTela()
    {
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;

        }
        else
        {
            GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "";
            naTela = false;
            tempoTela = 3.0f;
        }
    }

    public static void mostrarPopUp()
    {
        if (!naTela)
        {
            GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().text = "Preencha todos os nomes dos grupos!";
            GameObject.Find("preencherTodosOsNomes").GetComponent<Text>().color = Color.red;
            naTela = true;
        }

    }
}
