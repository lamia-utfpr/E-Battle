using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class voltarMenuInicial : MonoBehaviour
{
    public AudioSource audioVoltar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menuInicial(){
        audioVoltar = GameObject.Find("voltar").GetComponent<AudioSource>();
        audioVoltar.Play();
        SceneManager.LoadScene("Tela Inicial", LoadSceneMode.Single);
    }
}
