using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp_empurrarOutroPlayer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void empurrar(){
        GameObject.Find("tabela_players").GetComponent<setarTabelaPlayers>().transform.position = GameObject.Find("painel_Pergunta").transform.position + new Vector3(0, 300, 0);
        GameObject.Find("tabela_players").GetComponent<setarTabelaPlayers>().setarAcao(0);
    }


}
