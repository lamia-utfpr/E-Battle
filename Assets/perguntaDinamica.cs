using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class perguntaDinamica : MonoBehaviour
{

    public string nomeArquivo = "teste.txt";
    public Text pergunta;

    void Start()
    {
       pergunta = GameObject.Find("Pergunta").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var sr = new StreamReader(Application.dataPath + "/" + nomeArquivo);
        var ConteudoArquivo = sr.ReadToEnd();
        sr.Close();
        pergunta.text = "ConteudoArquivo";
    }
}
