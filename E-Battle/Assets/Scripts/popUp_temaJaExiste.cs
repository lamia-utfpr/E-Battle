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

    [SerializeField]
    private AudioSource audioTemaExistente;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject fundoMenu;

    [SerializeField]
    private GameObject temaExiste;

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

    public void removerTela(){
        if (tempoTela > 1){
            tempoTela -= Time.deltaTime;
        }

        else{
            texto.text = "";
            naTela = false;
            tempoTela = 3.0f;
            alerta.transform.position = fundoMenu.transform.position + new Vector3(-2000, 0, 1);
        }
    }

    public void mostrarPopUp(){
        if (!naTela){
            alerta.GetComponentInChildren<Text>().text = "O tema já existe!";
            alerta.transform.position = fundoMenu.transform.position + new Vector3(0, 0, 1);

        	audioTemaExistente.Play();
            texto = temaExiste.GetComponent<Text>();
            texto.text = "";
            naTela = true;
            
        }
        
    }

}
