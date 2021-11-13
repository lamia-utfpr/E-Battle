using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarConfirmacao : MonoBehaviour
{
    // Start is called before the first frame update
    private static Text texto;
    private static bool naTela = false;

    private static float tempoTela = 4f;


    [SerializeField]
    private GameObject confirma;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject menu;



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

    public void removerTela(){
        if (tempoTela > 1){
            tempoTela -= Time.deltaTime;
        }
        else{
            confirma.GetComponent<Text>().text = "";
            naTela = false;
            tempoTela = 4.0f;
        }
    }

    public void mostrar(){
        if (!naTela){

            alerta.GetComponent<Text>().text = "Pergunta inserida com sucesso!";
            alerta.transform.position = menu.transform.position + new Vector3(0, 0, 1);
            naTela = true;
        }
        
    }
}
