using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_temaJaExiste : MonoBehaviour
{
    // Start is called before the first frame update

    private static Text texto;
    private static bool naTela = false;
    private static float tempoTela = 3.0f;
    private static AudioSource audioTemaExistente;


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
            GameObject.Find("alerta/Text").GetComponent<Text>().text = "O tema já existe!";
            GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(0, 0, 1);

            audioTemaExistente = GameObject.Find("tema_ja_existe").GetComponent<AudioSource>();
        	audioTemaExistente.Play();
            texto = GameObject.Find("tema_ja_existe").GetComponent<Text>();
            texto.text = "";
            naTela = true;
            
        }
        
    }

}
