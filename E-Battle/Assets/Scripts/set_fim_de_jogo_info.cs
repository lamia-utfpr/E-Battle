using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class set_fim_de_jogo_info : MonoBehaviour
{
    // Start is called before the first frame update

    private static Color[] players_colors;
    private static string[] players_names;

    [SerializeField]
    private AudioSource som;
    public AudioClip comemora;

    [SerializeField]
    private GameObject[] posicao;

    [SerializeField]
    private GameObject[] coroa;

    [SerializeField]
    private GameObject[] nome;

    void Start()
    {
        for (int i = 0; i < players_colors.Length; i++)
        {
            posicao[i].GetComponent<SpriteRenderer>().color = players_colors[i];
            nome[i].GetComponent<Text>().text = players_names[i];
        }
        for (int i = players_colors.Length; i < 4; i++)
        {
            posicao[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            coroa[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            nome[i].GetComponent<Text>().text = "";
        }

        som.clip = comemora;
        som.Play();

    }

    public static void setPlayersColors(Color[] vetor)
    {
        players_colors = vetor;
    }

    public static void setPlayersNames(string[] vetor)
    {
        players_names = vetor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
