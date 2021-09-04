using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class mudar_valor_pergunta : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tirarmensagem(){
        GameObject.Find("CaixaDaPergunta/Pergunta_vazia").GetComponent<Text>().text = "";
        GameObject.Find("alerta").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(-2000, 0, 1);
        GameObject.Find("alerta_positivo").transform.position = GameObject.Find("fundo_menu").transform.position + new Vector3(-2000, 0, 1);

    }
}
