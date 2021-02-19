using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class usarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update

    string nome;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void verificarEusarPowerUp(){
        nome = this.transform.Find("Text").GetComponent<Text>().text;

        if (String.Equals(nome, "Aumentar tempo")){
            powerUp_tempoMaior.aumentarTempo();
        }else if (String.Equals(nome, "Dado maior")){
            powerUp_dadoMaior.aumentarDado();
        }

        this.GetComponent<Button>().interactable = false;
        
        removerPowerUp();
    }


    private void removerPowerUp(){
        
        GameObject playerAtual = GameObject.Find("Players").GetComponent<MvP1>().getJogAtual();
        
        List<string> powerupsNovos = new List<string>(); 

        List<string> powerupsVelhos = new List<string>();
        powerupsVelhos = playerAtual.GetComponent<gerenciarPowerUpsPlayer>().getListaPowerUps();


        for (int i = 0; i < powerupsVelhos.Count; i++){
            if (powerupsVelhos[i] == nome){
                continue;
            }else
            {
                powerupsNovos.Add(powerupsVelhos[i]);
            }
        }

        playerAtual.GetComponent<gerenciarPowerUpsPlayer>().atualizarListaPowerUps(powerupsNovos);


    }


}
