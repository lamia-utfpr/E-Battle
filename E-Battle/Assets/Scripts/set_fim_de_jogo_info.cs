using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class set_fim_de_jogo_info : MonoBehaviour
{
    // Start is called before the first frame update

    private static Color[] players;

    void Start()
    {
        for (int i = 0; i < players.Length; i++)
            GameObject.Find("posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = players[i];

        for (int i = players.Length; i < 4; i++)
        {
            GameObject.Find("posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GameObject.Find("coroa_posicao_" + (i + 1)).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }


    }

    public static void setPlayers(Color[] vetor)
    {
        players = vetor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
