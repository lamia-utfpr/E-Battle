using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temas_banco : MonoBehaviour{
    
    private BancoDeDados bancoDeDados = new BancoDeDados();
    

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<int, string> temas = bancoDeDados.mostrarTemas();

    }

    // Update is called once per frame
    void Update()
    {   
      
    }
}


