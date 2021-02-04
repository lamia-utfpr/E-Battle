using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusearPerguntaComTodasCorretas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void inserirPerguntaComTodasAltCorretas(){
        GameObject.Find("Valor_slider").GetComponent<slider_value>().inserirPerguntaComTodasCorretas();
    }

    public void NaoInserirPerguntaComTodasCorretas(){
        GameObject.Find("Valor_slider").GetComponent<slider_value>().NaoInserirPerguntaComTodasCorretas();
    }
}
