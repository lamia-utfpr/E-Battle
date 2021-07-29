using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class verificarAltVazia : MonoBehaviour
{

    private bool naTela = false;
    private float tempoTela = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (naTela)
            tirarTela();
    }

    public void verificar(){
        InputField inputfield = GameObject.Find(this.name).GetComponent<InputField>();

        if (inputfield.interactable){
            if (String.IsNullOrWhiteSpace(inputfield.text)){
                GameObject.Find("texto_alternativaVazia").GetComponent<Text>().text = "Preencha todas as alternativas!";
                GameObject.Find("Adicionar Pergunta").GetComponent<inserirPergunta>().set_altVazia(true);
                naTela = true;
            }else{
                GameObject.Find("texto_alternativaVazia").GetComponent<Text>().text = "";
                GameObject.Find("Adicionar Pergunta").GetComponent<inserirPergunta>().set_altVazia(false);
            }
        }
    }

    private void tirarTela(){
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;

        }
        else
        {
            GameObject.Find("texto_alternativaVazia").GetComponent<Text>().text = "";
            naTela = false;
            tempoTela = 4.0f;
        }
    }

}
