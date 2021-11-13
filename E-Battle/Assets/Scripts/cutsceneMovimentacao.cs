using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneMovimentacao : MonoBehaviour
{
    // Start is called before the first frame update

    private static bool naTela = false;

    //esse aqui é o tempo que vai ficar na tela, só alterar pra duração do video
    private static float tempoTela = 5.0f;

    [SerializeField]
    private GameObject cutsceneMovimento;

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
            GameObject.Find("painel_cutsceneMovimentacao").transform.position = new Vector3(0, 10000, 1);
            naTela = false;
            tempoTela = 5.0f;
        }
    }

    public void mostrarCutscene(){
        if (!naTela){
            GameObject.Find("painel_cutsceneMovimentacao").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
            naTela = true;
        }
    }

}
