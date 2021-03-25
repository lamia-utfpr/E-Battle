using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarConfirmacao : MonoBehaviour
{
    private static Text texto;
    private static bool naTela = false;

    private static float tempoTela = 2.5f;

    void Start()
    {
        
    }


    public static bool get_naTela(){
        return naTela;
    } 

    // Update is called once per frame
    void Update()
    {
        
        if (naTela){
            removerTela();
        }

    }

    public static void removerTela(){
        if (tempoTela > 1){
            tempoTela -= Time.deltaTime;
            
        }
        else{
            GameObject.Find("confirmação_inserção").GetComponent<Text>().text = "";
            naTela = false;
            tempoTela = 3.0f;
        }
    }

    public static void mostrar(){
        if (!naTela){
            texto = GameObject.Find("confirmação_inserção").GetComponent<Text>();
            texto.text = "Pergunta inserida com sucesso!";
            naTela = true;
        }
        
    }
}
