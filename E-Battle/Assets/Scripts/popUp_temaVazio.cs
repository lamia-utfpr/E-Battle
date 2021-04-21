using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_temaVazio : MonoBehaviour
{
private static Text texto;
    private static bool naTela = false;

    private static float tempoTela = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    

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
            
            texto.text = "";
            naTela = false;
            tempoTela = 3.0f;
        }
    }

    public static void mostrarPopUp(){
        if (!naTela){
            texto = GameObject.Find("tema_vazio").GetComponent<Text>();
            texto.text = "Tema vazio! Insira algo!";
            naTela = true;
        }
        
    }

}
