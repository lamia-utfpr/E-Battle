using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SeleçãoDeTemas : MonoBehaviour
{

    FileInfo[] temas;

    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/temas/");
        temas = dir.GetFiles("*.txt");
        //var fileInfo = Directory.getFiles(Application.dataPath + "/temas/","*.txt");
    }

    // Update is called once per frame
    void Update()
    {
        //DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/temas/");
        //FileInfo[] temas = dir.GetFiles("*.txt");
        foreach (FileInfo f in temas)
        {
            Debug.Log(f);
        }
    }
}
