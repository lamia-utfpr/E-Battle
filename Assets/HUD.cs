using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject[] players;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void jogadorAtual(int jogador)
    {
        texto.text = "Turno do Jogador " + jogador;
    }

    public void powerup(string powerup,int jogador)
    {
        texto.text = "O jogador " + jogador + " Recebeu o powerup de: " + powerup;
    }

}
