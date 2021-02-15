using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inserirPergunta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inserirPergunt(){
        GameObject.Find("Valor_slider").GetComponent<slider_value>().inserirPergunta();
    }

}
