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

    [SerializeField]
    private AudioSource audiosource;

    void Start()
    {
        if (tocarMusica)
            audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
