using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class toggleRet1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject tabela;

    [SerializeField]
    private int alternativa;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getStatus()
    {
        return this.GetComponent<Toggle>().isOn;
    }

    public void statusToggle1()
    {
        if (this.GetComponent<Toggle>().isOn == true)
        {
            tabela.GetComponent<tabelaDosTemas>().ToggledAlt(alternativa);
        }
    }
}
