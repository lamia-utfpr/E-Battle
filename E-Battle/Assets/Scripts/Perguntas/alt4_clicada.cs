using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alt4_clicada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registrarResposta(){
        GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().usuarioRespondeu(4);
    }
}
