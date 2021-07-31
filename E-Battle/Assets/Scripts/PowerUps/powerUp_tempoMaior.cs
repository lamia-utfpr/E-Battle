using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp_tempoMaior
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void aumentarTempo(){
        apresentarPergunta.setTempoAtual(GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getTempoAtual() + 30);
    }


}
