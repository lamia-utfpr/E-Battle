using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class mudar_valor_pergunta : MonoBehaviour
{
    [SerializeField]
    private GameObject perguntaVazia;

    [SerializeField]
    private GameObject alerta;

    [SerializeField]
    private GameObject alertaPositivo;

    [SerializeField]
    private GameObject menu;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tirarmensagem(){
        perguntaVazia.GetComponent<Text>().text = "";
        alerta.transform.position = menu.transform.position + new Vector3(-2000, 0, 1);
        alertaPositivo.transform.position = menu.transform.position + new Vector3(-2000, 0, 1);

    }
}
