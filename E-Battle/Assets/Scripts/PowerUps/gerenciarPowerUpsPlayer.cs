using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gerenciarPowerUpsPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private List<string> powerups; 

    void Start()
    {
        powerups = new List<string>();
    }

    public List<string> getListaPowerUps(){
        return powerups;
    }

    public void atualizarListaPowerUps(List<string> listaNova){
        powerups = listaNova;
    }

    public void addPowerUp(string nome){
        powerups.Add(nome);
    }

    public void verificarObtencaoDePowerUp(int casa){
        if (GameObject.Find("casa " + casa)){
            if (GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().getTemPowerUp() ){

                addPowerUp(GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().get_nomePowerUp());
                GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().tirarPowerUp();
                
                Debug.Log(this.name + " pegou um power up! Ele caiu na casa " + casa);


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
