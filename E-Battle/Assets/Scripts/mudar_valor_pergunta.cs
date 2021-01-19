using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class mudar_valor_pergunta : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField pergunta;
    public Text perguntaInserida;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tirarmensagem(){
        perguntaInserida.text = "";
    }
}
