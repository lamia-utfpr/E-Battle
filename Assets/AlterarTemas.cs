using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AlterarTemas : MonoBehaviour
{

    string diretorio;
    public RawImage arquivo;

    public void abrirExplorer()
    {
        diretorio = EditorUtility.OpenFilePanel("Overwrite with png", Application.dataPath + "/temas/", "txt");
        abrirArquivo();
    }

    void abrirArquivo()
    {
        if(diretorio != null)
        {
            mostrarArquivo();
        }
    }

    void mostrarArquivo()
    {
        WWW www = new WWW("file:///" + diretorio);
        arquivo.texture = www.texture;
        Debug.Log(PlayerPrefs.GetString("path"));
        PlayerPrefs.SetString("path",diretorio);
        Debug.Log(PlayerPrefs.GetString("path"));
    }

}
