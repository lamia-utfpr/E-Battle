using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_pergunta : MonoBehaviour
{
    // Start is called before the first frame update
private static Text texto;
    private static bool naTela = false;

    private static float tempoTela = 3.0f;

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
            GameObject.Find("popUp_perguntaRespondida").transform.position = new Vector3(0, 10000, 1);
            naTela = false;
            tempoTela = 3.0f;
        }
    }

    public static void mostrarPopUp(int op){
        if (!naTela){
            texto = GameObject.Find("popUp_perguntaRespondida/texto_popUpPergunta").GetComponent<Text>();
            GameObject.Find("popUp_perguntaRespondida").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 200, 1);
            if (op == 1)
                texto.text = "Resposta correta!";
            else if (op == 0)
                texto.text = "Resposta incorreta!";
            naTela = true;
        }
        
    }

}
