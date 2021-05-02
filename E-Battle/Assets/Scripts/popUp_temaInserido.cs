using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popUp_temaInserido : MonoBehaviour
{
    private static Text texto;
    private static bool naTela = false;
    private static float tempoTela = 3.0f;
    private static AudioSource audioTemaInserido;


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
            texto = GameObject.Find("tema_inserido").GetComponent<Text>();
            texto.text = "Tema inserido com sucesso.";
            naTela = true;
            audioTemaInserido = GameObject.Find("tema_inserido").GetComponent<AudioSource>();
            audioTemaInserido.Play();
        }
        
    }

}
