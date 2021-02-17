using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarCasas : MonoBehaviour
{
    // Start is called before the first frame update

    private static bool temPowerUp = false;
    private string nome_powerup;

    void Start()
    {

    }

    public void set_nomePowerUp(string nome){
        nome_powerup = nome;
    }

    public string get_nomePowerUp(){
        return nome_powerup;
    }

    public bool getTemPowerUp(){
        return temPowerUp;
    }

    public void setTemPowerUp(bool x){
        temPowerUp = x;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
