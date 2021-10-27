using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao_mostrar_pergunta : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool mostrarPergunta = false;
    private AudioSource som;
    public AudioClip cronometro;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrarPergunta)
            GameObject.Find("HUD_principal/Botao").GetComponent<Button>().interactable = true;
        else
            GameObject.Find("HUD_principal/Botao").GetComponent<Button>().interactable = false;
    }

    public void mostrarPainel()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {
        if (mostrarPergunta)
        {
            GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
            GameObject.Find("powerups").transform.position = GameObject.Find("painel_Pergunta").transform.position + new Vector3(-850, -100, 0);
            mostrarPergunta = false;
            som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
            som.clip = cronometro;
            som.Play();
        }

    }

}
