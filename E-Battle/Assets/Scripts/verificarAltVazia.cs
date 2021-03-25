using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class verificarAltVazia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void verificar(){
        InputField inputfield = GameObject.Find(this.name).GetComponent<InputField>();

        if (inputfield.interactable){
            if (String.IsNullOrWhiteSpace(inputfield.text)){
                GameObject.Find("texto_alternativaVazia").GetComponent<Text>().text = "Preencha todas as alternativas!";
                GameObject.Find("Adicionar Pergunta").GetComponent<inserirPergunta>().set_altVazia(true);
            }else{
                GameObject.Find("texto_alternativaVazia").GetComponent<Text>().text = "";
                GameObject.Find("Adicionar Pergunta").GetComponent<inserirPergunta>().set_altVazia(false);
            }
        }
    }

}
