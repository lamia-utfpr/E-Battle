using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarConfirmacao : MonoBehaviour
{
    private static Text texto;
    private static bool naTela = false;

    private static float tempoTela = 4f;

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
            tempoTela = 4.0f;
        }
    }

    public static void mostrar(){
        if (!naTela){
            //texto = GameObject.Find("confirmação_inserção").GetComponent<Text>();
            //texto.text = "Pergunta inserida com sucesso!";
            GameObject.Find("alerta_positivo/Text").GetComponent<Text>().text = "Pergunta inserida com sucesso!";
            GameObject.Find("alerta_positivo").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);
            naTela = true;
        }
        
    }
}
