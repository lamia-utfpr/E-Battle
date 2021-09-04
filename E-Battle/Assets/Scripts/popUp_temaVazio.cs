using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_temaVazio : MonoBehaviour
{
private static Text texto;
    private static bool naTela = false;
    private static float tempoTela = 3.0f;
    public static AudioSource audioTemaVazio;

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
            GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(-2000, 0, 1);
        }
    }

    public static void mostrarPopUp(){
        if (!naTela){
            GameObject.Find("alerta/Text").GetComponent<Text>().text = "Tema vazio! Insira algo!";
            GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);

            texto = GameObject.Find("tema_vazio").GetComponent<Text>();
            texto.text = "";
            naTela = true;
            audioTemaVazio = GameObject.Find("tema_vazio").GetComponent<AudioSource>();
            audioTemaVazio.Play();
        }
        
    }


}
