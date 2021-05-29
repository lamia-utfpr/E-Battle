using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jogadorAtualHUDTabuleiro : MonoBehaviour
{
    // Start is called before the first frame update

    private static string texto;

    void Start()
    {
        GameObject.Find("jogador_atual_info").GetComponent<Text>().text = "Jogador atual: " + texto;
    }

    public static void setJogadorAtualHUDTabuleiro(string name)
    {
        texto = name;
    }

    public void jogadorAtual(string jogador)
    {
        GameObject.Find("jogador_atual_info").GetComponent<Text>().text = "Jogador atual: " + texto;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
