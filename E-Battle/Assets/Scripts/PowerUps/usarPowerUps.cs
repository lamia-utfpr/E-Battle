using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class usarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void verificarEusarPowerUp(){
        string nome = this.transform.Find("Text").GetComponent<Text>().text;

        if (String.Equals(nome, "Aumentar tempo")){
            powerUp_tempoMaior.aumentarTempo();
        }

        
        this.GetComponent<Button>().interactable = false;
    }


}
