using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private static string texto;


    void Start()
    {
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "Turno do grupo " + texto;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public static void setPlayer(string name){
        texto = name;
    }

    public void jogadorAtual(string jogador)
    {
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = jogador;
        
    }

    public void powerup(string powerup, int jogador)
    {
        GameObject.Find("ControleTurno/HUD").GetComponent<Text>().text = "O jogador " + jogador + " Recebeu o powerup de: " + powerup;
    }

}
