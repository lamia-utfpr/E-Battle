using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class musica_fundo : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool tocarMusica;

    void Start()
    {
        if (tocarMusica)
            GameObject.Find("Musica_Fundo").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
