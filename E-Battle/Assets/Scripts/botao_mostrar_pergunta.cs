using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao_mostrar_pergunta : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool mostrarPergunta = false;

    [SerializeField]
    private AudioSource som;

    [SerializeField]
    private AudioClip cronometro;

    [SerializeField]
    private GameObject botao;

    [SerializeField]
    private GameObject painelPergunta;

    [SerializeField]
    private GameObject cameraTabuleiro;

    [SerializeField]
    private GameObject powerups;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrarPergunta)
            botao.GetComponent<Button>().interactable = true;
        else
            botao.GetComponent<Button>().interactable = false;
    }

    public void mostrarPainel()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {
        if (mostrarPergunta)
        {
<<<<<<< Updated upstream
            GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
            GameObject.Find("powerups").transform.position = GameObject.Find("painel_Pergunta").transform.position + new Vector3(-850, 0, 0);
=======
            painelPergunta.transform.position = cameraTabuleiro.transform.position + new Vector3(0, 0, 1);
            powerups.transform.position = painelPergunta.transform.position + new Vector3(-850, -100, 0);
>>>>>>> Stashed changes
            mostrarPergunta = false;
            som.clip = cronometro;
            som.Play();
        }

    }

}
