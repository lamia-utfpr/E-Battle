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
    private AudioSource som;
    public AudioClip comemora;

    void Start()
    {
        for (int i = 0; i < players_colors.Length; i++)
        {
            GameObject.Find("posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = players_colors[i];
            GameObject.Find("nome_pos" + (i + 1)).GetComponent<Text>().text = players_names[i];
        }
        for (int i = players_colors.Length; i < 4; i++)
        {
            GameObject.Find("posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GameObject.Find("coroa_posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GameObject.Find("nome_pos" + (i + 1)).GetComponent<Text>().text = "";
        }

        som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
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
