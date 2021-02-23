using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;



public class apresentarInfoPlayerAtual : MonoBehaviour
{
    // Start is called before the first frame update

    private Text powerup1;
    private Text powerup2;
    private Text powerup3;
    private Text[] powerupsNomes;
    
    
    
    private Text nomePlayer;



    void Start()
    {
        
        powerupsNomes = new Text[3];
        
        powerup1 = GameObject.Find("powerUpsPossuidos/powerUp1").GetComponent<Text>();
        powerup2 = GameObject.Find("powerUpsPossuidos/powerUp2").GetComponent<Text>();
        powerup3 = GameObject.Find("powerUpsPossuidos/powerUp3").GetComponent<Text>();
        nomePlayer = GameObject.Find("nomePlayer").GetComponent<Text>();

    
        powerup1.text = ""; 
        powerup2.text = "";
        powerup3.text = "";
        nomePlayer.text = "";
    
        powerupsNomes[0] = powerup1;
        powerupsNomes[1] = powerup2;
        powerupsNomes[2] = powerup3;
    
    
    }  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarInformacoes(){
        

        GameObject player = GameObject.Find("Players").GetComponent<MvP1>().getJogAtual();
        List<string> powerups = player.GetComponent<gerenciarPowerUpsPlayer>().getListaPowerUps();

        Debug.Log("Quantia de power ups do " + player.name + ": " + powerups.Count);
        
        /*
        if (powerups.Count == 1)
            powerup1.text = powerups[0];
        else if (powerups.Count == 2){
            powerup1.text = powerups[0];
            powerup2.text = powerups[1];
        }
            
        else if (powerups.Count == 3){
            powerup1.text = powerups[0];
            powerup2.text = powerups[1];
            powerup3.text = powerups[2];
        }
        */ 
        
        
        for (int i = 0; i < powerups.Count; i++){
            powerupsNomes[i].text = powerups[i];
        }

        nomePlayer.text = player.name;
    } 

    public void zerarHUD(){
        GameObject player = GameObject.Find("Players").GetComponent<MvP1>().getJogAtual();
        List<string> powerups = player.GetComponent<gerenciarPowerUpsPlayer>().getListaPowerUps();

        


        for (int i = 0; i < 3; i++){
            powerupsNomes[i].text = "";
        }

        nomePlayer.text = "";
    }

}
