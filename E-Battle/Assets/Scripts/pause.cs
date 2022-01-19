using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    bool menu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!menu){
                GameObject.Find("menu_esc").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1);
                menu = true;
            }else{
                GameObject.Find("menu_esc").transform.position = new Vector3(3000, 0, 0);
                menu = false;
            }
                
        }
    }

    public void novoJogo(){
        SceneManager.LoadScene("Começar Jogo", LoadSceneMode.Single);
    }

    public void criarTema(){
        SceneManager.LoadScene("Criação de temas", LoadSceneMode.Single);
    }

    public void criarPerguntas()
    {
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }

    public void continuar(){
        menu = false;
        GameObject.Find("menu_esc").transform.position = new Vector3(3000, 0, 0);
    }
}
