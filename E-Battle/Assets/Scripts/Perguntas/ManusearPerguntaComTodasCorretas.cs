using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusearPerguntaComTodasCorretas : MonoBehaviour
{

    [SerializeField]
    private GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void inserirPerguntaComTodasAltCorretas(){
        slider.GetComponent<slider_value>().inserirPerguntaComTodasCorretas();
    }

    public void NaoInserirPerguntaComTodasCorretas(){
        slider.GetComponent<slider_value>().NaoInserirPerguntaComTodasCorretas();
    }
}
