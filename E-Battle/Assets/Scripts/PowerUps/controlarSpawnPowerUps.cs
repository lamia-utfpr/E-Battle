using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlarSpawnPowerUps : MonoBehaviour
{
    // Start is called before the first frame update

    private static int intervalo_entre_casas;
    private static int casa_atual = 0;
    private int quantia_casas = 18;
    private int quantia_powerups = 5;
    private string[] nome_powerups;

    void Start()
    {
        //power ups disponíveis durante a partida

        nome_powerups = new string[quantia_powerups];
        nome_powerups[0] = "Aumentar tempo";
        nome_powerups[1] = "Dado maior";
        nome_powerups[2] = "Dado maior 2";
        nome_powerups[3] = "Dado maior 3";
        nome_powerups[4] = "Dado maior 4";

        //a distancia entre cada power up, no caso, quantas casas o player tem que percorrer pra pegar o próximo power up

        //intervalo_entre_casas = Random.Range(3, 5);
        intervalo_entre_casas = 2;
        preencherCasas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        //função que preenche as casas do tabuleiro de acordo com a quantia existente, exclui a casa inicial e a casa final na hora de preencher.

    private void preencherCasas(){
        for (int i = 1; i <= quantia_casas; i++){
            
            //esse if verifica se a casa atual deve ter um power up de acordo com o intervalo definido na função Start(), e caso deva ter, então é procurado o objeto com o nome da casa
            //e suas variáveis são alteradas, as variáveis são "temPowerUp" e "nomePowerUp". Após definir os valores para as casas, as variáveis responsáveis por verificar se a casa deve
            //ou não ter um power up são resetadas


            if (casa_atual == intervalo_entre_casas){
                GameObject.Find("casa " + i).GetComponent<GerenciarCasas>().setTemPowerUp(true);
                GameObject.Find("casa " + i).GetComponent<GerenciarCasas>().set_nomePowerUp(nome_powerups[Random.Range(0, quantia_powerups-1)]);

                Debug.Log(GameObject.Find("casa " + i).name + GameObject.Find("casa " + i).GetComponent<GerenciarCasas>().get_nomePowerUp());

                casa_atual = 0;
                intervalo_entre_casas = Random.Range(3, 5);
                intervalo_entre_casas = 2;
            }

            casa_atual++;
        }
    }

   

}
