using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class tirar_musica_tabuleiro : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool estadoAtual;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        estadoAtual = this.GetComponent<Toggle>().isOn;
    }

}
