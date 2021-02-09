using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erroPerguntaCom1Ou0Alternativas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void errou(){
        GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().usuarioRespondeu(-5);
    }
}
