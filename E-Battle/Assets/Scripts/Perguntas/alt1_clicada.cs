using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alt1_clicada : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject painel;
    [SerializeField]
    private int alt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void registrarResposta(){
        //GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().usuarioRespondeu(1);
        painel.GetComponent<apresentarPergunta>().usuarioRespondeu(alt);
    }
}
